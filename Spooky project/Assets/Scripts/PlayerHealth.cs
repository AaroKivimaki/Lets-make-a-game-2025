using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 2f;

    public void TakeDamge(int damage)
    {
        Health -= damage;

        

        if (Health <= 0)
        {
            Debug.Log("Player died!!");
        }

    }
}
