using UnityEngine;
using UnityEngine.AI;

public class NavMeshCustomer : MonoBehaviour
{
    protected enum CustomerState
    {
        IDLE,
        WALK,
        REQUEST,
        CAT
    }

    [SerializeField] protected Transform target;
    // private Transform target;
    protected NavMeshAgent agent;
    protected CustomerState state;

    protected virtual void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Furniture").transform;
        }
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (agent.remainingDistance >= 5f)
        {
            // agent.SetDestination(target.position);
            state = CustomerState.WALK;
            // Debug.Log("Customer has stopped");
        }
        else if(agent.remainingDistance < 5f && state == CustomerState.WALK)
        {
            agent.isStopped = true;
            state = CustomerState.IDLE;
        }
    }

}
