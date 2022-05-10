using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameAllWeapon {
    //Gun
    PISTOL,
    MP5,
    ICE,
    AK,
    BOW,
    //Melee
    PUNCH,
    SWORD,
    FISH
}
public enum check {}
public class WeaponController : MonoBehaviour
{
    //[SerializeField]
    public DefaultConfig defaultConfig;
    public NameAllWeapon nameAllWeapon;

    protected float lastShot;

    public int gunIndex;
    public int currentBullet;
    public int bulletMax;

    void Awake()
    {
        currentBullet = bulletMax;
    }

    public void CallAttackGun()
    {

        if (Time.time > lastShot + defaultConfig.fireRate)
        {
            if (currentBullet > 0)
            {
                ProcessAttack();

                //animate player shoot 
                //...


                lastShot = Time.time;
                currentBullet--;
            }
            else
            {
                //Player No Amo sound
            }
        }
        CallIdle();

    }//call attack
    public void CallAttackMelee()
    {
        if (Time.time > lastShot + defaultConfig.fireRate)
        {
            if (currentBullet > 0)
            {
                ProcessAttack();

                //animate player shoot 
                //...

                lastShot = Time.time;
            }
            else
            {
                //Player No Amo sound
            }
        }
        CallIdle();

    }//call attack
    public void CallAttack() {
        switch (nameAllWeapon)
        {
            case NameAllWeapon.PUNCH:
            case NameAllWeapon.SWORD:
            case NameAllWeapon.FISH:
                CallAttackMelee();
                break;
            case NameAllWeapon.PISTOL:
            case NameAllWeapon.MP5:
            case NameAllWeapon.ICE:
            case NameAllWeapon.AK:
            case NameAllWeapon.BOW:
                CallAttackGun();
                break;
        } // switch and case
    }


    public void CallIdle()
    {
        ProcessIdle();
    }
    public virtual void ProcessIdle() { }
    public virtual void ProcessAttack() { }
}
