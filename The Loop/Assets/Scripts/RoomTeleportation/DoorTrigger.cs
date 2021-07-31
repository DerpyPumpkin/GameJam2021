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

    //Room Disabeling End

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        doorAnimator = door.GetComponent<Animator>();

        listLengt = roomList.Length;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player)
        {
            doorAnimator.Play("CloseDoor");
            Debug.Log("Ping");
        }

        if(disableRooms)
        {
            for(int i = 0; i < listLengt; i++)
            {
                Debug.Log(i);
                roomList[i].SetActive(false);
            }
        }
    }
}
