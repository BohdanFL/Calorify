using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBWorking : MonoBehaviour
{
    string dbName = "URI=file:Users.db";
    void Start()
    {
        CreateDB();
        RegisterUser("Max", "989m66@gmail.com", "lalalala", 62, 182, "growth", "small");
        LoginUser("989m66@gmail.com", "lalalala");
        ShowAll();
    }

    void CreateDB()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open(); 
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS User (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Email TEXT, Password TEXT, Mass REAL, Height REAL, Goal TEXT, ActivityLevel TEXT);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        
    }

    public void RegisterUser(string name, string email, string password, double mass, double height, string goal, string activityLevel)
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO User (Name, Email, Password, Mass, Height, Goal, ActivityLevel) VALUES (@Name, @Email, @Password, @Mass, @Height, @Goal, @ActivityLevel);";
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Mass", mass);
                command.Parameters.AddWithValue("@Height", height);
                command.Parameters.AddWithValue("@Goal", goal);
                command.Parameters.AddWithValue("@ActivityLevel", activityLevel);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public bool LoginUser(string email, string password)
    {
        string nameToCheck = ""; // string used to check if there're records by email and login

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM User WHERE Email = @Email AND Password = @Password;";
                command.Parameters.AddWithValue("@Email", email); 
                command.Parameters.AddWithValue("@Password", password);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nameToCheck = (string)reader["Name"];
                    }
                }
            }
        }
        if(nameToCheck.Length > 0)
        {
            return true;
        }

        return false;
    }

    // Only for development
    void ShowAll()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM User;";
                using(IDataReader  reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log($"Name: {reader["Name"]}");
                    }
                }
            }
        }
    }

    void ClearTable()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM User;";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

}
