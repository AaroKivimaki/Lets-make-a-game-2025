using UnityEngine;
using TMPro;
public class InteraktioController : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    TextMeshProUGUI interactionText;

    [SerializeField]
    float interactionDistance = 5f;

    interactable CurrentTarget;

    public void Update()
    {
        UpdateCurrent();
        UpdateText();
        InputCheck();
    }

    void UpdateCurrent()
    {
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        Physics.Raycast(ray, out var hit, interactionDistance);

        CurrentTarget = hit.collider?.GetComponent<interactable>();
    }

    void UpdateText()
    {
        if (CurrentTarget == null)
        {
            interactionText.text = string.Empty;
            return;
        }

        interactionText.text = CurrentTarget.Message;
    }

    void InputCheck()
    {
        if(Input.GetKeyDown(KeyCode.E) && CurrentTarget != null)
        {
            CurrentTarget.Interact();
        }
    }
}
