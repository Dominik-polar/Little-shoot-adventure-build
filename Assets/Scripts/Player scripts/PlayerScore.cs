using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;
    public int killedEnemy=0;
    

    void Update()
    {
        scoreText.text = killedEnemy.ToString();
    }
}
