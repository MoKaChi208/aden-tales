using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponController> weapons_Unlocked;
    [SerializeField]
    private WeaponController[] total_Weapons;

    [HideInInspector]
    public WeaponController current_Weapon;
    private int current_Weapon_Index;

    private TypeControlAttack current_Type_Control;


    private bool isShooting;

    private State state;
    private enum State
    {
        Normal,
        Attacking,
    }

    private void Awake()
    {

        LoadActiveWeapons();

        current_Weapon_Index = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeWeapon(weapons_Unlocked[1]);
    }

    void LoadActiveWeapons()
    {
        weapons_Unlocked.Add(total_Weapons[0]);
        for(int i = 1; i< total_Weapons.Length; i++)
        {
            weapons_Unlocked.Add(total_Weapons[i]);
        }
    }
    public void SwitchWeapon()
    {
        current_Weapon_Index++;

        current_Weapon_Index =
            (current_Weapon_Index >= weapons_Unlocked.Count) ? 0 : current_Weapon_Index;

        ChangeWeapon(weapons_Unlocked[current_Weapon_Index]);
    }

    void ChangeWeapon(WeaponController newWeapon)
    {
        if (current_Weapon)
        {
            current_Weapon.gameObject.SetActive(false);
        }
        current_Weapon = newWeapon;
        current_Type_Control = newWeapon.defaultConfig.typeControl;

        newWeapon.gameObject.SetActive(true);

    }

    public void Attack()
    {
        if(current_Type_Control == TypeControlAttack.Hold)
        {
            current_Weapon.CallAttack();
        }
        else
        {
            if(current_Type_Control == TypeControlAttack.Click)
            {
                if (!isShooting)
                {
                    current_Weapon.CallAttack();
                    isShooting = true;
                }
            }
        }
    }
    public void ResetAttack()
    {
        isShooting = false;
        current_Weapon.CallIdle();
    }

}//class
