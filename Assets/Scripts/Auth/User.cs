using System;
using TMPro;
using UnityEditor;
using UnityEngine;

enum GoalType
{
    LoseWeight,
    PutOnWeight,
    KeepFit
}

enum ActivityType
{
    None,
    Regular,
    Often
}

public class User
{
    // Дані користувача
    private string username;
    private string email;
    private string password;
    private short goal;
    private short activity;
    private short height;
    private short weight;

    public User()
    {
        username = "";
        email = "";
        goal = (short)GoalType.KeepFit;
        activity = (short)ActivityType.Regular;
        height = 0;
        weight = 0;
    }

    public User(string _username, string _email, string _password, short _goal, short _activity, short _height, short _weight)
    {
        SetUsername(_username);
        SetEmail(_email);
        SetPassword(_password);
        SetGoal(_goal);
        SetActivity(_activity);
        SetHeight(_height);
        SetWeight(_weight);
    }

    public void SetUsername(string _username) {
        if (_username.Length > 0)
        {
            username = _username;
        }
    }

    public void SetEmail(string _email) {
        if (_email.Length == 0) { 
            throw new Exception("Email is empty");
        }
        if (!_email.Contains("@gmail.com") || !(_email.Length > 10))
        {
            throw new Exception("Incorrect email");
        }
        email = _email;
    }

    public void SetPassword(string _password) {
        if (_password.Length == 0)
        {
            throw new Exception("Email is empty");
        }
        if (!(_password.Length > 6))
        {
            throw new Exception("Password must be longer than 6 characters");
        }
        password = _password;
        // додати більше перевірок(цифри, великі і маленькі букви)
        // додати шкалу оцінки паролю
    }

    public void SetGoal(short _goal) {
        if (_goal < 0 && _goal >= Enum.GetNames(typeof(GoalType)).Length)
        {
            throw new Exception("GoalType doesn't exist");
        }
        goal = _goal;
    }

    public void SetActivity(short _activity) {
        if (_activity < 0 && _activity >= Enum.GetNames(typeof(ActivityType)).Length)
        {
            throw new Exception("GoalType doesn't exist");
        }
        activity = _activity;
    }

    public void SetHeight(short _height) {
        if (_height <= 0)
        {
            throw new Exception("Height must be greater than 0!");
        }
        height = _height;
    }

    public void SetWeight(short _weight) {
        if (_weight <= 0)
        {
            throw new Exception("Weight must be greater than 0!");
        }
        weight = _weight;
    }


    public string GetUsername() { return username; }
    public string GetEmail() { return email; }
    public string GetPassword() { return password; }
    public short GetGoal() { return goal; }
    public short GetActivity() { return activity; }
    public short GetHeight() { return height; }
    public short GetWeight() { return weight; }
}
// Tips: Перевіряти данні у сеттерах.
// Виводити помилки у інтерфейс