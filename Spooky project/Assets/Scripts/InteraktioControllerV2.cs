using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteraktioControllerV2 : MonoBehaviour
{
    [Header("Raycast asetukset")]
    [SerializeField] private float interactionDistance = 5f;
    [SerializeField] private KeyCode interactionKey;

    private Camera playerCamera;
    private ItemScript item;

    void Start()
    {
        playerCamera = GetComponent<Camera>();
    }

    void Update()
    {
        PerformRaycast();
        InteractionInput();
    }

    void PerformRaycast()
    {
        if(Physics.Raycast(playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, interactionDistance))
        {
            var _item = hit.collider.GetComponent<ItemScript>();
            if(_item != null)
            {
                item = _item;

            }
            else
            {
                ClearItem();
            }
        }
        else
        {
            ClearItem();
        }
    }

    void InteractionInput()
    {
        if (Input.GetKeyDown(interactionKey))
        {
              item.ObjectInteraction();
        }
    }

    void ClearItem()
    {
        if (item != null)
        {
            item = null;
        }
    }
}
