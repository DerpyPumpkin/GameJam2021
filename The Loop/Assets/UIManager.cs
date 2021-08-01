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
    [SerializeField] List<GameObject> healthIconsGO;
    void Awake()
    {
        DamageOverlay = this.GetComponent<Animation>();
        player = FindObjectOfType<PlayerAbilities>();
    }

    // Update is called once per frame
    public void TakeDamage()
    {
       /* for (int i = 3; i > _currentHealth; i--)
        {
            Debug.Log("health is: " + i);
            if(healthIconsGO[i].activeInHierarchy)
            healthIconsGO[i-1].SetActive(false);
        }*/
        //DamageOverlay.Play("DamageOverlayAnim");
    }
    public void WinScreen()
    {
        winScreenGO.SetActive(true);    
    }
}
