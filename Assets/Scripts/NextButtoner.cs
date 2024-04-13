using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class NextButtoner : MonoBehaviour
{
    
    public ButtonAnimation[] buttonAnimations;
    public DragGerms[] dragGerms;
    public FoodBurst[] foodBursts;




    public GameObject[] panels; // To assign panels in the inspector
    private int currentPanelIndex = 0;
    public GameObject nextButton;
    


    void Start()
    {
        // Initially, activate the first panel and deactivate the rest
        ShowPanelAtIndex(currentPanelIndex);

    }

    public void ShowNextPanel()
    {
        

        if (currentPanelIndex < panels.Length - 1)
        {
            currentPanelIndex++;
            ShowPanelAtIndex(currentPanelIndex);
        }

        else
        {
            // You've reached the end of the panels array
            // can handle the end logic, e.g., disable the next button or trigger a game over state
            Debug.Log("The end of the panels");
            // Disable the next button, end the game, or other actions
        }
    }


    private void ShowPanelAtIndex(int index)
    {
        // Loop through all panels and activate the one at the current index
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i] != null) // Check if the panel reference is not null
            {
                panels[i].SetActive(i == index); // Activate the current panel and deactivate others
            }
            if (index == 2) //  panel number 3 has index 2
            {

                nextButton.SetActive(false);
                foreach (var buttonAnimation in buttonAnimations)
                {
                    if (buttonAnimation != null) // Check if the buttonAnimation reference is not null
                    {
                        buttonAnimation.PlayAnimationAndDisappear();
                    }
                                                          
                }
                

            }

            if (index == 5) //  panel number 3 has index 2
            {
     
                nextButton.SetActive(false);
               

            }


            if (index == 6) //  panel number 3 has index 2
            {

                nextButton.SetActive(false);
                foreach (var foodBurst in foodBursts)
                {
                    if (foodBurst != null) // Check if the item reference is not null
                    {
                        foodBurst.FoodClick();
                        Debug.Log("food is click");
                    }

                }


            }


        }

       
    }

    public bool AreAllButtonsInactive()
    {
        foreach (var buttonAnimation in buttonAnimations)
        {   
            if (buttonAnimation != null && buttonAnimation.gameObject.activeSelf)
            {
                // If any button is still active, return false immediately
                return false;
            }
        }

        // If this line is reached, all buttons are inactive
        return true;
    }

    public bool checkForClick()
    {
        foreach (var buttonAnimation in buttonAnimations)
        {
            if (buttonAnimation != null && buttonAnimation.gameObject.activeSelf)
            {
                // If any button is still active, return false immediately
                return false;
            }
        }

        // If this line is reached, all buttons are inactive
        return true;
    }

    public bool AreAllGermsInactive()
    {
        foreach (var dragGerm in dragGerms)
        {
            if (dragGerm != null && dragGerm.gameObject.activeSelf)
            {
                // If any button is still active, return false immediately
                return false;
            }
        }

        // If this line is reached, all buttons are inactive
        return true;
    }
}
