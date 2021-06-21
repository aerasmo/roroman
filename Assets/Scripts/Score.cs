using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int money;
    public Text scoreText;
    // Start is called before the first frame update
    void Start () {
        scoreText = GetComponent<Text>();
        money = 0;
        // scoreText.text = "0";
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = money.ToString();
    }
}
