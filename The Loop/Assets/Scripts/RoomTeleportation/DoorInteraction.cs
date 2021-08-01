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
    public RoomManagerScript roomManager;
    //Reset Rooms End

    public DoorTrigger[] doorTriggerList;
    private int doorlength;

    //Variables and Objects End

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        doorAnimator = door.GetComponent<Animator>();
        doorlength = doorTriggerList.Length;
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
                    roomManager.ResetRooms();
                    for(int i = 0; i < doorlength; i++)
                    {
                        doorTriggerList[i].startTimer = false;
                        doorTriggerList[i].doorTime = 0f;
                    }

                }


                doorAnimator.Play("DoorOpen");

                //triggerBlock.SetActive(false);//Deactivate TriggerBlock
            }
        }
    }








}
