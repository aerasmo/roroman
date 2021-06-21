using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip titleScreenSound, level1Sound, level3Sound, level5Sound, normalBossFightSound, intenseBossFightSound, victoryBossFightSound, bulletFireSound, dynamiteSound, baitSound, invincibilitySound, fishnetSound, skillButtonSound, damagedSound, deadSound;
    static AudioSource audioSrc;


    void Awake() {

    }
    void Start()
    {
        titleScreenSound = Resources.Load<AudioClip>("title screen"); 
        
        level1Sound = Resources.Load<AudioClip>("LEVEL 1");
        level3Sound = Resources.Load<AudioClip>("LEVEL 3");
        level5Sound = Resources.Load<AudioClip>("LEVEL 5");
        normalBossFightSound = Resources.Load<AudioClip>("boss battle normal");
        intenseBossFightSound = Resources.Load<AudioClip>("boss battle intense");
        victoryBossFightSound = Resources.Load<AudioClip>("boss battle victory");
        bulletFireSound = Resources.Load<AudioClip>("bullet hell single");
        dynamiteSound = Resources.Load<AudioClip>("dynamite");
        baitSound = Resources.Load<AudioClip>("bait");
        invincibilitySound = Resources.Load<AudioClip>("invincibility");
        fishnetSound = Resources.Load<AudioClip>("fishnet");
        skillButtonSound = Resources.Load<AudioClip>("skill button");
        damagedSound = Resources.Load<AudioClip>("damaged");
        deadSound = Resources.Load<AudioClip>("dead");

        audioSrc = GetComponent<AudioSource>();
        // if (instance == null)
        // { 
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);
        //     return;
        // }
        // if (instance == this) return; 
        // Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip){ 
        switch (clip){
            case "title screen":
                titleScreenSound = Resources.Load<AudioClip>("title screen"); 
                audioSrc.loop = true;
                audioSrc.clip = titleScreenSound;
                audioSrc.Play();
                break;
            case "LEVEL 1":
                // audioSrc.loop = true;
                level1Sound = Resources.Load<AudioClip>("LEVEL 1");
                audioSrc.clip = level1Sound;
                audioSrc.PlayOneShot(level1Sound);
                break;
            case "LEVEL 3":
                level3Sound = Resources.Load<AudioClip>("LEVEL 3");

                audioSrc.PlayOneShot(level3Sound);
                break;
            case "LEVEL 5":
                level5Sound = Resources.Load<AudioClip>("LEVEL 5");

                audioSrc.PlayOneShot(level5Sound);
                break;
            case "boss battle normal":
                normalBossFightSound = Resources.Load<AudioClip>("boss battle normal");
                audioSrc.loop = true;
                audioSrc.clip = normalBossFightSound;
                audioSrc.Play();
                break;
            case "boss battle intense":
                intenseBossFightSound = Resources.Load<AudioClip>("boss battle intense");

                audioSrc.PlayOneShot(intenseBossFightSound);
                break;
            case "boss battle victory":
                victoryBossFightSound = Resources.Load<AudioClip>("boss battle victory");

                audioSrc.PlayOneShot(victoryBossFightSound);
                break;
            case "bullet hell single":
                audioSrc.PlayOneShot(bulletFireSound);
                break;
            case "dynamite":
                audioSrc.PlayOneShot(dynamiteSound);
                break;
            case "bait":
                audioSrc.PlayOneShot(baitSound);
                break;
            case "invincibility":
                audioSrc.PlayOneShot(invincibilitySound);
                break;
            case "fishnet":
                audioSrc.PlayOneShot(fishnetSound);
                break;
            case "skill button":
                audioSrc.PlayOneShot(skillButtonSound);
                break;
            case "damaged":
                audioSrc.PlayOneShot(damagedSound);
                break;
            case "dead":
                audioSrc.PlayOneShot(deadSound);
                break;
        }
    }
}