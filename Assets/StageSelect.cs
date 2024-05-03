using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Stage Selection Manager
public class StageSelect : MonoBehaviour
{
    public Dialouge dialouge;
    public void PlayStage1() // Loads stages 
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void PlayStage2() { SceneManager.LoadScene("Stage 2"); }

    public void PlayStage3() { SceneManager.LoadScene("Stage 3"); }

    public void PlayStage4() { SceneManager.LoadScene("Stage 4"); }

    public void PlayStage5() { SceneManager.LoadScene("Stage 5"); }

    public void PlayStage6() { SceneManager.LoadScene("Stage 6"); }

    public void PlayStage7() { SceneManager.LoadScene("Stage 7"); }

    public void PlayStage8() { SceneManager.LoadScene("Stage 8"); }

    public void PlayStage9() { SceneManager.LoadScene("Stage 9"); }

    public void backButton() { SceneManager.LoadScene("Main Menu"); }


}       
