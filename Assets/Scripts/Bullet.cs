using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    private Vector2 screenBounds;

    //public GameObject impactEffect;

    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // Debug.Log(screenBounds.x);
        // Debug.Log(transform.position.x);
    }   

    private void Update() {
        if (transform.position.x > screenBounds.x * 2.575) {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            //boat
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    
}