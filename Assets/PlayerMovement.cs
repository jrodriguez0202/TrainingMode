using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// Player Movement Manager, where all the movement for Guy, the main character, happens
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidBody; // Sets Guy for gravity
    public Sprite spIdle,spCrouch,spLP,spMP,spHP,spLK,spMK,spHK,spcLP,spBlock,spProj; // Holds all the sprites for Guy
    //public Animator animator; UNUSED CURRENTLY

    public Transform attackPoint; // Attack hitbox
    public float attackRange = 0.5f; // Hitbox range
    public LayerMask enemyLayers; // Checks to see if game object is enemy

    public ProjectileBehavior ProjectilePrefab; // Projectile Holder
    public Transform LaunchOffset; // Where the projectile is launched from

    private bool isJumping; // checks to see if player is jumping

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* MOVEMENT */
        float dirX = Input.GetAxis("Horizontal");
        myRigidBody.velocity = new Vector2 (dirX * 7f, myRigidBody.velocity.y);

        //animator.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            myRigidBody.velocity = new Vector2(0, 16f);
            isJumping = true;
        }


        /* ACTIONS */

        // Light Punch
        if (Input.GetKeyDown("u"))
        {
            GetComponent<SpriteRenderer>().sprite = spLP;
            Attack(50);
        }
        if (Input.GetKeyUp("u"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Medium Punch
        if (Input.GetKeyDown("i"))
        {
            GetComponent<SpriteRenderer>().sprite = spMP;
            Attack(75);

        }
        if (Input.GetKeyUp("i"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Heavy Punch
        if (Input.GetKeyDown("o"))
        {
            GetComponent<SpriteRenderer>().sprite = spHP;
            Attack(100);

        }
        if (Input.GetKeyUp("o"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Light Kick
        if (Input.GetKeyDown("j"))
        {
            GetComponent<SpriteRenderer>().sprite = spLK;
            Attack(50);

        }
        if (Input.GetKeyUp("j"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Medium Kick
        if (Input.GetKeyDown("k"))
        {
            GetComponent<SpriteRenderer>().sprite = spMK;
            Attack(75);

        }
        if (Input.GetKeyUp("k"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Heavy Kick
        if (Input.GetKeyDown("l"))
        {
            GetComponent<SpriteRenderer>().sprite = spHK;
            Attack(100);

        }
        if (Input.GetKeyUp("l"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Crouch
        if (Input.GetKeyDown("s"))
        {
            GetComponent<SpriteRenderer>().sprite = spCrouch;

            if (Input.GetKeyDown("i") && Input.GetKeyDown("s") == true)
            {
                GetComponent<SpriteRenderer>().sprite = spcLP;
            }
            if (Input.GetKeyUp("i"))
            {
                GetComponent<SpriteRenderer>().sprite = spCrouch;
            }

        }
        if (Input.GetKeyUp("s")) 
        { 
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Block
        if (Input.GetKeyDown("b"))
        {
            GetComponent<SpriteRenderer>().sprite = spBlock;
        }
        if (Input.GetKeyUp("b"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }

        // Projectile
        if (Input.GetKeyDown("p"))
        {
            GetComponent<SpriteRenderer>().sprite = spProj;
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
        if (Input.GetKeyUp("p"))
        {
            GetComponent<SpriteRenderer>().sprite = spIdle;
        }
    }

    void Attack(int damage) // Where attack is registered 
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // Creates Circle Hitbox

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Guy hit " + enemy.name + "for " + damage);
            enemy.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor")) // Checks to see if jumping, allows only for one jump
        {
            isJumping = false;
        }
    }

    private void OnDrawGizmosSelected() // Displays hitbox
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
