using UnityEngine;
using UnityEngine.AI;

public class AttackStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NavMeshAgent agent = animator.GetComponentInParent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = true;
        }
        animator.SetBool("isPunching", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NavMeshAgent agent = animator.GetComponentInParent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = false;
        }
        animator.SetBool("isPunching", false);
    }
}
