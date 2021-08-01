using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerAbilities player;
    List<GameObject> hearts;
    Animation DamageOverlay;
    [SerializeField] GameObject winScreenGO;
    void Awake()
    {
        DamageOverlay = this.GetComponent<Animation>();
        player = FindObjectOfType<PlayerAbilities>();
    }

    // Update is called once per frame
    void Start()
    {
        for(int i = 0; i < hearts.Count; i++)
        {
            //if(hearts[i].activeInHierarchy == true)
        }

    }
    public void TakeDamage()
    {
        DamageOverlay.Play("DamageOverlayAnim");
    }
    public void WinScreen()
    {
        winScreenGO.SetActive(true);    
    }
}
