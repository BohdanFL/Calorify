using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PanelChanger;

public class SignUp : MonoBehaviour
{

    // Дані користувача
    private string username;
    private string email;
    private string password;
    private int goal = 2;
    private int activity = 1;
    private short height;
    private short weight;


    //// Поля вводу даних
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField heightInput;
    public TMP_InputField weightInput;

    public void GetUserDataFromPanel()
    {

        username = usernameInput.text;
        email = emailInput.text;
        password = passwordInput.text;

        if (!string.IsNullOrEmpty(heightInput.text))
        {
            height = Convert.ToInt16(heightInput.text);
        }
        else height = 0;

        if (!string.IsNullOrEmpty(weightInput.text))
        {
            weight = Convert.ToInt16(weightInput.text);
        }
        else weight = 0;


        switch (currentAuthPanelIndex)
        {
            case 1:
                // sign up panel
                if (email.Length == 0 || password.Length == 0)
                {
                    throw new Exception("Not all fields are filled");
                }
                else if (!email.Contains("@gmail.com") || !(email.Length > 10))
                {
                    throw new Exception("Incorrect email");
                }
                else if (!(password.Length > 6))
                {
                    throw new Exception("Password must be longer than 6 characters");
                }

                break;
            case 4:
                // name panel
                if (username.Length == 0)
                {
                    throw new Exception("Username field empty!");
                }
                break;
            case 5:
                // height panel
                if (height <= 0)
                {
                    throw new Exception("Height must be greater than 0!");
                }
                break;
            case 6:
                // weight panel
                if (weight <= 0)
                {
                    throw new Exception("Weight must be greater than 0!");
                }
                break;
            case 7:
                Debug.Log("Username: " + username);
                Debug.Log("Email: " + email);
                Debug.Log("Password: " + password);
                Debug.Log("Weight: " + weight);
                Debug.Log("Height: " + height);
                Debug.Log("Goal: " + goal);
                Debug.Log("Activity: " + activity);


                break;
            default:
                    //throw new Exception("Panels don't exist");
                break;
        }
    }

    public void SetGoal(int option)
    {
        if (option >= 0 && option < 3)
        {
            goal = option;
        }
    }
    public void SetActivity(int option)
    {
        if (option >= 0 && option < 3)
        {
            activity = option;
        }
    }
}

// Tips: Перевіряти данні у сеттерах.