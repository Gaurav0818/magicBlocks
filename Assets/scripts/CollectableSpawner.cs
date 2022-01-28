using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject[] collectable;
    public int num;
    public bool canSpawn = true;
    private void Update()
    {
        if (canSpawn)
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(1f, 4f);
            Vector2 pos = new Vector2(x, y);
            int spawnNumber = 0;
            int number = Random.Range(0, 9);
            num = number;
            if ( number <= 1)
            {
                spawnNumber = 1;
                print(number);
            }
            GameObject spawned = Instantiate(collectable[spawnNumber],transform);
            spawned.transform.position = pos;
            spawned.transform.parent = null;
            canSpawn = false;
        }
    }

}
