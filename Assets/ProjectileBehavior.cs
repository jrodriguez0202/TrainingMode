using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 8f; // sets Projectile speed
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed; // sends projectile right based off time and speed
    }

    private void OnCollisionEnter2D(Collision2D collision) // Checks to see if it hits player or wall
    {
        Collider2D enemy = collision.gameObject.GetComponent<Collider2D>();

        if (collision.gameObject.CompareTag("Dude")) // Update damage if hits player
        {
            Destroy(gameObject);
            enemy.GetComponent<Player>().TakeDamage(50);
            
        }
        if (collision.gameObject.CompareTag("Wall")) // Just destroys object if it hits wall
        {
            Destroy(gameObject);
        }
    }

   
}
