using TMPro;
using UnityEngine;

public class M_PlayerInteract : MonoBehaviour
{
    public Transform InteractionSource;
    public float InteractionRange;
    public GameObject InteractionUI;
    public TextMeshProUGUI interactionText;
    private void Update()
    {
        InteractionRay();
        
    }

    void InteractionRay()
    {
        Ray ray = new Ray(InteractionSource.position, InteractionSource.forward);
        RaycastHit hit;
        bool hitSomething = false;
        if (Physics.Raycast(ray, out hit, InteractionRange))
        {
            hit.collider.gameObject.TryGetComponent(out IGetDescription interactObj);
            if (interactObj != null)
            {
                hitSomething = true;
                interactionText.text = interactObj.GetDescription();
            }
            hit.collider.gameObject.TryGetComponent(out M_IInteractable interactableObj);
            if (interactableObj != null)
            {
                hitSomething = true;
                interactableObj.Interact();
            }
            
            
        }
        InteractionUI.SetActive(hitSomething);
    }
}
