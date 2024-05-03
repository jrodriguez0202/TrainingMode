using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect;
    public QuizManager quizManager;
    public void Answer()
    {
        if (isCorrect) // checks if answer is correct, returns to QuizManager
        {
            Debug.Log("Correct");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Incorrect");
            quizManager.wrong();
        }
    }
}
