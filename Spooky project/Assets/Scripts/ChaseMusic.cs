using JetBrains.Annotations;
using UnityEngine;

public class ChaseMusic : MonoBehaviour
{
    private MonsterAI parentScript;
    public AudioSource audioSource;
    public AudioClip chase;
    void Start()
    {
    }

    void Awake()
    {
       parentScript = transform.parent.GetComponent<MonsterAI>();
    }

    void Update()
    {
        if (parentScript.chasing)
        {
            audioSource.PlayOneShot(chase);
        } else
        {
            audioSource.Stop();
        }
        
    }
}
