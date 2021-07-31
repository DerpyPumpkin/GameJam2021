using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool enable = true;

    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10f;

    [SerializeField] private Transform thisCamera = null;
    [SerializeField] private Transform cameraHolder = null;

    private float toggleSpeed = 3.0f;
    private Vector3 startPos;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        startPos = thisCamera.localPosition;
    }
    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude * 2;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2; 
        return pos;
    }
    private void PlayMotion(Vector3 motion)
    {
        thisCamera.localPosition += motion * Time.deltaTime;
    }
    private void CheckMotion()
    {
        float speed = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        if (!controller.isGrounded) return;

        PlayMotion(FootStepMotion());
    }
    private void ResetPosition()
    {
        if (thisCamera.localPosition == startPos) return;
        thisCamera.localPosition = Vector3.Lerp(thisCamera.localPosition, startPos, 1 * Time.deltaTime);
    }
    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15.0f;
        return pos;
    }
    void Update()
    {
        if (!enable) return;

        CheckMotion();
        ResetPosition();
        thisCamera.LookAt(FocusTarget());
    }
}

