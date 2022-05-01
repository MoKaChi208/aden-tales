using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private Animator anim;

    private Vector2 moveDirection;
    private Vector2 lastMoveDiretion;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        Animate();

        if (attackTimeCounter > 0)
            attackTimeCounter -= Time.deltaTime;

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("isAttack", false);

        }

        MouseFight();
    }
    private void FixedUpdate()
    {
        if (attacking == false)
        {
            Move();
        }
    }
    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDiretion = moveDirection;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
    }//Input Move
    void Move()
    {
        rigid.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }//Move

    void Animate()
    {
        anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);
        anim.SetFloat("MoveMagnitude", moveDirection.magnitude);


        anim.SetFloat("LastMoveX", lastMoveDiretion.x);
        anim.SetFloat("LastMoveY", lastMoveDiretion.y);

    }


    //MosePosition
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    private Vector3 mousePosition;
    private Vector3 attack;


    public bool attacking = false;
    private float attackTimeCounter;
    public float attackingTime;
    public Animator effect;
    public bool isAttack = false;

    void MouseFight()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            //effect.SetBool("isEffect", true);
            Debug.Log("EffecOn");
            rigid.velocity = Vector3.zero;
            mousePosition = GetMouseWorldPosition();
            attack = mousePosition - transform.position;

            Debug.Log(attack.x);
            Debug.Log(attack.y);
            anim.SetFloat("AttackX", attack.x);
            anim.SetFloat("AttackY", attack.y);
            lastMoveDiretion.x = attack.x;
            lastMoveDiretion.y = attack.y;

            attackTimeCounter = attackingTime;

            anim.SetBool("isAttack", true);
            //effect.SetFloat("AnimEffectX", lastMoveDiretion.x);
            //effect.SetFloat("AnimEffectY", lastMoveDiretion.y);

        }

    }

    //==========================
    //Speech Bubble
    private bool interacting;
    public void ToggleInteraction()
    {
        interacting = !interacting;
    }
}
