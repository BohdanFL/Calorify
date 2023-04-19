using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    // Дані користувача
    private string email;
    private string password;

    // Кнопки авторизації
    public Button loginButton;
    public Button signupButton;

    // Поля вводу даних
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    // Панелі
    public GameObject signupPanel;
    public GameObject loginPanel;

    public void Init()
    {
        try
        {
            email = emailInput.text;
            password = passwordInput.text;
            Debug.Log(email + " " + password);

            // Валідація даних
            DataValidate();

            emailInput.text = "";
            passwordInput.text = "";

            Debug.Log("Successfully!");
            SceneManager.LoadScene("MainScreen");
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }


    public void DataValidate()
    {
        if (email.Length == 0 || password.Length == 0)
        {
            throw new Exception("Not all fields are filled");
        }
        else if (!email.Contains("@gmail.com") || !(email.Length > 10))
        {
            throw new Exception("Incorrect email");
        }
    }

    public void MoveToSignupPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
    }

    public void MoveToLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
    }
}
