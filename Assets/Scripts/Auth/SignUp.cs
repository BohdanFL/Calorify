using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PanelChanger;

public class SignUp : MonoBehaviour
{
    private User user = new User();

    // Поля вводу даних
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField heightInput;
    public TMP_InputField weightInput;

    public void GetUserDataFromPanel()
    {
        switch (currentAuthPanelIndex)
        {
            case 1:
                try
                {
                    if (emailInput.text.Length == 0 || passwordInput.text.Length == 0)
                    {
                        throw new Exception("Not all fields are filled");
                    }

                    user.SetEmail(emailInput.text);
                    user.SetPassword(passwordInput.text);
                } catch (Exception e)
                {
                    throw e;
                }

                // sign up panel
                break;
            case 4:
                // name panel
                try
                {
                    if (usernameInput.text.Length == 0)
                    {
                        throw new Exception("Username field empty!");
                    }
                    user.SetUsername(usernameInput.text);
                }
                catch (Exception e)
                {
                    throw e;
                }
                break;
            case 5:
                // height panel
                try
                {
                    if (!string.IsNullOrEmpty(heightInput.text))
                    {
                        user.SetHeight(Convert.ToInt16(heightInput.text));
                    }
                    else {
                        throw new Exception("String is null or empty");
                    };
                }
                catch (Exception e)
                {
                    throw e;
                }
                break;
            case 6:
                // weight panel
                try
                {
                    if (!string.IsNullOrEmpty(weightInput.text))
                    {
                        user.SetWeight(Convert.ToInt16(weightInput.text));
                    }
                    else
                    {
                        throw new Exception("String is null or empty");
                    };
                }
                catch (Exception e)
                {
                    throw e;
                }
                break;
            case 7:
                usernameInput.text = "";
                emailInput.text = "";
                passwordInput.text = "";
                weightInput.text = "";
                heightInput.text = "";

                Debug.Log("Username: " + user.GetUsername());
                Debug.Log("Email: " + user.GetEmail());
                Debug.Log("Password: " + user.GetPassword());
                Debug.Log("Weight: " + user.GetWeight());
                Debug.Log("Height: " + user.GetHeight());
                Debug.Log("Goal: " + user.GetGoal());
                Debug.Log("Activity: " + user.GetActivity());
                break;
        }
    }

    // дропнути сеттери signup і використовувати user setters ???
    public void SetGoal(short option)
    {
        user.SetGoal(option);
    }

    public void SetActivity(short option)
    {
        user.SetGoal(option);
    }
}

// Todo: 
// Виводити помилки у інтерфейс