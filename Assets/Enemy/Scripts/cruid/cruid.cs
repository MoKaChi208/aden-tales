using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cruid : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform homePosition;
    public float chaseRaidus;
    public float attackRadius;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        //anim
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position,
                            transform.position) <= chaseRaidus
            && Vector3.Distance(target.position,
                            transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp =
                            Vector3.MoveTowards(transform.position,
                               target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
    }
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
