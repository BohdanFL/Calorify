using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advice : MonoBehaviour
{
    //public string url;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenURL(string url)
    {
        if (url.Contains("https://") || url.Contains("http://"))
        {
            Application.OpenURL(url);
            Debug.Log(url);
        }
    }
}
