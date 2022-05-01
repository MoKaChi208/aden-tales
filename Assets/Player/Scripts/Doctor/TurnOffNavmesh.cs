using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurnOffNavmesh : MonoBehaviour
{
    private PlayerMovementHandler PlayerMovementHandler;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update

    void OnEnable()
    {
        SetActive();
        
    }
    void SetActive()
    {
        PlayerMovementHandler = GetComponent<PlayerMovementHandler>();

        if (GetComponent<NavMeshAgent>() != null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }

    void TurnOffNavMeshAgent()
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false;
        }
    }
}
