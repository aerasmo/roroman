using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start(){
        InvokeRepeating("Shoot", 0, 0.3f);
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // SoundManagerScript.PlaySound("bullet hell single");
    }
}