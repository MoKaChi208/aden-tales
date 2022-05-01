using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public interface IEnemyTargetable
    {
        GameObject GetGameObject();
        Vector3 GetPosition();
        //void Damage(Enemy attacker, float damageMultiplier);
    }
    public static List<Enemy> enemyList = new List<Enemy>();

    public EnemyMain EnemyMain { get; private set; }

    private void Awake()
    {
        enemyList.Add(this);
        EnemyMain = GetComponent<EnemyMain>();

    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
