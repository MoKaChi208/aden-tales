using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 startingPosition;
    private Vector3 roamPosition;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Body").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(roamPosition);

        float reachedPositionDistance = 1f;
        if(agent.remainingDistance < reachedPositionDistance)
        {
            StartCoroutine(placeNameCo());
        }

    }
    private void FindTarget()
    {
        float targetRange = 10f;
        
    }
    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(2f,4f);
    }
    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private IEnumerator placeNameCo()
    {
        agent.SetDestination(transform.position);
        yield return new WaitForSeconds(1f);
        roamPosition = GetRoamingPosition();

    }
}
