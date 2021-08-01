using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Camera camera;
    public GameObject bullet;
    public CameraShake cameraShake;
    private bool screenShakeOn = true;

    [Header("Stats")]
    public float firerate = 0.75f;
    private float firerateTimmer = 0f;
    public int hp = 100;
    [HideInInspector]
    public int maxHp;

    [Header("Visual & Effects")]
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
    public float shootScreenShakeStrength;
    public float shootScreenShakeDuration;
    public float damagedScreenShakeStrength;
    public float damagedScreenShakeDuration;
    UIManager uIManager;
    // Start is called before the first frame update
    void Awake()
    {
        maxHp = hp;
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var doOnce = true;
        if (Input.GetKeyUp("c"))
        {
            if (screenShakeOn && doOnce)
            {
                doOnce = false;
                screenShakeOn = false;
            }
            if (!screenShakeOn && doOnce)
            {
                doOnce = false;
                screenShakeOn = true;
            }
        }

        firerateTimmer = Mathf.Clamp(firerateTimmer - Time.deltaTime, 0, 1000);
        if (Input.GetMouseButton(0) && firerateTimmer <= 0)
        {
            firerateTimmer = firerate;
            GameObject bulletObject = Instantiate(bullet);
            bulletObject.transform.position = camera.transform.position + camera.transform.forward;
            bulletObject.transform.forward = camera.transform.forward;
            staffState = 1;
            staffStacks = 0;
            countDown = staffInitialDrawBackTime;
            //Audio Visual
            FindObjectOfType<AudioManager>().Play("Player Shoot");
            if (screenShakeOn) { StartCoroutine(cameraShake.Shake(shootScreenShakeDuration, shootScreenShakeStrength)); }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            TakeDamage();
            Destroy(other);
            FindObjectOfType<AudioManager>().Play("Player Hit");
        }
    }

    public void TakeDamage()
    {
        uIManager.TakeDamage();
        hp--;
        if (screenShakeOn){StartCoroutine(cameraShake.Shake(damagedScreenShakeDuration, damagedScreenShakeStrength));}
    }
}
