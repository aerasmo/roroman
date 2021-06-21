using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject turtlePrefab;
    public GameObject dilisPrefab;
    public GameObject lapuPrefab;
    public GameObject tilapiaPrefab;
    public GameObject nochlessPrefab;
    public GameObject sharkPrefab;
    public float respawnTime = 1f;

    public GameObject arlongPrefab;

    private Vector2 screenBounds;
    static AudioSource audioSrc;

    public int level;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // StartCoroutine(turtleWave());
        // StartCoroutine(levelOneBoss());
        audioSrc = GetComponent<AudioSource>();

        switch(level) {
            case 0:
                StartCoroutine(endlessSpawner());
                break;
            case 1: 
                // StartCoroutine(levelOneBoss());
                // SoundManagerScript.PlaySound("LEVEL 1");

                StartCoroutine(levelOneSpawner());
                // StartCoroutine(levelOneSpawner());
                break;

        }
        // spawnArlong();


        // StartCoroutine(tilapiaWave());
        // StartCoroutine(sharkWave());
        // StartCoroutine(lapuWave());
        // spawnNochless();
    }
    // TODO error on random spawn
    void spawnTurtle() {
        GameObject turtle = Instantiate(turtlePrefab) as GameObject;
        turtle.transform.position = new Vector2(screenBounds.x *2.75f, Random.Range(-300f, 90f));
        // print("turtle atsssss" + turtle.transform.position);
    }
    void spawnDilis(int mode) {
        GameObject dilis = Instantiate(dilisPrefab) as GameObject;
        switch (mode) {
            case 1:
                dilis.transform.position = new Vector2(screenBounds.x *2.75f, Random.Range(-340f, 90f));
                break;
            case 2:
                dilis.transform.position = new Vector2(screenBounds.x *2.75f, Random.Range(-330f, 30f));
                break;
        }
        // print("dilis at" + dilis.transform.position);
    }
   void spawnTilapia() {
        GameObject tilapia = Instantiate(tilapiaPrefab) as GameObject;
        // tilapia.transform.position = new Vector2(screenBounds.x *2.75f, -200f);
        tilapia.transform.position = new Vector2(screenBounds.x * 2.75f + Random.Range(-100f, 500f), Random.Range(-270f, 20f));
        // print("tilapia at" + tilapia.transform.position);
    }
    void spawnLapu() {
        GameObject lapu = Instantiate(lapuPrefab) as GameObject;
        lapu.transform.position = new Vector2(screenBounds.x * 2.75f + Random.Range(-100f, 500f), Random.Range(-250f, -50f));
        // lapu.transform.position = new Vector2(screenBounds.x * 2.75f, Random.Range(-150f, 20f));
        print("lapu at" + lapu.transform.position);
        // 2174.8
        // 1403
    }
    // make shark faster
    void spawnShark(int mode) {
        print(mode);
        GameObject shark = Instantiate(sharkPrefab) as GameObject;
        // shark.transform.position = new Vector2(screenBounds.x *2.75f, 80f);
        // print("lapu at" + shark.transform.position);
        switch (mode) {
            case 0: 
                shark.transform.position = new Vector2(screenBounds.x *2.75f, Random.Range(70f, -300f));
                break;
            case 1:
                shark.transform.position = new Vector2(screenBounds.x *2.75f, -280f);
                break;
            case 2:
                shark.transform.position = new Vector2(screenBounds.x *2.75f, Random.Range(-150f, 0f));
                break;
            case 3:
                shark.transform.position = new Vector2(screenBounds.x *2.75f, 60f);
                break;
        }
    }
    void spawnNochless() {
        GameObject nochless = Instantiate(nochlessPrefab) as GameObject;
        nochless.transform.position = new Vector2(screenBounds.x *2.75f, -250f);
    }
    void spawnArlong() {
        GameObject arlong = Instantiate(arlongPrefab) as GameObject;
        arlong.transform.position = new Vector2(screenBounds.x *2.75f - 150f, 0f);
    }
    IEnumerator turtleWave(float seconds, int count, bool inf) {
        int i = 0;
        if (inf) {
            while (true) {
                spawnTurtle();
                yield return new WaitForSeconds(seconds);
            }
        }
        else {
        while(i < count) {
                yield return new WaitForSeconds(seconds);
                // yield return new WaitForEndOfFrame();
                spawnTurtle();
                i++;
            }
        }
    }
    IEnumerator endlessSpawner() {
        // spawnNochless(500);
        StartCoroutine(dilisWave(0.25f, 1, true));
        StartCoroutine(nochlessWave(80));
        StartCoroutine(tilapiaWave(1f, 20, true));
        StartCoroutine(sharkWave(1, 8f, 2, true));
        StartCoroutine(turtleWave(4f,  1, true));
        StartCoroutine(lapuWave(6f,  1, true));
        // StartCoroutine(arlongspawner(10f));
        StartCoroutine(sharkWaveTop(15f));
        StartCoroutine(sharkWaveBot(20f));

        yield return new WaitForSeconds(0);


    }
    IEnumerator arlongspawner(float seconds) {
        while (true) {
            spawnArlong();
            yield return new WaitForSeconds(seconds);
        }
    }
    IEnumerator levelOneSpawner() {

        // StartCoroutine(dilisWave(0.25f));
        StartCoroutine(dilisWave(0.75f, 20, false));

        yield return new WaitForSeconds(10);
        yield return new WaitForSeconds(10);
        // StartCoroutine(dilisWave(0.4f, 200));
        spawnTilapia();

        StartCoroutine(dilisWave(0.4f, 50, false));
        StartCoroutine(tilapiaWave(1f, 10, false));
        yield return new WaitForSeconds(15);
        StartCoroutine(tilapiaWave(0.75f, 25, false));
        StartCoroutine(dilisWave(0.30f, 50, false));
        yield return new WaitForSeconds(10);
        spawnTurtle();
        // StartCoroutine(dilisWave(0.5f, 15));
        yield return new WaitForSeconds(10);
        StartCoroutine(dilisPack(500));

        yield return new WaitForSeconds(3);
        // SoundManagerScript.Play()
        SoundManagerScript.PlaySound("boss battle normal");

        yield return new WaitForSeconds(6);
        StartCoroutine(levelOneBoss());
        // spawnArlong();
    }
    IEnumerator levelOneBoss() {

        arlongPrefab.SetActive(true);
        
        // SoundManagerScript.PlaySound("boss battle normal");
        // spawnArlong();
        StartCoroutine(sharkWave(1, 2.25f, 2, true));
        StartCoroutine(sharkWaveTop(3f));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(sharkWaveBot(2.5f));
        yield return new WaitForSeconds(60);
        StartCoroutine(sharkPack());
        // StartCoroutine(sharkWaveBot(f));
        // StartCoroutine(sharkWave(1, 3, 2, true));
        // StartCoroutine(sharkWave(1, 5, 3, true));


    }
    IEnumerator dilisWave(float seconds, int count, bool inf) {
        int i = 0;
        if (inf) {
            while (true) {
                spawnDilis(1);
                yield return new WaitForSeconds(seconds);
            }
        }
        else {
        while(i < count) {
                yield return new WaitForSeconds(seconds);
                // yield return new WaitForEndOfFrame();
                spawnDilis(1);
                i++;
            }
        }
 
    }
    IEnumerator nochlessWave(float seconds) {
        while(true) {
            spawnNochless();
            yield return new WaitForSeconds(seconds);

        }
    }
    IEnumerator dilisPack(int count) {
        int i = 0;
        while (i < count) {
        // while(true) {
            spawnDilis(2);
            yield return new WaitForEndOfFrame();
            i++;
        }
    }
    IEnumerator tilapiaWave(float seconds, int count, bool inf) {
        int i = 0;
        if (inf) {
            while (true) {
                spawnTilapia();
                yield return new WaitForSeconds(seconds);
            }
        }
        else {
        while(i < count) {
                yield return new WaitForSeconds(seconds);
                // yield return new WaitForEndOfFrame();
                spawnTilapia();
                i++;
            }
        }
    }
    IEnumerator lapuWave(float seconds, int count, bool inf) {
        int i = 0;
        if (inf) {
            while (true) {
                spawnLapu();
                yield return new WaitForSeconds(seconds);
            }
        }
        else {
        while(i < count) {
                yield return new WaitForSeconds(seconds);
                // yield return new WaitForEndOfFrame();
                spawnLapu();
                i++;
            }
        }
    }
    // SHARK ------------------------------------
    IEnumerator sharkPack() {
        while(true) {
            yield return new WaitForEndOfFrame();
            // yield return new WaitForSeconds(seconds);
            spawnShark(0);
        }
    }
    IEnumerator sharkWave(int count, float seconds, int mode, bool inf) {
        int i = 0;
        if (inf) {
            while(true) {
                yield return new WaitForSeconds(seconds);
                spawnShark(mode);
            }
        }
        else {
            while(i < count) {
                yield return new WaitForSeconds(seconds);
                spawnShark(mode);
                i++;
            }
        }
    }
    IEnumerator sharkWaveTop(float seconds) {
        while(true) {
            yield return new WaitForSeconds(seconds);
            spawnShark(3);
        }
    }
    IEnumerator sharkWaveBot(float seconds) {
        while(true) {
            yield return new WaitForSeconds(seconds);
            spawnShark(1);
        }
    }
}
