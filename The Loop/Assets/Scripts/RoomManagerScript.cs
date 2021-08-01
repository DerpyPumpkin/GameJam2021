using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagerScript : MonoBehaviour
{
    public EnemyScript[] roomEnemies;
    private int enemyCount;
    public GameObject[] doorInteractions;
    private int doorcount;



    // Start is called before the first frame update
    void Start()
    {
        enemyCount = roomEnemies.Length;
        doorcount = doorInteractions.Length;
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if (roomEnemies[i].isActiveAndEnabled)
            {
                for (int t = 0; t < doorcount; t++)
                {
                    doorInteractions[t].SetActive(false);
                }
            }
            else {
                for (int t = 0; t < doorcount; t++)
                {
                    doorInteractions[t].SetActive(true);
                }
            }
        }
        
    }

    public void ResetRooms()
    {
        Debug.Log("Start Resetign enemies");
        for (int i = 0; i < enemyCount; i++)
        {
            roomEnemies[i].gameObject.SetActive(true);
            roomEnemies[i].Reset();
            Debug.Log("Reset Enemy " + i);
        }
    }

    public void AggroEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            roomEnemies[i].isAggro = true;
        }
    }
}
