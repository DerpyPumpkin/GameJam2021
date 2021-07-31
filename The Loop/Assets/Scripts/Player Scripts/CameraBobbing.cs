using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;
    public PlayerMovement controller;
    public bool CameraBobOn = true;

    float defaultPosY = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        var doOnce = true;
        if (Input.GetKeyUp("c"))
        {
            if (CameraBobOn && doOnce)
            {
                doOnce = false;
                CameraBobOn = false;    
            }
            if (!CameraBobOn && doOnce)
            {
                doOnce = false;
                CameraBobOn = true;    
            }
        }
        if (Mathf.Abs(controller.moveDirection.x) > 0.1f || Mathf.Abs(controller.moveDirection.z) > 0.1f)
        {
            if (CameraBobOn)
            {
                //Player is moving
                timer += Time.deltaTime * walkingBobbingSpeed;
                transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
            }
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}
