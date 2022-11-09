using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using System.Collections.Generic;

public class DBManager : MonoBehaviour
{
    [Header("DB")]
    private IDbConnection dbConnection;
    private IDbCommand cmd;
    private IDataReader dataReader;

    [Header("Values Database")]
    private int ingredientsAmount;
    private List<string> ingredientsName;
    private int potionsAmount;
    private List<string> potionsName;

    private void Awake()
    {
        OpenDatabase();

        /*Ingredients*/
        ingredientsAmount = getIngredientsAmount();
        ingredientsName = getAllIngredientsName();

        /*Potions*/
        potionsAmount = getPotionsAmount();
        potionsName = getAllPotionsName();
    }

    private void OpenDatabase()
    {
        string dbUri = "URI=file:alchENTImist.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
    }

    private void readString(int rowPas = 1) {
        while (dataReader.Read()) {
            string res = dataReader.GetString(rowPas);
        }
    }

    private int getIngredientsAmount() {
        string query = "SELECT COUNT(*) FROM ingredients;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        while (dataReader.Read()){ return dataReader.GetInt32(0); }

        return 0;
    }

    private List<string> getAllIngredientsName() {
        string query = "SELECT * FROM ingredients;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<string> res = new List<string>();
        while (dataReader.Read()) { res.Add(dataReader.GetString(1)); }

        return res;
    }

    private int getPotionsAmount() {
        string query = "SELECT COUNT(*) FROM potions;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        while (dataReader.Read()) { return dataReader.GetInt32(0); }

        return 0;
    }

    private List<string> getAllPotionsName()
    {
        string query = "SELECT * FROM potions;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<string> res = new List<string>();
        while (dataReader.Read()) { res.Add(dataReader.GetString(1)); }

        return res;
    }

    /*Accesores de Ingredientes*/
    public int IngredientsAmount { get { return ingredientsAmount; } set { ingredientsAmount = value; } }
    public List<string> IngredientsName { get { return ingredientsName; } set { ingredientsName = value; } }

    /*Accesores de Pociones*/
    public int PotionsAmount { get { return potionsAmount; } set { potionsAmount = value; } }
    public List<string> PotionsName { get { return potionsName; } set { potionsName = value; } }
}
