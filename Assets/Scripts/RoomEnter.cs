using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform currentRoom = transform;
            GameObject.Find("RoomEvents").GetComponent<EnemyEvent>().EnemyEncounter(currentRoom);
            print("Entered Room");
            Destroy(gameObject);
        }
    }
}
