using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot instance;
    private WeaponManager weaponManager;
    private PlayerMovementHandler player;
    public bool canShoot { get; private set; }
    private bool isHoldAttack;
    private bool isAttack;

    private Vector3 attackDir;
    private Vector3 targetMouse;

    private State state;
    private enum State
    {
        Normal,
        Attacking,
    }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        player = GetComponent<PlayerMovementHandler>();
        weaponManager = GetComponent<WeaponManager>();
        canShoot = true;
        isAttack = false;
        SetStateNormal();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponManager.SwitchWeapon();
        }
        switch (state)
        {
            case State.Normal:
                //HandleMovement();
                HandleAttack();
                HandleClick();
                break;
            case State.Attacking:
                HandleAttack();
                HandleClick();
                break;
        }
        //Attack by key
        #region
        //if (Input.GetKey(KeyCode.L))
        //{
        //    isHoldAttack = true;
        //}
        //else
        //{
        //    weaponManager.ResetAttack();
        //    isHoldAttack = false;
        //}
        //if(isHoldAttack && canShoot)
        //{
        //    weaponManager.Attack();
        //}
        #endregion

    }
    private void HandleAttack()
    {
        //Attack by key
        #region
        //if (Input.GetKey(KeyCode.L))
        //{
        //    SetStateAttacking();
        //    weaponManager.Attack();
        //}
        //else
        //{
        //    weaponManager.ResetAttack();
        //    SetStateNormal();
        //}
        #endregion

        //if (Input.GetMouseButton(0))
        //{
        //    isAttack = true;
        //    SetStateAttacking();

        //    attackDir = (UtilsClass.GetMouseWorldPosition() - GetPosition()).normalized;

        //    weaponManager.Attack();
        //}
        //else
        //{
        //    isAttack = false;
        //    attackDir = Vector3.zero;
        //    weaponManager.ResetAttack();
        //    SetStateNormal();
        //    weaponManager.Attack();
        //}
        weaponManager.ResetAttack();
        SetStateNormal();

    }
    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetMouse = (UtilsClass.GetMouseWorldPosition()).normalized;

            //Debug.Log(targetMouse);
        }
        weaponManager.ResetAttack();
        SetStateNormal();
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
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public Vector3 GetAttackDir()
    {
        return attackDir;
    }
    public bool GetBoolAttack()
    {
        return isAttack;
    }
    private Vector3 SetAttackDir()
    {
        return Vector3.zero;
    }
}
