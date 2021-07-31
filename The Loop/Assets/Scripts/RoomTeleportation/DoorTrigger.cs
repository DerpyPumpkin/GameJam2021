using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private GameObject player;
    public GameObject door;
    private Animator doorAnimator;

    //Room Disabeling Start
    public bool disableRooms;
    public GameObject[] roomList;
    private int listLengt;
    private float doorTime = 0f;
    public float doorCloseTime = 2.3f;
    private bool startTimer = false;
    //Room Disabeling End

    public EnemyScript[] roomEnemies;
    private int enemyCount;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        doorAnimator = door.GetComponent<Animator>();

        listLengt = roomList.Length;
        enemyCount = roomEnemies.Length;
    }


    void Update()
    {
        if (startTimer)
        {
            doorTime += Time.deltaTime;
            if(doorTime == doorCloseTime)
            {
                DisabelRooms();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            doorAnimator.Play("CloseDoor");
            startTimer = true;
            AggroEnemies();
        }

    }

    void DisabelRooms()
    {
        doorTime = 0;

        if (disableRooms)
        {
            for (int i = 0; i < listLengt; i++)
            {
                Debug.Log(i);
                roomList[i].SetActive(false);
            }
        }
        

    }

    void AggroEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            roomEnemies[i].isAggro = true;
        }
    }
}
