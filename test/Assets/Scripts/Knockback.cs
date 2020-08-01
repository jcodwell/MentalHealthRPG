using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust; // force the character knock things back
    public float knockTime; // give time for the knock back 

    // if the enemy is in the trigger area
    private void OnTriggerEnter2D(Collider2D other) // no reason to put other here
    {
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player")) // for pot
        {
            other.GetComponent<Pot>().Smash(); // trigger breakable tag and break the pot
        }

        // find tag either player or enemy
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null) // if there is a rigid body
            {

                // dynamic rigid body = move by physical system, use direction, or forces
                // kinematic rigid body = move by script
                // then apply the force
                // find the difference between the two of us
                Vector2 difference = hit.transform.position - transform.position;
                // normalized the difference and mul by thrust
                difference = difference.normalized * thrust;
                // use impulse to in addforce
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("enemy"))
                {
                    // enter stagger state
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }

                if (other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().Knock(knockTime);
                }
            }
        }
    }
}