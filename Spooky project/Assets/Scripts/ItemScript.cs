using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Avain,
        Ovi,
    }

    [Header("Tyyppi")]
    [SerializeField] private ItemType itemType = ItemType.None;

    private OviS ovet;
    private AvainS avaimet;

    private void Awake()
    {
        switch (itemType)
        {
            case ItemType.Ovi: ovet = GetComponent<OviS>(); break;
            case ItemType.Avain: avaimet = GetComponent<AvainS>(); break;
        }
    }

    public void ObjectInteraction()
    {
        switch (itemType)
        {
            case ItemType.Ovi: ovet?.ToggleDoor(); break;
            case ItemType.Avain: avaimet?.KeyPickup(); break;
        }
    }
}
