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
    private List<Ingredient> ingredientsName;
    private int potionsAmount;
    private List<Potion> potionsName;
    private int ingredientsPotionAmount;
    private List<IgrendientsPotion> ingredientsPotionName;

    private void Awake()
    {
        OpenDatabase();

        /*Ingredients*/
        ingredientsAmount = getIngredientsAmount();
        ingredientsName = getAllIngredientsName();

        /*Potions*/
        potionsAmount = getPotionsAmount();
        potionsName = getAllPotionsName();

        /*IngredientsPotion*/
        ingredientsPotionAmount = getIngredientsPotionAmount();
        ingredientsPotionName = getAllIngredientsPotionsName();

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

    private List<Ingredient> getAllIngredientsName() {
        string query = "SELECT * FROM ingredients;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<Ingredient> res = new List<Ingredient>();
        while (dataReader.Read()) {
            res.Add(new Ingredient(dataReader));
        }

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

    private List<Potion> getAllPotionsName()
    {
        string query = "SELECT * FROM potions;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<Potion> res = new List<Potion>();
        while (dataReader.Read()) {
            res.Add(new Potion(dataReader));
        }

        return res;
    }

    private int getIngredientsPotionAmount() {
        string query = "SELECT COUNT(*) FROM potions_ingredients;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        while (dataReader.Read()) { return dataReader.GetInt32(0); }

        return 0;
    }

    private List<IgrendientsPotion> getAllIngredientsPotionsName() {
        string query = "SELECT * FROM potions_ingredients;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<IgrendientsPotion> res = new List<IgrendientsPotion>();
        while (dataReader.Read())
        {
            res.Add(new IgrendientsPotion(dataReader));
        }

        return res;
    }

    /*Accesores de Ingredientes*/
    public int IngredientsAmount { get { return ingredientsAmount; } set { ingredientsAmount = value; } }
    public List<Ingredient> Ingredients { get { return ingredientsName; } set { ingredientsName = value; } }

    /*Accesores de Pociones*/
    public int PotionsAmount { get { return potionsAmount; } set { potionsAmount = value; } }
    public List<Potion> Potions { get { return potionsName; } set { potionsName = value; } }

    /*Accesores de IngredientesPocion*/
    public int IngredientsPotionAmount { get { return ingredientsPotionAmount; } set { ingredientsPotionAmount = value; } }
    public List<IgrendientsPotion> IngredientsPotion { get { return ingredientsPotionName; } set { ingredientsPotionName = value; } }
}
