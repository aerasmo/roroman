﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public void Back() {
        string scenename = "splashscreen";
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(0);
    }
}
