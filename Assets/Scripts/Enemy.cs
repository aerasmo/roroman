using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Enemy :MonoBehaviour {

    public EnemyData enemyData;

    private int health;
    private int bounty;
    private float speed;

    [SerializeField]
    private Transform[] routes;

    // public playerController boat;
    public Rigidbody2D enemy;
    private Vector2 screenBounds;

    // color blink patch
    private Renderer rend;
    private Color c; 
    // route movement vars
    
    private int routeToGo;
    private float tParam;
    private Vector2 enemyPosition;

    private float speedModifier;
    private bool coroutineAllowed;

    public HealthBar healthBar;
    public GameObject youwinPanel;
    public GameObject arlongBar;

    void Awake() {

    }
    void Start() {
        health = enemyData.health;
        this.bounty = enemyData.bounty;
        this.speed = enemyData.speed;
        if (enemyData.name == "Arlong") {
            arlongBar.SetActive(true);

            // yield return new WaitForSeconds(5);
            healthBar.SetMaxHealth(health);
        }


        Physics2D.IgnoreLayerCollision (10, 10, true);
        // enemy.velocity = new Vector2 (speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // color blink patch
        rend = GetComponent<Renderer> ();
        c = rend.material.color;
        // route movement

        // print(enemyData.routes[1]);
        routeToGo = 0;
        tParam = 0f;
        // speedModifier = 0.5f;
        coroutineAllowed = true;
        // print("turtle at" + enemy.transform.position);

        routes = enemyData.routes;
        for (int i = 0; i < routes.Length; i++) {
            // routes[i].transform.position = new Vector2(1403f, enemy.transform.position.y + 450);
            routes[i].transform.position = new Vector2(enemy.transform.position.x - 771.8f, enemy.transform.position.y + 450f);
            // ownroute[i].transform.position = new Vector2(enemy.transform.position.x - 771.8f, enemy.transform.position.y + 450f);
            // print("pos ------------------");
            // print(this.routes[i].position);
        };
    }


    private void Update() {
        if (enemy.position.x < screenBounds.x - 150f) {
            if (enemyData.name == "Arlong") {
                // yield return new WaitForSeconds(5);
            }
            else {
                Destroy(this.gameObject);
            }
        }

        // TODO if turtle 
        if (coroutineAllowed) {
            StartCoroutine(GoBytheRoute(routeToGo));
            // print(routes[1].transform.position);
            // print(routes[2].transform.position);
            // print(routes[3].transform.position);
        }
    
    }

    public void TakeDamage (int damage){
        health -= damage;
        if (enemyData.name == "Arlong") {
            healthBar.SetHealth(health);
        }

        if (health <= 0)
        {
            Die();
            // SoundManagerScript.PlaySound("bullet hell single");
        }
        // color blink patch
        else {
            StartCoroutine("Hit");
        }
    }

    void Die (){
        print("dying");

        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Score.money += bounty;
        if (enemyData.name == "Arlong") {
            SoundManagerScript.PlaySound("dynamite");

            SoundManagerScript.PlaySound("boss battle victory");
            Time.timeScale = 0;
            youwinPanel.SetActive(true);
            arlongBar.SetActive(false);

            // yield return new WaitForSeconds(5);
            // healthBar.SetMaxHealth(health);
        }
        Destroy(gameObject);
    }
    // color blink patch
    // changes opacity for 0.5 seconds (upon being hit)
    IEnumerator Hit() {
        // opacity
        c.a = 0.6f;
        rend.material.color = c;
        yield return new WaitForSeconds(0.10f);
        c.a = 1f;
        rend.material.color = c;
    }

    // curve route
    IEnumerator GoBytheRoute(int routeNumber) {
        // print(transform.position);
        coroutineAllowed = false;
        if (routeNumber == 0 & enemyData.name == "Arlong") {
            enemy.transform.position = routes[0].GetChild(0).transform.position;
            yield return new WaitForSeconds(5);
        }


    //    print("-------------------------------");
    //    print(routes[routeNumber].position);
    //    print(routes[routeNumber].position);
        //TODO update position origin to x minus enemy x pos
        Vector2 p0 = routes[routeNumber].GetChild(0).transform.position;
        // Vector2 p0 = ownroute[routeNumber].GetChild(0).transform.position;
        Vector2 p1 = routes[routeNumber].GetChild(1).transform.position;
        // Vector2 p1 = ownroute[routeNumber].GetChild(1).transform.position;
        Vector2 p2 = routes[routeNumber].GetChild(2).transform.position;
        // Vector2 p2 = ownroute[routeNumber].GetChild(2).transform.position;
        Vector2 p3 = routes[routeNumber].GetChild(3).transform.position;
        // Vector2 p3 = ownroute[routeNumber].GetChild(3).transform.position;

        while (tParam < 1) {
            tParam += Time.deltaTime * speed; 
            
            enemyPosition = Mathf.Pow(1-tParam, 3) * p0 +
                3 * Mathf.Pow(1-tParam, 2) * tParam * p1  +
                3 * (1- tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;
            
            // print(enemyPosition);
            enemy.transform.position = enemyPosition;
            // print(enemy.position);
            // yield return new WaitForSeconds(1);
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routeToGo += 1;
        if (routeToGo > routes.Length - 1) {
            routeToGo = 0;
            coroutineAllowed = false;
            if (enemyData.name == "Arlong") {
                coroutineAllowed = true;
        }
        }

        else {
            coroutineAllowed = true;
        }

        
    }
}