using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Camera camera;
    public GameObject bullet;
    public float firerate = 0.75f;
    private float firerateTimmer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
