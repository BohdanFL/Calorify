using System;
using TMPro;
using UnityEngine;
using static PanelChanger;

public class SignUp : MonoBehaviour
{
    // Поля вводу даних
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField heightInput;
    public TMP_InputField weightInput;
    public TMP_Text ErrorOutput;

    public void GetUserDataFromPanel()
    {
        switch (currentAuthPanelIndex)
        {
            case 1:
                // sign up panel
                try
                {
                    if (emailInput.text.Length == 0 || passwordInput.text.Length == 0)
                    {
                        throw new Exception("Not all fields are filled");
                    }

                    User.SetEmail(emailInput.text);
                    User.SetPassword(passwordInput.text);

                    if (ErrorOutput.text.Length != 0)
                    {
                        ErrorOutput.text = "";
                    }
                } catch (Exception e)
                {
                    ErrorOutput.text = e.Message;
                    throw e;
                }

                break;
            case 4:
                // name panel
                try
                {
                    if (usernameInput.text.Length == 0)
                    {
                        throw new Exception("Username field empty!");
                    }
                    User.SetUsername(usernameInput.text);

                    if (ErrorOutput.text.Length != 0)
                    {
                        ErrorOutput.text = "";
                    }
                }
                catch (Exception e)
                {
                    ErrorOutput.text = e.Message;
                    throw e;
                }
                break;
            case 5:
                // height panel
                try
                {
                    if (!string.IsNullOrEmpty(heightInput.text))
                    {
                        User.SetHeight(float.Parse(heightInput.text));
                    }
                    else {

                        throw new Exception("String is null or empty");
                    };

                    if (ErrorOutput.text.Length != 0)
                    {
                        ErrorOutput.text = "";
                    }
                }
                catch (Exception e)
                {
                    ErrorOutput.text = e.Message;
                    throw e;
                }
                break;
            case 6:
                // weight panel
                try
                {
                    if (!string.IsNullOrEmpty(weightInput.text))
                    {
                        User.SetWeight(float.Parse(weightInput.text));
                    }
                    else
                    {
                        throw new Exception("String is null or empty");
                    };

                    if (ErrorOutput.text.Length != 0)
                    {
                        ErrorOutput.text = "";
                    }
                }
                catch (Exception e)
                {
                    ErrorOutput.text = e.Message;
                    throw e;
                }
                break;
            case 7:
                DBWorking.RegisterUser();

                usernameInput.text = "";
                emailInput.text = "";
                passwordInput.text = "";
                weightInput.text = "";
                heightInput.text = "";

                if (ErrorOutput.text.Length != 0)
                {
                    ErrorOutput.text = "";
                }

                break;
        }
    }

    public void SetGoal(short option)
    {
        User.SetGoal(option);
    }

    public void SetActivity(short option)
    {
        User.SetGoal(option);
    }
}

// Todo: 
// Виводити помилки у інтерфейс