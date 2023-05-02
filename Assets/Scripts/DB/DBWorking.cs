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
        ClearTable();
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
                command.CommandText = "INSERT INTO User (Name) VALUES (@Name);";
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
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
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

}
