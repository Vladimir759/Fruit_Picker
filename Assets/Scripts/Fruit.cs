using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int scoreReward;
    void Update()
    {
        if(transform.position.y <= -20)
        {
            Destroy(gameObject);
            GameManager gameManager = Camera.main.GetComponent<GameManager>();
            gameManager.DestroyAllFruits();
        }
    }

    
}
