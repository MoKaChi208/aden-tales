using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.AI;
using System;

public class PlayerMovementHandler : MonoBehaviour
{
    private const float SPEED = 5f;

    public PlayerMain playerMain { get; private set; }

    [SerializeField]
    private Animator anim;

    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private Vector3 target;

    private NavMeshAgent agent;

    private void Awake()
    {
        playerMain = GetComponent<PlayerMain>();
        agent = GetComponent<NavMeshAgent>();
        anim.SetFloat("LastMoveX", 1); //Idle
        anim.SetFloat("LastMoveY", 1);
        lastMoveDir = Vector3.right;
        agent.enabled = false;
    }
    void Start()
    {
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }
    private void Update()
    {
        ProcessInput(); Animate();
        //Debug.Log("Move"+GetLastMoveDir());
        //Debug.Log("Attack Dir" + GetLastAttackDir());

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (agent.enabled == false) { 
        //    agent.enabled = true; }
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Debug.Log("target"+target);
        //    target.z = transform.position.z;
        //    agent.SetDestination(target);
        //}
        //if (agent.enabled == true)
        //{
        //    Debug.Log("agent" + agent.transform.position);
        //    Debug.Log("Distance" + agent.remainingDistance);
        //    if (Math.Abs((agent.transform.position - target).sqrMagnitude) <= 1f)
        //    {
        //        agent.ResetPath();
        //        agent.enabled = false;
        //    }
        //    else
        //    {
        //        AnimationWithPathFinding();
        //    }
        //}

    }
    private void FixedUpdate()
    {

        Move();
    }
    void Animate()
    {
        anim.SetFloat("MoveX", moveDir.x);//Walk
        anim.SetFloat("MoveY", moveDir.y);
        anim.SetFloat("MoveMagnitude", moveDir.magnitude);


        anim.SetFloat("LastMoveX", lastMoveDir.x); //Idle
        anim.SetFloat("LastMoveY", lastMoveDir.y);

    }
    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && moveDir.x != 0 || moveDir.y != 0)
        {
            lastMoveDir = moveDir;
        }
        moveDir = new Vector2(moveX, moveY).normalized;
    }//Input Move
    void Move()
    {
        playerMain.PlayerRigidbody2D.velocity = moveDir * SPEED;
    }//Move

    private void AnimationWithPathFinding()
    {
       // Debug.Log("target" + target);
       // Debug.Log("position" + agent.transform.position);
        anim.SetFloat("MoveX", agent.velocity.x);//Walk
        anim.SetFloat("MoveY", agent.velocity.y);
        anim.SetFloat("MoveMagnitude", agent.velocity.magnitude);

    }
    //private Vector3 mousePosition;
    //private Vector3 attack;

    //void MouseFight()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        mousePosition = UtilsClass.GetMouseWorldPosition();
    //        attack = mousePosition - transform.position;

    //        Debug.Log("Attack Vector"+attack);
    //        //Debug.Log(attack.y);


    //    }

    //}
    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
        playerMain.PlayerRigidbody2D.velocity = Vector3.zero;
    }

    public Vector3 GetLastMoveDir()
    {
        return lastMoveDir;
    }
    public Vector3 GetMoveDir()
    {
        return moveDir;
    }
    //public Vector3 GetLastAttackDir()
    //{
    //    return attack;
    //}
}
