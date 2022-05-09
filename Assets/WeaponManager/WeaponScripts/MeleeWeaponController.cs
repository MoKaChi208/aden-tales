using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : WeaponController
{
    private Collider2D fireCollider;

    private WaitForSeconds wait_Time = new WaitForSeconds(0.02f);
    private WaitForSeconds fire_CollierWait = new WaitForSeconds(0.02f);

    private PlayerMovementHandler playerMove;
    private WeaponAnimation anim;
    private PlayerShoot playerShoot;

    // Start is called before the first frame update
    private void Awake()
    {
        playerShoot = GetComponentInParent<PlayerShoot>();
        playerMove = GetComponentInParent<PlayerMovementHandler>();
        anim = GetComponent<WeaponAnimation>();
    }
    void Update()
    {
        //Debug.Log(playerMove.GetLastMoveDir());
        //anim.WeaponIdleAnimation(playerMove.GetLastMoveDir());
        //anim.Animate(playerMove.GetMoveDir(), playerMove.GetLastMoveDir());
    }

    public override void ProcessAttack()
    {
        //base.ProcessAttack();

        switch (nameAllWeapon)
        {
            case NameAllWeapon.PUNCH:
                
                break;

            case NameAllWeapon.SWORD:
                //Debug.Log("Melee"+ playerShoot.GetAttackDir());
                //anim.WeaponAttackAnimation(playerShoot.GetAttackDir(),playerShoot.GetBoolAttack());
                break;

            case NameAllWeapon.FISH:
                break;
        } // switch and case

        //Spawn Bullet

    }//process attack

    public override void ProcessIdle()
    {
        //base.ProcessAttack();

        switch (nameAllWeapon)
        {
            case NameAllWeapon.PUNCH:

                break;

            case NameAllWeapon.SWORD:
                
                anim.Animate(playerMove.GetMoveDir(), playerMove.GetLastMoveDir());

                break;

            case NameAllWeapon.FISH:
                break;
        } // switch and case

        //Spawn Bullet

    }

    IEnumerator WaitForShootEffect()
    {
        yield return wait_Time;
        //fx_Shot.Play;
    }

    IEnumerator ActiceFireCollider()
    {
        fireCollider.enabled = true;

        yield return fire_CollierWait;

        fireCollider.enabled = false;
    }
}
