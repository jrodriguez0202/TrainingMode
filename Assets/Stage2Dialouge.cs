using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Main Dialouge Manager
public class Stage2Dialouge : MonoBehaviour
{
    public TextMeshProUGUI dialougeText, buttonText;
    public GameObject retryButton, nextButton, menuButton, dialouge2;
    public bool endDialouge = false;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
 //       sentences.Clear();
    }
    public void StartDialouge(Dialouge dialouge) // Starts the dialouge and puts into the queue
    {
        
        sentences.Clear();
        nextButton.SetActive(true);
        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() // When Next button is pushed, display the next sentence
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        dialougeText.text = sentence;
    }

    void EndDialouge() // When dialouge is over, display buttons to return to next stage
    {
      
        nextButton.SetActive(false);


        if (endDialouge == true)
        {
            retryButton.SetActive(true);
            menuButton.SetActive(true);
        }
    }

    public void boolDialouge()
    {
        endDialouge = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        retryButton.SetActive(true);
    }

}
