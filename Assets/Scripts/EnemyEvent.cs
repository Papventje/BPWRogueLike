using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour
{
    public GameObject[] enemies;

    public void EnemyEncounter(Transform currentRoom)
    {
        int spawnNumber = Random.Range(2, 8);
        int index = Random.Range(0, enemies.Length);

        Debug.Log("SpawnNumber: " + spawnNumber + "Index: " + index);

        for (int i = 0; i < spawnNumber; i++)
        {
            Instantiate(enemies[0], currentRoom.position + new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)), Quaternion.identity);
        }
    }
}
