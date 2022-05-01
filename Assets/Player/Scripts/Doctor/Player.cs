using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private enum State
    {
        Normal,
    }

    private PlayerMain playerMain;
    //private State state;

    private void Awake()
    {
        Instance = this;
        playerMain = GetComponent<PlayerMain>();
        //state = State.Normal;

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

    public GameObject GetGameObject()
    {
        return gameObject;
    }
    //Pickup
    //Dodged
    //KnockBack
    //Damage
    //Health

}//class
