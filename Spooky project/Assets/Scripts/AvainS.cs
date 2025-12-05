using UnityEngine;

public class AvainS : MonoBehaviour
{
    [SerializeField] private AvainToiminto avain;
    public void KeyPickup()
    {
        if(avain != null)
        {
            Inventory.Instance.LisaaAvain(avain);

            gameObject.SetActive(false);
        }
    }
}
