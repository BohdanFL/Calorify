﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignUp : MonoBehaviour
{

    // Дані користувача
    private string username;
    private string email;
    private string password;
    private string repeatPassword;

    // Поля вводу даних
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField repeatPasswordInput;


    public void Init()
    {
        try
        {
            username = usernameInput.text;
            email = emailInput.text;
            password = passwordInput.text;
            repeatPassword = repeatPasswordInput.text;

            // Валідація даних
            DataValidate();

            usernameInput.text = "";
            emailInput.text = "";
            passwordInput.text = "";
            repeatPasswordInput.text = "";

            Debug.Log("Successfully!");
            SceneManager.LoadScene("MainScreen");
        }
        catch (Exception e) {
            Debug.Log(e);
        }

    }
    public void DataValidate()
    {
        if (username.Length == 0 || email.Length == 0 || password.Length == 0 || repeatPassword.Length == 0)
        {
            throw new Exception("Not all fields are filled");
        }
        else if (!email.Contains("@gmail.com") || !(email.Length > 10))
        {
            throw new Exception("Incorrect email");
        }
        else if (password != repeatPassword)
        {
            throw new Exception("Passwords don't match");
        }
        else if (!(password.Length > 6))
        {
            throw new Exception("Password must be longer than 6 characters");
        }
    }
}