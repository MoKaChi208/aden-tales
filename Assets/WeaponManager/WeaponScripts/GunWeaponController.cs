using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem fx_Shot;
    public GameObject fx_BulletFall;

    private Collider2D fireCollider;

    private WaitForSeconds wait_Time = new WaitForSeconds(0.02f);
    private WaitForSeconds fire_CollierWait = new WaitForSeconds(0.02f);

    // Start is called before the first frame update
    void Start()
    {
        //create bullets
    }

    public override void ProcessAttack()
    {
        //base.ProcessAttack();

        switch (nameAllWeapon)
        {

            case NameAllWeapon.PISTOL:
                break;

            case NameAllWeapon.MP5:
                break;

            case NameAllWeapon.ICE:
                break;

            case NameAllWeapon.AK:
                break;

            case NameAllWeapon.BOW:
                break;

        } // switch and case

        //Spawn Bullet

    }//process attack

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

}//class
