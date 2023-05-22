using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPopUpInfo : MonoBehaviour
{
    public TextMeshProUGUI index;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI calories;
    public TextMeshProUGUI prots;
    public TextMeshProUGUI carbs;
    public TextMeshProUGUI fats;

    public TMP_InputField inputMass;

    int calculatedCals, calculatedProts, calculatedFats, calculatedCarbs, mass;

    private void FixedUpdate()
    {
        if (index.text.Length > 0)
        {
            Item item = FoodStatic.GetItem(Int32.Parse(index.text));

            if (inputMass.text.Length == 0) mass = 100;
            else mass = Int32.Parse(inputMass.text);

            calculatedCals = (int)(item.Calories * (mass / 100));
            calculatedProts = (int)(item.Prots * (mass / 100));
            calculatedFats = (int)(item.Fats * (mass / 100));
            calculatedCarbs = (int)(item.Carbs * (mass / 100));

            itemName.text = item.Name;
            calories.text = $"{calculatedCals.ToString()}";
            prots.text = $"{calculatedProts.ToString()}";
            carbs.text = $"{calculatedCarbs.ToString()}";
            fats.text = $"{calculatedFats.ToString()}";

        }
    }

    public void AddToRatio()
    {
        ChangeProgressBarValue progressBar = new ChangeProgressBarValue();
        progressBar.AddProductData(calculatedCals, calculatedCarbs, calculatedFats, calculatedProts);
    }
}
