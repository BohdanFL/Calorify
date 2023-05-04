using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject panel;

    public void ChangeText(string newText)
    {
        panel.SetActive(true);
        text.text = newText;
    }

    public void ClearText()
    {
        panel.SetActive(false);
        text.text = "";
    }
}
