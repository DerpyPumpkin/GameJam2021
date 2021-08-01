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

    //public EnemyScript[] roomEnemies;
    private int enemyCount;
    public RoomManagerScript roomManager;
    public bool aggroEnemies = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        doorAnimator = door.GetComponent<Animator>();

        listLengt = roomList.Length;
        //enemyCount = roomEnemies.Length;
    }


    void Update()
    {
        
        if (startTimer)
        {
            //Debug.Log("startTimer" + doorTime);
            doorTime += Time.deltaTime;
            if(doorTime >= doorCloseTime)
            {
                Debug.Log("Close Door");
                DisabelRooms();

            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            doorAnimator.Play("DoorClose");
            startTimer = true;
            if (aggroEnemies)
            {
                roomManager.AggroEnemies();
            }
            
        }

    }

    void DisabelRooms()
    {
        doorTime = 0;
        Debug.Log("RunDisable");
        if (disableRooms)
        {
            Debug.Log("If Disable");
            for (int i = 0; i < listLengt; i++)
            {
                Debug.Log(i);
                roomList[i].SetActive(false);
                Debug.Log("Disable done");
            }
        }
        

    }

    /*void AggroEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            roomEnemies[i].isAggro = true;
        }
    }*/
}
