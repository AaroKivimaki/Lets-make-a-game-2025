using UnityEngine;
using UnityEngine.AI;

public class DyingStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NavMeshAgent agent = animator.GetComponentInParent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = true;
            agent.speed = 0;
        }
        animator.SetBool("isDying", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NavMeshAgent agent = animator.GetComponentInParent<NavMeshAgent>();
        GameObject gameObject = GameObject.Find("Vihollinen");
        if (agent != null)
        {
            gameObject.SetActive(false);
        }

        WinnerScreen gameEndController = Object.FindFirstObjectByType<WinnerScreen>();

        if (gameEndController != null)
        {
            gameEndController.ActivateWinScreen();
        }

        animator.SetBool("isDying", false);
    }

}
