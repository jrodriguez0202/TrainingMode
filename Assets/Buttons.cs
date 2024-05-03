using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Tells each button what to do
public class Buttons : MonoBehaviour
{  
    public void backToMenu() // Returns to stage selection menu
    {
        SceneManager.LoadScene("Stage Selection");
    }

    public void backToMainMenu() // Returns back to title screen
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void retryStage1() // Each reloads the assigned stage
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void retryStage2() { SceneManager.LoadScene("Stage 2"); }

    public void retryStage3() { SceneManager.LoadScene("Stage 3"); }

    public void retryStage4() { SceneManager.LoadScene("Stage 4"); }

    public void retryStage5() { SceneManager.LoadScene("Stage 5"); }

    public void retryStage6() { SceneManager.LoadScene("Stage 6"); }

    public void retryStage7() { SceneManager.LoadScene("Stage 7"); }

    public void retryStage8() { SceneManager.LoadScene("Stage 8"); }

    public void retryStage9() { SceneManager.LoadScene("Stage 9"); }
}
