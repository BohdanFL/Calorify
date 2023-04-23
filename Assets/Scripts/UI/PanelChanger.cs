using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelChanger : MonoBehaviour
{
    public GameObject[] mainPanels;
    public GameObject[] authPanels;
    static public int currentAuthPanelIndex = 0;

    public GameObject welcomePanel;
    public GameObject signupPanel;
    public GameObject loginPanel;

    public Button profileButton;
    public Button nextButton;
    public Button previousButton;

    public void LoadPanelByIndex(int index)
    {
        for(int i = 0; i < mainPanels.Length; i++)
        {
            if(index != i)
            {
                mainPanels[i].SetActive(false);
            } else
            {
                mainPanels[i].SetActive(true);
            }
        }
        if (index == 0)
        {
            profileButton.gameObject.SetActive(true);
        } else {
            profileButton.gameObject.SetActive(false);
        }
    }

    public void ToAuthPanel(GameObject authPanel)
    {
        welcomePanel.SetActive(false);
        authPanel.SetActive(true);
        previousButton.gameObject.SetActive(true);

        if (authPanel == signupPanel)
        {
            nextButton.gameObject.SetActive(true);
        }

        currentAuthPanelIndex++;
    }

    public void SwapAuthPanel()
    {
        loginPanel.SetActive(!loginPanel.activeSelf);
        signupPanel.SetActive(!signupPanel.activeSelf);

        if (signupPanel.activeSelf)
        {
            nextButton.gameObject.SetActive(true);
        }
        else if (loginPanel.activeSelf)
        {
            nextButton.gameObject.SetActive(false);
        }
    }

    public void ToNextPanel()
    {
        authPanels[currentAuthPanelIndex - 1].SetActive(false);
        currentAuthPanelIndex++;
        if (currentAuthPanelIndex == authPanels.Length)
        {
            nextButton.gameObject.SetActive(false);
            SceneManager.LoadScene("MainScreen");
            return;
        }
        authPanels[currentAuthPanelIndex].SetActive(true);
    }

    public void ToPreviousPanel()
    {
        authPanels[currentAuthPanelIndex].SetActive(false);

        if (loginPanel.activeSelf && currentAuthPanelIndex == 1)
            loginPanel.SetActive(false);

        currentAuthPanelIndex--;
        authPanels[currentAuthPanelIndex].SetActive(true);

        if (currentAuthPanelIndex == 0)
        {
            nextButton.gameObject.SetActive(false);
            previousButton.gameObject.SetActive(false);
        }
    }
}
