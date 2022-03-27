using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public GameObject player;
    private GameObject distraction;
    public NavMeshAgent agent;
    public ParticleSystem particles;
    public float detectionrange;

    private bool idle = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            if(Vector3.Distance(player.transform.position, transform.position) < detectionrange)
            {
                startAttack();
            }
        }
        else if(distraction != null)
        {
            followDistraction();
            if (Vector3.Distance(distraction.transform.position, transform.position) < 2.0f)
            {
                endAttack();
            }
        }
        else
        {
            attackPlayer();
        }
        
    }

    private void startAttack()
    {
        particles.Play();
        idle = false;
        player.GetComponent<PlayerStats>().changeMorale(-10);
        player.GetComponent<PlayerStats>().stressTrigger();
    }

    private void endAttack()
    {
        particles.Stop();
        agent.isStopped = true;
    }

    public void distract(GameObject d)
    {
        distraction = d;
    }

    private void attackPlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void followDistraction()
    {
        agent.SetDestination(distraction.transform.position);
    }
}
