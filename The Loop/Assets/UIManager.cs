using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerAbilities player;
    List<GameObject> hearts;
    Animation DamageOverlay;
    void Awake()
    {
        DamageOverlay = this.GetComponent<Animation>();
        player = FindObjectOfType<PlayerAbilities>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage()
    {
        DamageOverlay.Play("DamageOverlayAnim");
    }
}
