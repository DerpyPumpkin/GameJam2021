using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int maxHealth;
    int currentHealth;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float firerate;
    float firerateTimmer = 0f;
    

    [Header("Enemy AI")]
    [SerializeField] bool isShootie;
    [SerializeField] bool isChasie;
    [SerializeField] float searchDistance;
    [SerializeField] float attackDistance;

    [Header("Other")]
    [SerializeField] GameObject bullet;
    public CameraShake cameraShake;
    [SerializeField] ParticleSystem bloodEffect;

    public bool isAggro = false;
    public bool reset = false;
    Vector3 startPos;
    Vector3 startRot;

    PlayerAbilities player;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        startRot = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);

        player = FindObjectOfType<PlayerAbilities>();
        cameraShake = FindObjectOfType<CameraShake>();
        currentHealth = maxHealth;

        movementSpeed *= Random.Range(0.85f, 1.05f);
        firerate *= Random.Range(0.95f, 1.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) Die(false);

        if (reset)
        {
            reset = false;
            Reset();
        }

        if (Vector3.Distance(transform.position, player.transform.position) < searchDistance || currentHealth < maxHealth)
        {
            isAggro = true;
        }
        if (isAggro)
        {
            if (isChasie)
            {
                transform.LookAt(player.transform.position);
                transform.Translate(0, 0, movementSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
                {
                    Attack();
                }
            }
            if (isShootie)
            {
                transform.LookAt(player.transform.position);
                firerateTimmer = Mathf.Clamp(firerateTimmer - Time.deltaTime, 0, 1000);
                if (firerateTimmer == 0)
                {
                    firerateTimmer = firerate;
                    GameObject bulletObject = Instantiate(bullet);
                    bulletObject.transform.position = transform.position + transform.forward;
                    bulletObject.transform.forward = transform.forward;
                }
            }
        }
    }
    public void TakeDamage()
    {
        currentHealth--;
        bloodEffect.Play();
    }
    void Attack()
    {
        player.TakeDamage();
        Die(true);
    }
    public void Reset()
    {
        firerateTimmer = 0f;
        currentHealth = maxHealth;
        transform.localPosition = startPos;
        transform.localEulerAngles = startRot;
        isAggro = false;
        gameObject.SetActive(true);
    }
    void Die(bool _cameFromAttack)
    {
        if(!_cameFromAttack) 
        {
            player.GainHealth();
        }
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage();
            Destroy(other);
            FindObjectOfType<AudioManager>().Play("Enemy Hit");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, searchDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
