using System.Collections;
using System.Collections.Generic;
using TMPro;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Manages Quiz function
public class QuizManager : MonoBehaviour
{
    public List<QanA> QandA; // Puts Questions and Answers into a list
    public GameObject[] options; // answers
    public int currentQuestion; // current question

    public GameObject GameOverPanel;
    public GameObject correctPanel;

    public TextMeshProUGUI QuestTxt;
    public Text ScoreTxt;
    public Text correctTxt;

    public Button closeButton;

    int totalQuestions = 0;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        totalQuestions = QandA.Count;
        currentQuestion = 0;
        GameOverPanel.SetActive(false);
        correctPanel.SetActive(false);
        generateQuestion();
        score = 0;
    }

    public void retry() // Loads Quiz Again
    {
        SceneManager.LoadScene("Quiz"); 
    }


    public void GameOver() // Displays score once quiz is complete
    {
        GameOverPanel.SetActive(true);
        ScoreTxt.text = score + "/5"; 
    }

    public void correct() // If answer is correct 
    {
        score += 1;
        QandA.RemoveAt(currentQuestion);
        generateQuestion();
        correctPanel.SetActive(true);
        correctTxt.text = "CORRECT!";
    }

    public void wrong() // If answer is wrong
    {
        
        QandA.RemoveAt(currentQuestion);
        generateQuestion();
        correctPanel.SetActive(true);
        correctTxt.text = "INCORRECT";
    }

    void SetAnswers() // Sets the answers based off the four buttons 
    {
        for (int i = 0; i < options.Length; i++) 
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QandA[currentQuestion].Answers[i];

            if (QandA[currentQuestion].CorrectAnswer == i+1) // If corressponding button answer is true, sets it as true
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion() // Generates Question randomly
    {
        if (QandA.Count > 5) // Sets question limit to 5
        { 
            currentQuestion = Random.Range(0, QandA.Count); // randomizes what question is asked

            QuestTxt.text = QandA[currentQuestion].Question;
            SetAnswers();
        }
        else 
        {       
            Debug.Log("No Questions");
            GameOver();
        }
    }

    public void closePanel()
    {
        correctPanel.SetActive(false);
    }
}
