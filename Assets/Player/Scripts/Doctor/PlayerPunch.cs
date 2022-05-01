using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerPunch : MonoBehaviour
{
    public static PlayerPunch instance;
    private const float SPEED = 50f;
    private State state;
    private enum State
    {
        Normal,
        Attacking,
    }
    private void Awake()
    {
        instance = this;
        SetStateNormal();
    }

    // Update is called once per frame
    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                //HandleMovement();
                HandleAttack();
                break;
            case State.Attacking:
                HandleAttack();
                break;
        }
    }
    private void SetStateNormal()
    {
        state = State.Normal;
        GetComponent<PlayerMovementHandler>().Enable();
    }
    private void SetStateAttacking()
    {
        state = State.Attacking;
        GetComponent<PlayerMovementHandler>().Disable();
    }
    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Attack
            SetStateAttacking();

            Vector3 attackDir = (UtilsClass.GetMouseWorldPosition() - GetPosition()).normalized;

            //EnemyHandler enemyHandler = EnemyHandler.GetClosestEnemy(GetPosition() + attackDir * 4f, 20f);
            //bool hitEnemy;
            //if (enemyHandler != null)
            //{
            //    //enemyHandler.Damage(this);
            //    hitEnemy = true;
            //    attackDir = (enemyHandler.GetPosition() - GetPosition()).normalized;
            //    transform.position = enemyHandler.GetPosition() + attackDir * -12f;
            //}
            //else
            //{
            //    hitEnemy = false;
            //    transform.position = transform.position + attackDir * 4f;
            //}

            float attackAngle = UtilsClass.GetAngleFromVectorFloat(attackDir);

            //// Play attack animation
            //if (playerBase.IsPlayingPunchAnimation())
            //{
            //    // Play Kick animation since punch animation is currently active

            //}
            //else
            //{
            //    // Play Punch animation
            //}

            SetStateNormal();
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
