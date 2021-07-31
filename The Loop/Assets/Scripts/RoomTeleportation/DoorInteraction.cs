using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    //Variables and Objects Start
    //playerStart
    GameObject player;
    public GameObject interactDisplay;
    //playerEnd

    public GameObject triggerBlock;//ThisObject

    public bool teleportRooms = true;

    //Door Animations Start
    public GameObject door;
    private Animator doorAnimator;
    //Door Animations End

    //Ancorpoint Start
    public GameObject corridorAnchorpoint;
    public GameObject nextRoomAnchorpoint;
    //Ancorpoint End

    //Reset Rooms Start
    public EnemyScript[] nextRoomEnemies;
    private int enemyCount;

    //Reset Rooms End


    //Variables and Objects End

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        doorAnimator = door.GetComponent<Animator>();
        enemyCount = nextRoomEnemies.Length;
    }

    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player)
        {
            interactDisplay.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject == player)
        {
            interactDisplay.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider collision)
    { 
        if(collision.gameObject == player)
        {
            Debug.Log("In trigger");
            if (Input.GetAxisRaw("Interact")> 0)//Interect With Door
            {
                interactDisplay.SetActive(false);//Deactivate Interactionpromt

                if (teleportRooms)
                {
                    //MoveNextRoomStart
                    nextRoomAnchorpoint.SetActive(true);
                    nextRoomAnchorpoint.transform.position = corridorAnchorpoint.transform.position;
                    nextRoomAnchorpoint.transform.rotation = corridorAnchorpoint.transform.rotation;
                    //MOveNextRoomEnd
                    ResetRooms();

                }


                doorAnimator.Play("OpenDoor");

                triggerBlock.SetActive(false);//Deactivate TriggerBlock
            }
        }
    }

    void ResetRooms()
    {
        Debug.Log("Start Resetign enemies");
        for (int i = 0; i < enemyCount; i++)
        {
            nextRoomEnemies[i].gameObject.SetActive(true);
            nextRoomEnemies[i].Reset();
            Debug.Log("Reset Enemy " + i );
        }
    }







}
