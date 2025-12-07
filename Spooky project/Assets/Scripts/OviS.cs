using UnityEngine;

public class OviS : MonoBehaviour
{
    [Header("Asetukset")]
    [SerializeField] private Transform doorPivot; //saranat
    [SerializeField] private float openAngle = 90f; //kuinka paljon aukeaa
    [SerializeField] private float closeAngle = 0f; //miten on kiinni 0 = täysin enemmän kuin se niin raollaan
    [SerializeField] private float rotationSpeed = 2f; //kuinka nopeasti avautuu

    [Header("Lukko asetukset")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private AvainToiminto requiredKey;

    private bool isDoorOpen = false;
    private bool isAnimating = false;
    private Quaternion targetRotation;

    private void Start()
    {
        targetRotation = Quaternion.Euler(0f, closeAngle, 0f);
    }

    private void Update()
    {
        if (isAnimating)
        {
            doorPivot.localRotation = Quaternion.Lerp(doorPivot.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

            if(Quaternion.Angle(doorPivot.localRotation, targetRotation) < 0.1f)
            {
                doorPivot.localRotation = targetRotation;
                isAnimating = false;
            }
        }
    }

    public void ToggleDoor()
    {
        if (isLocked)
        {
            if (Inventory.Instance.OnAvain(requiredKey))
            {
                Debug.Log($"{gameObject.name} Aukesi oikealla avaimella {requiredKey.avainNimi}");
                isLocked = false;
            }
            else
            {
                return;
            }
        }

        if (!isAnimating)
        {
            isDoorOpen = !isDoorOpen;

            targetRotation = Quaternion.Euler(0f, isDoorOpen ? openAngle : closeAngle, 0f);

            isAnimating = true;
        }
    }
}
