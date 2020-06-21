﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] botRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom;

    [HideInInspector]
    public List<GameObject> rooms;

    public float waitTime;
    bool spawnedBoss;
    public GameObject boss;

    private void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
