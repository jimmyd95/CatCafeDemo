
using UnityEngine;

public class Customer : NavMeshCustomer
{
    public bool hasLeft = false;
    public bool hasCat = false;
    private bool playerLeft = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        // make the customer go back to the door if the cat has been delivered
        if (playerLeft && hasCat)
        {
            agent.isStopped = false;
            target = GameObject.FindWithTag("Door").transform;
            agent.SetDestination(target.position);
            // playerLeft = false;
            destinationReached = false;
            playerLeft = false;
        }
        else if (destinationReached && hasCat)
        {
            hasLeft = true;
            Debug.Log("Customer has left the cafe: " + hasLeft + " - " + destinationReached);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Cat"))
        {
            hasCat = true;
            destinationReached = false;
            // Debug.Log("Cat entered the customer");
        }
        if (other.CompareTag("Player"))
        {
            playerLeft = false;
            // Debug.Log("Player entered the customer");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerLeft = true;
            // Debug.Log("Player left the customer");
        }
    }

}
