using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textBox;
    public string[] dialogSentences;
    private int index;
    public GameObject continueButton;
    private PlayerController controller;
    public GameObject player;
    public GameObject portal;

    public Animator animator;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        controller = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if(textBox.text == dialogSentences[index])
        {
            continueButton.SetActive(true);
        }    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Write());
            controller.enabled = false;
            animator.Play("Player_Idle");
        }
    }

    IEnumerator Write()
    {
        foreach(char letter in dialogSentences[index].ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSeconds(0.05f);
        }


    }

    public void Continue()
    {
        continueButton.SetActive(false);
        if (index < dialogSentences.Length - 1)
        {
            index++;
            textBox.text = "";
            StartCoroutine(Write());
        }
        else
        {
            textBox.text = "";
            controller.enabled = true;
            continueButton.SetActive(false);
            portal.SetActive(true);
        }
    }


    
}
