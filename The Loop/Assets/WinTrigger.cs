using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") Debug.Log("Big Win, najs!");
        FindObjectOfType<UIManager>().WinScreen();
    }
}
