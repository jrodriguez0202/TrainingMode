using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Guy Health Manager
public class PlayerGuy : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public bool isBlocking;

    public HealthBarP1 healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update() // sees if you are blocking or not
    {
        if (Input.GetKeyDown("b"))
        {
            isBlocking = true;
        }
        if (Input.GetKeyUp("b"))
        {
            isBlocking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("dialouge2"))
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
    public void TakeDamage(int damage) // subtracts when you get damaged 
    {
        if (!isBlocking) // checks to see if you are blocking to subtract damage or not
        {
            currentHealth -= damage;
        }
        healthBar.SetHealth(currentHealth);
    }
}
