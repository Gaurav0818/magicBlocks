using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Range(1,5)]
    public int increaseValue;
    CollectableSpawner spawner;
    GameFlowController controller;
    // Update is called once per frame
    void Update()
    {
        spawner = FindObjectOfType<CollectableSpawner>();
        controller = FindObjectOfType<GameFlowController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawner.canSpawn = true;
            controller.IncreseEnemySpeed();
            controller.IncreaseScore(increaseValue);
            Destroy(gameObject);
        }    
    }
}
