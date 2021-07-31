using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    [SerializeField] int maxHealth;
    int currentHealth;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float searchDistance;
    [SerializeField] float attackDistance;
    [SerializeField] bool isAggro = false;
    PlayerAbilities player;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerAbilities>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < searchDistance || currentHealth < maxHealth || isAggro)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(0,0,movementSpeed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, player.transform.position) < attackDistance )
        {
            Attack();
        }
    }
    public void TakeDamage()
    {
        currentHealth--;
        if(currentHealth <= 0) Die();
    }
    void Attack()
    {
        player.hp--;
        Debug.Log("Player health is currently: " + player.hp);
        Die(); //make this poolable later on.
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet") TakeDamage();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position, searchDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, attackDistance);
    }
}
