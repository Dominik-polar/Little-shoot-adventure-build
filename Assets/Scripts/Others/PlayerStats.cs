using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public Text winsText;
    public Text deathText;
    public Text killsText;
    public Text description;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            description.GetComponent<Text>().enabled = true;
            winsText.GetComponent<Text>().enabled = true;
            deathText.GetComponent<Text>().enabled = true;
            killsText.GetComponent<Text>().enabled = true;
            winsText.text = PlayerPrefs.GetInt("Wins").ToString();
            deathText.text = PlayerPrefs.GetInt("Deaths").ToString();
            killsText.text = PlayerPrefs.GetInt("Kills").ToString();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            description.GetComponent<Text>().enabled = false;
            winsText.GetComponent<Text>().enabled = false;
            deathText.GetComponent<Text>().enabled = false;
            killsText.GetComponent<Text>().enabled = false;
        }
    }
}
