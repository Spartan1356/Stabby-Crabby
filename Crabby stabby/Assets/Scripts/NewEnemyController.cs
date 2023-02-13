using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyController : MonoBehaviour
{
    public float lookRadius = 180f;
    Transform target;
    NavMeshAgent agent;
    public int Damage;
    public int attackTimer;
    public int cooldown = 1000;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer--;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {

                if (attackTimer <= 0)
                {
                FindObjectOfType<Basehealth>().health -= Damage;
                    attackTimer = cooldown;
                }
                faceTarget();
            }
        }
    }
    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
    }
    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
