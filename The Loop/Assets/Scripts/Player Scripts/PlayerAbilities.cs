using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Camera camera;
    public GameObject bullet;

    public float firerate = 0.75f;
    private float firerateTimmer = 0f;
    public int hp = 100;
    private int maxHp;

    public GameObject staff;
    public float staffForwardTime;
    public float staffInitialDrawBackTime;
    public float staffDrawBackTime;
    private float countDown;
    private float staffStacks = 0;
    public float staffInitialDrawBackSpeed = 5f;
    public float staffForwardSpeed = 5f;
    public float staffDrawBackSpeed = 5f;
    private int staffState = 0;
    private float staffY;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        firerateTimmer = Mathf.Clamp(firerateTimmer - Time.deltaTime, 0, 1000);
        if (Input.GetMouseButton(0) && firerateTimmer == 0)
        {
            firerateTimmer = firerate;
            GameObject bulletObject = Instantiate(bullet);
            bulletObject.transform.position = camera.transform.position + camera.transform.forward;
            bulletObject.transform.forward = camera.transform.forward;
            staffState = 1;
            staffStacks = 0;
            countDown = staffInitialDrawBackTime;
        }
        countDown = Mathf.Clamp(countDown - Time.deltaTime, 0, 1000);
        float actualStaffSpeed = 0;
        if (staffState > 0)
        {     
            if (staffState == 1)
            {
                actualStaffSpeed = -staffInitialDrawBackSpeed;
                if (countDown <= 0) { countDown = staffForwardTime; staffState++; }
            }
            if (staffState == 2)
            {
                actualStaffSpeed = staffForwardSpeed;
                if (countDown <= 0) { countDown = staffDrawBackTime; staffState++; }
            }
            if (staffState == 3)
            {
                actualStaffSpeed = -staffDrawBackSpeed;
                if (countDown <= 0) {staffState = 0; }
            }
            staff.transform.position += staff.transform.up * actualStaffSpeed * Time.deltaTime;
        }
    }
}
