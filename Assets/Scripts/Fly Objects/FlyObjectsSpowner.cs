using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObjectsSpowner : MonoBehaviour
{
    
    [SerializeField] private GameObject flyPrefab;
    [SerializeField] private Transform spawnPoint;
    private bool objectExists;
    [SerializeField] private float spawnRandomFactor;

    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION");
        Destroy(collision.gameObject);
        objectExists = !objectExists;
    }

    private void FixedUpdate()
    {
        if (objectExists) return;
        if (Random.Range(0,2) < spawnRandomFactor)
        {
            GameObject fly = Instantiate(flyPrefab, spawnPoint.position, transform.rotation);
            objectExists = !objectExists;
        }
    }
}
