using UnityEngine;
using UnityEngine.EventSystems;

public class StomachAcid : MonoBehaviour, IDropHandler
{
    public Animator germAnimator; // Assign this in the inspector with your germ's Animator component

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            RectTransform germRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(
                this.GetComponent<RectTransform>(),
                eventData.position,
                eventData.pressEventCamera))
            {
                // Play the germ animation
                germAnimator.SetTrigger("PlayGermDeathAnimation");
            }
        }
    }
}
