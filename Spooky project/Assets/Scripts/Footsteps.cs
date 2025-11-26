using UnityEngine;

public class Footsteps : MonoBehaviour
{
    AudioSource audioSource;
    ParticleSystem footstepFx;
    public AudioClip[] footstepSounds;

    void Start()
    {
        
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        footstepFx = GetComponent<ParticleSystem>();
    }

    void Update()
    {
    }

    public void Footstep()
    {
        int random = Random.Range(0, footstepSounds.Length);
        var clip = footstepSounds[random];
        audioSource.PlayOneShot(clip);
    }
}
