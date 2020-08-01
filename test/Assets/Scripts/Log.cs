using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy // embedded enemy script 
{
    private Rigidbody2D myRigidbody;
    public Transform target; // as player
    public float chaseRadius; // log will chase player
    public float attackRadius; // log will sttack player
    public Transform homePosition; // log position
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform; // find its target as player
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() // only moving on the physical calls
    {
        CheckDistance();
    }

    void CheckDistance()
    {   // if distance is larger than attack radius and smaller than chase radius
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {

            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                // transform position moves to target positon
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                changeAnim(temp - transform.position);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }   
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    //changing states 
    private void ChangeState(EnemyState newState) // pass the value enemystate, the value is called newstate
    {
        if(currentState != newState)
        {
            currentState = newState;

        }
    }
}
