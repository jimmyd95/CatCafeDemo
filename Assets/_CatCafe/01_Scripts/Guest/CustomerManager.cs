using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private Spawn _spawn;
    private GameObject customer;

    private void Start() {
        customer = GameObject.FindWithTag("Customer");
    }

    private void Update() {
        // check if the customer left with the cat, if so, destroy that gameObject and spawn a new one
        if (!customer)
        {
            customer = GameObject.FindWithTag("Customer");
        }
        else if(customer.GetComponent<Customer>().hasLeft && customer.GetComponent<Customer>().getDestinationReached() && customer.GetComponent<Customer>().hasCat)
        {
            Destroy(customer);
            customer = _spawn.spawnNewObject("Customer");
        }
        // Debug.Log("Current customer status: " + customer + " - has left: " + customer.GetComponent<Customer>().hasLeft);
    }

}
