using UnityEngine;

public class Item : MonoBehaviour
{

    // Do item specific responses
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f,1f,0f,0.8f);
            Debug.Log("Item touched");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            Debug.Log("Item left alone");
        }
    }
}
