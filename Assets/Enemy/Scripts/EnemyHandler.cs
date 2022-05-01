using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public interface IEnemyTargetable
    {
        Vector3 GetPosition();
        void Damage(EnemyHandler attacker);
    }
    public static List<EnemyHandler> enemyHandlerList = new List<EnemyHandler>();

    public static EnemyHandler GetClosestEnemy(Vector3 position, float maxRange)
    {
        EnemyHandler closest = null;
        foreach (EnemyHandler enemyHandler in enemyHandlerList)
        {
            if (enemyHandler.IsDead()) continue;
            if (Vector3.Distance(position, enemyHandler.GetPosition()) <= maxRange)
            {
                if (closest == null)
                {
                    closest = enemyHandler;
                }
                else
                {
                    if (Vector3.Distance(position, enemyHandler.GetPosition()) < Vector3.Distance(position, closest.GetPosition()))
                    {
                        closest = enemyHandler;
                    }
                }
            }
        }
        return closest;
    }

    private const float speed = 30f;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    private int health;
    private float pathfindingTimer;
    private Func<IEnemyTargetable> getEnemyTarget;

    private State state;
    private enum State
    {
        Normal,
        Busy
    }
    private void Awake()
    {
        enemyHandlerList.Add(this);
        health = 40;
        state = State.Normal;
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform playerTransform = transform.Find("Player");
        playerTransform.GetComponent<Player>();
    }

    public void SetGetTarget(Func<IEnemyTargetable> getEnemyTarget)
    {
        this.getEnemyTarget = getEnemyTarget;
    }
    // Update is called once per frame
    void Update()
    {
        pathfindingTimer -= Time.deltaTime;

        switch (state)
        {
            case State.Normal:
                HandleMovement();
                FindTarget();
                break;
            case State.Busy:
                break;
        }
    }

    private void FindTarget()
    {
        float targetRange = 100f;
        float attackRange = 15f;
        if (getEnemyTarget != null)
        {
            if (Vector3.Distance(getEnemyTarget().GetPosition(), GetPosition()) < attackRange)
            {
                StopMoving();
                state = State.Busy;
                //Attack + Animation 

                // Attack complete
                state = State.Normal;
            }
            else
            {
                if (Vector3.Distance(getEnemyTarget().GetPosition(), GetPosition()) < targetRange)
                {
                    if (pathfindingTimer <= 0f)
                    {
                        pathfindingTimer = .3f;
                        //SetTargetPosition(getEnemyTarget().GetPosition());
                    }
                }
            }
        }
    }
    public bool IsDead()
    {
        return health <= 0;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    //public void Damage(IEnemyTargetable attacker)
    //{
    //    Vector3 bloodDir = (GetPosition() - attacker.GetPosition()).normalized;
    //    //Blood_Handler.SpawnBlood(GetPosition(), bloodDir);
    //    health--;
    //    if (IsDead())
    //    {
    //        //Animation dead
    //        //FlyingBody.Create(GameAssets.i.pfEnemyFlyingBody, GetPosition(), bloodDir);
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        // Knockback
    //        transform.position += bloodDir * 5f;
    //        //if (hitUnitAnim != null)
    //        //{
    //        //    state = State.Busy;
    //        //    unitAnimation.PlayAnimForced(hitUnitAnim, bloodDir * (Vector2.one * -1f), 1f, (UnitAnim unitAnim) => {
    //        //        state = State.Normal;
    //        //    }, null, null);
    //        //}
    //    }
    //}
    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                //animatedWalker.SetMoveVector(moveDir);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                    //animatedWalker.SetMoveVector(Vector3.zero);
                }
            }
        }
        else
        {
            //animatedWalker.SetMoveVector(Vector3.zero);
        }
    }
    private void StopMoving()
    {
        //pathVectorList = null;
    }
}
