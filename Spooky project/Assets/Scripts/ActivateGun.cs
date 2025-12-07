using UnityEngine;

public class ActivateGun : MonoBehaviour
{
    public float pickUpRange;
    public bool equipped;
    public static bool slotFull;
    public GameObject shotgun;
    private AmbienceMusic ambienceMusic;
    public AudioClip music;
    

    public Transform player;
    void Start()
    {
    }

    void Awake()
    {
        GameObject game = GameObject.Find("musicBox");
        ambienceMusic = game.GetComponent<AmbienceMusic>();
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            shotgun.SetActive(true);
            gameObject.SetActive(false);
            ambienceMusic.audioSource.Stop();
            ambienceMusic.audioSource.PlayOneShot(music);
        }

    }
}
