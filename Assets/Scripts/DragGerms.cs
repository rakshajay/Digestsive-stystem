using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragGerms : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    
    public NextButtoner nextButtoner;
    public FadeOutGameObject fadeOutGameObject;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Collider2D stomachCollider;
    private Animator animator;
    
    public string animationName; // The name of the animation to play

   
   




    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>(); // assign germ as a child of the canvas for the UI interaction
        stomachCollider = GameObject.FindGameObjectWithTag("Stomach").GetComponent<Collider2D>(); // Assuming the collider has a Collider2D component
        animator = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // can add some initial interaction logic here if needed
    }


    public void OnDrag(PointerEventData eventData)
    {
        
        { rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Stomach") // Check for collision with the 'Stomach' tag
        {
            PlayAnimationAndFadeOut();
        }
    }

    private void PlayAnimationAndFadeOut()
    {
        if (!string.IsNullOrEmpty(animationName))
        {
            animator.Play(animationName); // Play the specified animation
            Debug.Log("Played animation: " + animationName);
            StartCoroutine(DisableAfterAnimation());
        }
        else
        {
            Debug.LogWarning("Animation name is not set for " + gameObject.name);
        }
    }

    IEnumerator DisableAfterAnimation()
    {
        // Wait for the length of the animation.
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Deactivate the button's GameObject.
        gameObject.SetActive(false);

        
        fadeOutGameObject.StartFadeOut();

        if (nextButtoner.AreAllGermsInactive())
        {
            // All buttons are inactive, so activate the nextButton.
            nextButtoner.nextButton.SetActive(true);
        }

    }

}