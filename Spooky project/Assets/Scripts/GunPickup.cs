using Unity.Mathematics;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider boxCollider;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;

    public bool equipped;
    public static bool slotFull;
    void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            boxCollider.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            boxCollider.isTrigger = true;
            slotFull = true;
        }
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        boxCollider.isTrigger = true;
    }

}
