using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
  

    public class FoodBurst : MonoBehaviour
    {
        public NextButtoner nextButtoner;

        public Button foodButton;
        public List<Sprite> foodImages; // to Assign list in the editor
        public Image glowImage; // to assign the image with the "Glow" tag
        private int currentIndex = 0;


        public void FoodClick()
        {   
            foodButton.onClick.AddListener(ChangeImage); // Add a click listener to the button
             Debug.Log("lis to click");
           glowImage.canvasRenderer.SetAlpha(0.0f);
        }

        private void ChangeImage()
        {
            Debug.Log("Method working");
            if (currentIndex < foodImages.Count)
            {
                Debug.Log("change image working");
              // Change the image on the button
               foodButton.image.sprite = foodImages[currentIndex];
               currentIndex++;
            }
            else
            {
            // Last image has been reached, start Glow image fade in and out
            StartCoroutine(FadeGlowImage());
            currentIndex = 0; // Reset the index if you want to cycle through images again
            }

        }


        IEnumerator FadeGlowImage()
        {
        // Fade in
        glowImage.CrossFadeAlpha(1.0f, 2.0f, false);
        yield return new WaitForSeconds(2.0f); // Wait for the fade in to finish

        // Fade out
        glowImage.CrossFadeAlpha(0.0f, 2.0f, false);
        }

    }
