using UnityEngine;
using UnityEngine.AI;

public class Pathing : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        agent.destination = target.position;
    }
}
