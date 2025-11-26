using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;

    void Start()
    {
        
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
