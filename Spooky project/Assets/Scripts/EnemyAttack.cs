using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float attackDistance = 1.5f; 
    public float attackRadius = 0.5f;
    public int damageAmount = 1;

    public void Attack()
    {
        Vector3 attackPoint = transform.position + transform.forward * attackDistance;

        Collider[] hitColliders = Physics.OverlapSphere(attackPoint, attackRadius);

        foreach (var hitCollider in hitColliders)
        {
            // TÄRKEÄ MUUTOS: Etsi komponentti vanhemmista
            // Koska PlayerHealth on juuressa (vanhemmassa) ja Collider lapsessa.
            PlayerHealth playerHealth = hitCollider.GetComponentInParent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamge(damageAmount);
                Debug.Log("Osuma rekisteröity ja vahinko annettu juuriobjektiin!");
                return; // Osuu vain kerran yhtä iskua kohden
            }
        }
        
        Debug.Log("Isku ohi!");
    }
}