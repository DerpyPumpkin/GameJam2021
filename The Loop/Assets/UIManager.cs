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
    public void TakeDamage(int _currentHealth)
    {
        for (int i = 3; i > _currentHealth; i--)
        {
            if(healthIconsGO[i-1].activeInHierarchy)
            healthIconsGO[i-1].SetActive(false);
        }
        DamageOverlay.Play("DamageOverlayAnim");
    }
    public void GainHealth(int _currentHealth)
    {
        for (int i = 0; i < _currentHealth; i++)
        {
            Debug.Log(i);
            if(!healthIconsGO[i].activeInHierarchy)
            healthIconsGO[i].SetActive(true);
        }
    }
    public void WinScreen()
    {
        winScreenGO.SetActive(true);    
    }
}
