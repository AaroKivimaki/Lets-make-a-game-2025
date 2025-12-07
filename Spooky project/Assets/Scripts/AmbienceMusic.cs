using UnityEngine;

public class AmbienceMusic : MonoBehaviour
{
    private MonsterAI monsterScript;
    public AudioSource audioSource;
    public AudioClip[] clip;

    public bool trackMusic = false;
    void Start()
    {
        
    }

    private void Awake()
    {
        GameObject game = GameObject.Find("Vihollinen");
        monsterScript = game.GetComponent<MonsterAI>();
    }

    void Update()
    {
        if (trackMusic == false && monsterScript.chasing == false && audioSource.isPlaying == false)
        {
            ambience();
        }
        if (trackMusic == true && monsterScript.chasing == true)
        {
            audioSource.Stop();
        }
    }

    public void ambience()
    {
        int random = Random.Range(0, clip.Length);
        var music = clip[random];
        audioSource.PlayOneShot(music);
    }
}
