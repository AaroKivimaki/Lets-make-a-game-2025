using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float attackDistance = 3f; 
    public float attackRadius = 1.5f;
    public int damageAmount = 1;

    public void Attack()
    {
        Vector3 attackPoint = transform.position + transform.forward * attackDistance;

        Collider[] hitColliders = Physics.OverlapSphere(attackPoint, attackRadius);

        foreach (var hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponentInParent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamge(damageAmount);
                return;
            }
        }
    }
}