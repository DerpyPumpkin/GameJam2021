using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float searchDistance;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < searchDistance)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(0,0,movementSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position, searchDistance);
    }
}
