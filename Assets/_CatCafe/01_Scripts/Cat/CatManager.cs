using UnityEngine;

public class CatManager : Cat
{
    [SerializeField] private Spawn _spawn;

    private void Update() {
        if (GameObject.FindGameObjectsWithTag("Cat").Length < 3)
        {
            Debug.Log("No cats in the scene");
            _spawn.spawnNewObject("Cat", Quaternion.Euler(45,0,0));
        }
    }
}