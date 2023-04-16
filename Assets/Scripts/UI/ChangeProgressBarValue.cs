using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProgressBarValue : MonoBehaviour
{
    public Image progressBar;
    public TextMeshProUGUI text;
    public int caloriesNeeded;
    private int currentCalories;

    private void Start()
    {
        currentCalories = 0;
        progressBar.fillAmount = 0;
        text.text = "0%";
    }

    public void AddCalories(int calories)
    {
        float percentage;

        currentCalories += calories;
        percentage = (float)currentCalories / (float)caloriesNeeded;
        progressBar.fillAmount = percentage;
        text.text = $"{Mathf.RoundToInt(percentage * 100f)}%";
    }
}
