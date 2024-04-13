using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ButtonAnimation : MonoBehaviour 
{   public NextButtoner nextButtoner;
    private Animator animator;
    private Button button;

    public FadeOutGameObject fadeOutGameObject;




    public void PlayAnimationAndDisappear()
    {
        // Get the Animator attached to this GameObject.
        animator = GetComponent<Animator>();
        
        // Get the Button component attached to this GameObject.
        button = GetComponent<Button>();
        // Register the OnClick event.

        

        button.onClick.AddListener(PlayAnimation);
        
    }

    // Method to play animation and handle the rest of the process
    private void PlayAnimation()
    {
        
        
        // Play the "Bubble (1)" animation.
        animator.Play("Bubble (1)");

        // Optionally wait for the animation to finish before disabling the button.
        // This could be done with a Coroutine that waits for the animation length.
        StartCoroutine(DisableAfterAnimation());


    }

    IEnumerator DisableAfterAnimation()
    {
        // Wait for the length of the animation.
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Deactivate the button's GameObject.
        gameObject.SetActive(false);

        fadeOutGameObject.StartFadeOut();
        // Check if all buttons are now inactive.
        if (nextButtoner.AreAllButtonsInactive())
        {
            // All buttons are inactive, so activate the nextButton.
            nextButtoner.nextButton.SetActive(true);
        }

        

    }


}