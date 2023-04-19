using System;
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

    // Кнопки авторизації
    public Button loginButton;
    public Button signupButton;

    // Поля вводу даних
    public InputField usernameInput;
    public InputField emailInput;
    public InputField passwordInput;
    public InputField repeatPasswordInput;


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
