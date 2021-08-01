using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float range = 2f;
    private float rangeTimmer = 0;
    private bool destroyOnHit = true;


    // Start is called before the first frame update
    void Start()
    {
        rangeTimmer = range;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        rangeTimmer -= Time.deltaTime;
        if (rangeTimmer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
