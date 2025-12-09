using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 2f;
    public GameObject deathScreenUI;
    public Volume targetVolume;
    private Vignette vignette;
    public DeathScreen deathScreenController;
    
    public float damageVignetteIntensity = 0.6f;
    private bool isDead = false;


    void Start()
    {
        if (targetVolume != null && targetVolume.profile.TryGet(out Vignette vg))
        {
            vignette = vg;
        }

        if (vignette != null)
        {
            vignette.intensity.value = 0f;
        }
    }

    public void TakeDamge(int damage)
    {
        Health -= damage;

        
        if(vignette != null)
        {
            vignette.intensity.value = damageVignetteIntensity;
        }
        if (Health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;

        if (deathScreenController != null)
        {
            deathScreenController.ActivateDeathScreen();
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
