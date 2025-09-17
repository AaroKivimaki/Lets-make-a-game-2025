using System.Collections.Generic;
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
    int randNum, randNum2;
    public Vector3 rayCastOffSet;

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinationAmount);
        currentDestination = destinations[randNum];
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;

        if (Physics.Raycast(transform.position + rayCastOffSet, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                CaughtPlayer();
            }
        }
        if (chasing == true)
        {
            ChasePlayer();
        }

        if (walking == true)
        {
            if (currentDestination != null)
            {
                dest = currentDestination.position;
            }
            else
            {
                Debug.LogError("MonsterAI: currentDestination is not assigned!");
            }
            ai.destination = dest;
            ai.speed = walkSpeed;
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                randNum2 = Random.Range(0, 2);
                if(randNum2 == 0)
                {
                    randNum = Random.Range(0, destinationAmount);
                    currentDestination = destinations[randNum];
                }
                if (randNum2 == 1)
                {
                    //aiAnim.ResetTrigger("walk");
                    //aiAnim.SetTrigger("idle");
                    ai.speed = 0;
                    //StopCoroutine("stayIdle");
                    //StartCoroutine("stayIdle");
                    walking = false;
                }
            }
        }
    }
        void CaughtPlayer()
        {
                walking = false;
                //StopCoroutine("stayIdle");
                //StopCoroutine("chaseRoutine");
                //StartCoroutine("chaseRoutine");
                //aiAnim.ResetTrigger("walk");
                //aiAnim.ResetTrigger("idle");
                //aiAnim.SetTrigger("sprint");
                chasing = true;
        }

        void ChasePlayer()
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            if (ai.remainingDistance <= catchDistance)
            {
                //player.gameObject.SetActive(false);
                //aiAnim.ResetTrigger("sprint");
                //StartCoroutine(deathRoutine());
                chasing = false;
            }
        }
    //IEnumerator stayIdle()
    //{
    //    idleTime = Random.Range(minIdleTime, maxIdleTime);
    //    yield return new WaitForSeconds(idleTime);
    //    walking = true;
    //    randNum = Random.Range(0, destinationAmount);
    //    currentDestination = destinations[randNum];
    //}
    //IEnumerator chaseRoutine()
    //{
    //    chaseTime = Random.Range(minChaseTime, maxChaseTime);
    //    yield return new WaitForSeconds(chaseTime);
    //    walking = true;
    //    chasing = false;
    //    randNum = Random.Range(0, destinationAmount);
    //    currentDestination = destinations[randNum];
    //    aiAnim.ResetTrigger("sprint");
    //    aiAnim.SetTrigger("walk");
    //}
    //IEnumerator deathRoutine()
    //{

    //}
}
