
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    [SerializeField] GameObject target;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target == null || agent == null)
        {
            return;
        }

        if (agent.isOnNavMesh)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}