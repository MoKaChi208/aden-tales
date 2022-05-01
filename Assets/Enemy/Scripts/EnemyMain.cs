using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public Enemy Enemy { get; private set; }
    public Rigidbody2D EnemyRigidbody2D { get; private set; }
    private void Awake()
    {
        Enemy = GetComponent<Enemy>();
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
    }
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
