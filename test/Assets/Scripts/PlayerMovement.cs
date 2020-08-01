using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState // state machine
{
    walk,
    attack,
    interact,  // not yet used
    stagger,
    idle
}


public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk; // set current state as walk
        myRigidbody = GetComponent<Rigidbody2D>(); // call the rigidbody
        animator = GetComponent<Animator>(); // call the animator
        animator.SetFloat("moveX", 0); 
        animator.SetFloat("moveY", -1); // fix it as the down attack at the beginning
                                        // otherwise all 4 hitboxes will activate at the beginning
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; // set change as zero
        change.x = Input.GetAxisRaw("Horizontal"); // x controlled by horizontal
        change.y = Input.GetAxisRaw("Vertical"); // y controlled by vertical
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger) 
        { // press attack key [space] and when current state is not in attack state
            StartCoroutine(AttackCo()); // start coroutine attack
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle) // dependent of the above if, use else if 
        {
            UpdateAnimationAndMove(); // move routine for walk state
        }
    }

    private IEnumerator AttackCo() // attack routine
    {
        animator.SetBool("attacking", true); // set attacking true
        currentState = PlayerState.attack; // enter attacking state
        yield return null; // wait one frame
        animator.SetBool("attacking", false); // set attacking back to false
        yield return new WaitForSeconds(.33f); // wait for 0.33 sec
        currentState = PlayerState.walk; // change state back to walk
    }

    void UpdateAnimationAndMove() // walk routine
    {
        if (change != Vector3.zero) // if change is not zero
        {
            MoveCharacter(); // go to move character
            animator.SetFloat("moveX", change.x); // set moveX as x in change
            animator.SetFloat("moveY", change.y); // set moveY as y in change
            animator.SetBool("moving", true); // set moveing true 
        }
        else
        {
            animator.SetBool("moving", false); // when change is zero set moving false
        }
    }

    void MoveCharacter() //move character routine
    {
        change.Normalize(); // prevent diagonal speeding, normalize when more than 2 arrow keys are pressed
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        ); // move player position + change * speed * deltatime 
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime); // wait for knock time 
            myRigidbody.velocity = Vector2.zero; // turn velocity zero
            currentState = PlayerState.idle; // back to walk
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
