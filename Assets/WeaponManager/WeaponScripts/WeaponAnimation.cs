using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer spriteWeapon;
    [SerializeField]
    private SpriteRenderer player;

    public DefaultConfig defaultConfig;

    protected float lastShot;

    public bool attacking = false;
    private float attackTimeCounter;
    public float attackingTime;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteWeapon = GetComponent<SpriteRenderer>();
        player = GetComponent<SpriteRenderer>();
    }

    //public void WeaponIdleAnimation(Vector3 dir)
    //{
    //    anim.SetFloat("LastAttackX", dir.x);
    //    anim.SetFloat("LastAttackY", dir.y);
    //}
    public void WeaponAttackAnimation(Vector3 dir)
    {
        anim.SetBool("isAttack", true);
        float aX = 0, aY = 0;
        if (dir.x < 0) { aX = -1; }
        if (dir.x > 0) { aX = 1; }
        if (dir.x < 0) { aY = -1; }
        if (dir.y > 0) { aY = 1; }

        if (Math.Abs(dir.x) > Math.Abs(dir.y))
        {
            anim.SetFloat("attackX", aX);
            anim.SetFloat("attackY", 0);
        }
        if (Math.Abs(dir.x) < Math.Abs(dir.y))
        {
            anim.SetFloat("attackX", 0);
            anim.SetFloat("attackY", aY);
        }

        StartCoroutine(dura());

    }
    public void SetAnimation(bool trigger)
    {
        anim.SetBool("isAttack", trigger);
    }
    IEnumerator dura()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isAttack", false);
    }

    public void Animate(Vector3 moveDir, Vector3 lastMoveDir)
    {

        sortSpriteLayer(moveDir, lastMoveDir);
        if (moveDir.x != 0)
        {
            if (moveDir.x > 0)
            {
                anim.SetFloat("moveX", Vector3.right.x);//Walk
            }
            if (moveDir.x < 0)
            {
                anim.SetFloat("moveX", Vector3.left.x);//Walk
            }
            anim.SetFloat("moveY", Vector3.zero.x);
        }
        else
        {
            anim.SetFloat("moveX", moveDir.x);//Walk
            anim.SetFloat("moveY", moveDir.y);
            // sprite.sortingLayerName();
        }
        anim.SetFloat("MoveMagnitudeWeapon", moveDir.magnitude);


        anim.SetFloat("lastMoveX", lastMoveDir.x); //Idle
        anim.SetFloat("lastMoveY", lastMoveDir.y);

    }
    public void sortSpriteLayer(Vector3 moveDir, Vector3 lastMoveDir)
    {

        if (moveDir == Vector3.up || lastMoveDir == Vector3.up)
        {
            spriteWeapon.sortingOrder = player.sortingOrder + 1;
        }
        else
        {
            spriteWeapon.sortingOrder = 0;
        }

    }
    // Update is called once per frame
}
