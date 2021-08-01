using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    Transform target;
    Vector3 initialPos;
    float strength = 1f;


    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        initialPos = target.localPosition;
        Random.seed = System.DateTime.Now.Millisecond;
    }

    float pendingDuration = 0f;
    public void Shake(float duration)
    {
        if (duration > 0)
        {
            pendingDuration += duration;
        }
    }

    bool isShaking = false;

    void Update()
    {
        if (pendingDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }
    IEnumerator DoShake()
    {
        isShaking = true;

        var startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + pendingDuration)
        {
            var randomPoint = new Vector3(Random.Range(-strength, strength), Random.Range(-strength, strength), initialPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }

        pendingDuration = 0f;
        target.localPosition = initialPos;
        isShaking = false;
    }
}
