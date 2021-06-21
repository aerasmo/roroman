using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// invuln patch
// notes:
// layer must be in 9 and 10 for boat and enemies
// boats need to be sprite renderer (readjust boxcolider and firepoint)
// ----------------------------------------------------------------------


public class playerController : MonoBehaviour
{
    public Rigidbody2D boat;
    public float speed = 50000f;
    public GameObject barrier; 


    public float ytop = 490f;
    public float ybot = 90f;
    public float xleft = 900f;
    public float xright = 1960f;
    // start new game
    // public int  levelMoney = 0;
    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;

    // invuln patch
    private Renderer rend;
    private Color c; 

    private GameObject barrierPrefab;
    public GameObject gameOver;
    public GameObject cd;


    private bool onCooldown;
    public int vel;
    void Awake() {
    }
    void Start () {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // invuln patch
        rend = GetComponent<Renderer> ();
        c = rend.material.color;

        StartCoroutine(music(vel));

        // switch(vel) {
        //     case 0:
        //         SoundManagerScript.PlaySound("boss battle normal");
        //         break;
        //     case 1:
        //         SoundManagerScript.PlaySound("LEVEL 1");
        //         break;

        // }
    }
    IEnumerator music(int vel) {
        yield return new WaitForSeconds(0.10f);
        switch (vel){
            case 0:
                SoundManagerScript.PlaySound("boss battle normal");
                break;
            case 1:
                SoundManagerScript.PlaySound("LEVEL 1");
                break;
        }
    }
    private void Update() {
        // // boundaries check
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        boat.velocity = new Vector2 (moveHorizontal, moveVertical)*speed*Time.deltaTime;
        // Debug.Log(boat.transform.position)s;

        if (Input.GetKeyDown("space"))
        {
            if (!onCooldown) {
                SoundManagerScript.PlaySound("skill button");

                print("Skill used");
                useSkill("barrier", 2);
                StartCoroutine(cooldownCountdown());
            } else {
                print("skill on cooldown");
                cd.SetActive(true);
            }
            // use skill
            // .getskill
            // audioSrc.PlayOneShot(skillButtonSound);

        }
        // boundaries
        checkBoundaries();

    }
    void useSkill(string skill, int cooldown) {
        switch (skill)
        {
            case "barrier":
                StartCoroutine("useBarrier");
                break;
            default:
                break;
        }
    }
    IEnumerator cooldownCountdown() {
        onCooldown = true;
        yield return new WaitForSeconds(10);
        onCooldown = false;
        cd.SetActive(false);
    }

    void checkBoundaries(){
        if (boat.transform.position.y >= ytop) {
            boat.transform.position = new Vector3(boat.transform.position.x, ytop, 0);
        }
        else if (boat.transform.position.y <= ybot) {
            boat.transform.position = new Vector3(boat.transform.position.x, ybot, 0);
        }
        if (boat.transform.position.x <= xleft) {
            boat.transform.position = new Vector3(xleft, boat.transform.position.y, 0);
        }
        else if (boat.transform.position.x >= xright) {
            boat.transform.position = new Vector3(xright, boat.transform.position.y, 0);
        }
    }
    void TakeDamage (){
        // added 
        print("Took damage");
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
        boat.transform.position = new Vector3(866f,302f, 0);
        // animate boat explode

        SoundManagerScript.PlaySound("damaged");

        // boat.transform.position = new Vector3()
        if (currentHealth <= 0) {
            print("Player died");
            Die();
            // insert died screen here 
            // restart the scene
        }
        // invuln patch
        else{
            StartCoroutine("Invuln");
        }
        
    }
    void Die ()
    {
        SoundManagerScript.PlaySound("dead");
        Time.timeScale = 0;
        gameOver.SetActive(true);
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Destroy(gameObject);

    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
            
        {
            TakeDamage(); // boat

        }
    }
    // public void AddMoney (int amount) {
    //     Debug.Log(levelMoney);
    //     levelMoney += amount; 
    //     scoreText.text = levelMoney.ToString();

    //     // TODO add UI for
    // }
    // invuln patch
    IEnumerator Invuln() {
        Physics2D.IgnoreLayerCollision (9, 10, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds (2f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        c.a = 1f;
        rend.material.color = c;
    }
    // barrier
    IEnumerator useBarrier() {
        SoundManagerScript.PlaySound("invincibility");

        print("Using barrier");
        barrier.SetActive(true);
        // some sprite on
        // c.a = 0.5f;
        // rend.material.color = c;
        Physics2D.IgnoreLayerCollision (9, 10, true);
        yield return new WaitForSeconds (4f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        barrier.SetActive(false);
        // c.a = 1f;
        // rend.material.color = c;

    }
}

