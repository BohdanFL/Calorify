using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advice : MonoBehaviour
{

    public void OpenURL(string url)
    {
        if (url.Contains("https://") || url.Contains("http://"))
        {
            Application.OpenURL(url);
            Debug.Log(url);
        }
    }
}
