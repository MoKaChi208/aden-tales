using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public Player Player { get; private set; }
    public Rigidbody2D PlayerRigidbody2D { get; private set; }

    public PlayerMovementHandler PlayerMovementHandler { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Player = GetComponent<Player>();
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerMovementHandler = GetComponent<PlayerMovementHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
