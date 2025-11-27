using UnityEngine;

public class ActivateGun : MonoBehaviour
{
    public float pickUpRange;
    public bool equipped;
    public static bool slotFull;
    public GameObject shotgun;
    

    public Transform player;
    void Start()
    {
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            shotgun.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
