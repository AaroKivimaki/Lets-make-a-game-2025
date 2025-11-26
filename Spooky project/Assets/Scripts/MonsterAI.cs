using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public NavMeshSurface surface;
    public List<Transform> destinations;

    public Animator aiAnim;

    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime;
    public int destinationAmount;
    public bool walking, chasing;

    public Transform player;
    Transform currentDestination;
    Vector3 dest;

    int randNum;
    public Vector3 rayCastOffSet;

    [SerializeField] private int StartingHealth;
    public int health;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        ai.stoppingDistance = catchDistance;
        walking = true;
        randNum = Random.Range(0, destinationAmount);
        currentDestination = destinations[randNum];
        Health = StartingHealth;
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position);
        RaycastHit hit;

        //Löydä pelaaja
        if (Physics.Raycast(transform.position + rayCastOffSet, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                CaughtPlayer();
            }
        }
        if (aiAnim.GetBool("isPunching"))
        {
            return;
        }
        if (chasing == true)
        {
            ChasePlayer();
        }

        if (walking == true)
        {
            Walk();
        }
    }
    void CaughtPlayer()
    {
        walking = false;
        StopCoroutine("StayIdle");
        StopCoroutine("ChaseRoutine");
        StartCoroutine("ChaseRoutine");
        chasing = true;
    }

    void ChasePlayer()
    {
        dest = player.position;
        ai.destination = dest;
        ai.speed = chaseSpeed;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= catchDistance)
        {
                aiAnim.ResetTrigger("idle");
                aiAnim.ResetTrigger("walk");
                aiAnim.ResetTrigger("chase");
                aiAnim.SetTrigger("punch");
        }
        else
        {
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("chase");
        }
    }

    void Walk()
    {
        ai.isStopped = false;
        ai.stoppingDistance = 0;

        dest = currentDestination.position;
        ai.destination = dest;
        ai.speed = walkSpeed;
        aiAnim.ResetTrigger("chase");
        aiAnim.ResetTrigger("idle");
        aiAnim.SetTrigger("walk");

        if (ai.remainingDistance <= ai.stoppingDistance)
        {
            //Patrolli
            aiAnim.ResetTrigger("chase");
            aiAnim.ResetTrigger("walk");
            aiAnim.SetTrigger("idle");
            ai.speed = 0;
            StopCoroutine("StayIdle");
            StartCoroutine("StayIdle");
            walking = false;

            ai.stoppingDistance = catchDistance;
        }

    }
    IEnumerator StayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinationAmount);
        currentDestination = destinations[randNum];
    }
    IEnumerator ChaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinationAmount);
        currentDestination = destinations[randNum];
    }
}
