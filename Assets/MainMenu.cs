using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main Menu Manager
public class MainMenu : MonoBehaviour
{
    public void Play() // Play Button
    {
        SceneManager.LoadScene("Stage Selection");
    }
    public void Quiz() // Quiz Button
    {
        SceneManager.LoadScene("Quiz");
    }

    public void Glossary() // Glossary Button
    {
        SceneManager.LoadScene("Glossary");
    }
}
