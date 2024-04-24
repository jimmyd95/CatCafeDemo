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
    protected bool destinationReached = false;

    protected virtual void Start()
    {
        if (target == null)
        {
            randomizeTarget("Furniture");
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
            destinationReached = false;
            Debug.Log("Customer is moving to the target location.");
        }
        else if(agent.remainingDistance < 5f && state == CustomerState.WALK)
        {
            agent.isStopped = true;
            state = CustomerState.IDLE;
            destinationReached = true;
            Debug.Log("Customer has reached the target location.");
        }
    }

    protected virtual void randomizeTarget(string tag)
    {
        var gameObjectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        target = gameObjectsWithTag[Random.Range(0, gameObjectsWithTag.Length)].transform;
    }

    public bool getDestinationReached()
    {
        return destinationReached;
    }

}
