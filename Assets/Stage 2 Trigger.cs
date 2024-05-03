using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Triggers End Dialouge
public class Stage2Trigger : MonoBehaviour
{
    public Dialouge dialouge;
    public Collider2D collision2D;

    private void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.tag == "dialouge2") // checks to see if dialouge is the last dialouge avilable
        {
            Debug.Log("touch");
            Destroy(gameObject);
            FindObjectOfType<Stage2Dialouge>().boolDialouge();
            TriggerDialouge();
        }
        else
        {
            TriggerDialouge();
        }

        if (other.tag == "Player" && gameObject.tag == "dialouge9")
        {
            Destroy(gameObject);
            TriggerDialouge();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) // When player enters hidden game object dialouge, deletes it
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void TriggerDialouge() // Triggers starts dialouge in Stage2Dialouge class
    {
        FindObjectOfType<Stage2Dialouge>().StartDialouge(dialouge);
    }
}
