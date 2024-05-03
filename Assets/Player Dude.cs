using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main Manager Class for Dude
public class Player : MonoBehaviour
{
    public int maxHealth = 1000; // Health Value
    public int currentHealth;

    public HealthBar healthBar;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public float attackCooldown = 2f;
    public float attackTimer;
    public float attackDistance = 3f;
    public Sprite spIdle, spCrouch, spLP, spMP, spHP, spLK, spMK, spHK, spProj;
    
    private Transform guyPos;
    public float speed = 2.5f;
    public bool isTouching = false;
    //public DialougeManager dialougeManager;
   // public Collision2D collision;

    private string scene;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // sets his health 
        healthBar.SetMaxHealth(maxHealth); // Sets Health Bar
        //health.GetCurrentHealth(maxHealth);
        scene = SceneManager.GetActiveScene().name; // Sets scene variable so certain functions perform under certain scenes
        guyPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 2.5f; // sets Player speed
    }

    // Update is called once per frame
    void Update()
    {
        // Attack Timer
        attackTimer = attackTimer + 1f * Time.deltaTime;
        attackTimer = Mathf.Clamp(attackTimer, 0f, attackCooldown);
        if (attackTimer >= attackCooldown && (scene == "Stage 3"  || scene == "Stage 9")) // only attacks during Stage 3 and 9
        {
            //Attack Player
            attackTimer = 0f;
            Debug.Log("Attacking!");

            GetComponent<SpriteRenderer>().sprite = spLP;
            Attack(50);
        }
        if (attackTimer >= .3f)
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        if (attackTimer >= attackCooldown && (scene == "Stage 7" || scene == "Stage 9"))
        {
            //Attack Player
            attackTimer = 0f;
            Debug.Log("Enemy Attacking Player!");

            System.Random random = new System.Random(); // Generates random number to attack
            int num = random.Next(1,6);

            switch (num) // throws attack out based off num
            {
                case 1:
                    GetComponent<SpriteRenderer>().sprite = spLP; // light punch
                    Attack(50); // How much damage the attack does
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = spMP; // medium punch
                    Attack(75);
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = spHP; // heavy punch
                    Attack(100);
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().sprite = spLK; // light kick
                    Attack(50);
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().sprite = spMK; // medium kick
                    Attack(75);
                    break;
                case 6:
                    GetComponent<SpriteRenderer>().sprite = spHK; // heavy kick
                    Attack(100);
                    break;
            }

            System.Random atkCoolRand = new System.Random();
            float atkRand = atkCoolRand.Next(1,2);
            attackCooldown = atkRand;

        }
        if (attackTimer >= .3f)
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        if (scene == "Stage 8" || scene == "Stage 9") // moves towards Player during Stage 8 and 9 
        {
            transform.position = Vector2.MoveTowards(transform.position, guyPos.position, speed * Time.deltaTime);

        }
    }


    public void TakeDamage(int damage) // When he is hit, takes set damage from move
    {
        currentHealth -= damage; 

        healthBar.SetHealth(currentHealth); // updates health bar
    }

    void Attack(int damage) // Attack manager
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers); // creates circle hitbox

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Guy hit " + enemy.name + "for " + damage);
            if (Input.GetKeyDown("b") == true) // if opponent is blocking, damage is nullified
            {
                damage = 0;
            }
            enemy.GetComponent<PlayerGuy>().TakeDamage(damage); // sends damage to guy
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            speed = 0f;
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speed = -2f; // sends Dude back a bit when coming into contact with player
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        speed = 2.5f; // resumes chase
    }

    private void OnDrawGizmosSelected() // displays hitbox radius
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
