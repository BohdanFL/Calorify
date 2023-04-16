using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelChanger : MonoBehaviour
{
    public GameObject[] panels;

    public void LoadPanelByIndex(int index)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if(index != i)
            {
                panels[i].SetActive(false);
            } else
            {
                panels[i].SetActive(true);
            }
        }
    }
}
