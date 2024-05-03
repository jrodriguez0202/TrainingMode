using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glossary : MonoBehaviour
{
    public Dialouge dialouge;
    public Text glossaryText;
    public GameObject glossaryButton;

    private string sentences;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartDialouge() // Uses dialouge class to display definitions with buttons
    {
        foreach (string sentence in dialouge.sentences)
        {
            glossaryText.text = sentence;
        }
    }
}
