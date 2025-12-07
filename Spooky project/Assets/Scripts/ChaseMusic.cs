using UnityEngine;
using System.Collections;

public class ChaseMusic : MonoBehaviour
{
    private MonsterAI parentScript;
    private AmbienceMusic ambienceMusic;
    public AudioSource audioSource;
    public AudioClip chase;

    private bool track = false;
    void Start()
    {
    }

    void Awake()
    {
        parentScript = transform.parent.GetComponent<MonsterAI>();
        GameObject game = GameObject.Find("musicBox");
        ambienceMusic = game.GetComponent<AmbienceMusic>();

    }

    void Update()
    {
        if (parentScript.chasing && track == false)
        {
            ambienceMusic.trackMusic = true;
            audioSource.PlayOneShot(chase);
            track = true;
        }
        if (parentScript.chasing == false && track == true)
        {
            StartCoroutine(FadeOut(audioSource, 1f));
            track = false;
            ambienceMusic.trackMusic = false;
        }
        
    }
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
