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
    private List<OrdersPotion> orders;
    private List<Clients> clients;

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

        /*Orders*/
        orders = getAllOrders();
        clients = getAllClients();

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

    public List<Ingredient> getPotionIngredients(int IDpotion) {
        string query = "SELECT * FROM ingredients LEFT JOIN potions_ingredients WHERE id_potion = ";
        query += IDpotion;
        query += " AND potions_ingredients.id_ingredient = ingredients.id_ingredient;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<Ingredient> res = new List<Ingredient>();
        while (dataReader.Read()) 
        {
            res.Add(new Ingredient(dataReader));
        }

        return res;
    }

    private List<OrdersPotion> getAllOrders() 
    {
        string query = "SELECT * FROM orders;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<OrdersPotion> res = new List<OrdersPotion>();
        while (dataReader.Read())
        {
            res.Add(new OrdersPotion(dataReader));
        }
        return res;
    }

    private List<Potion> getOrdersPotions(int orderID)
    {
        string query = "SELECT * FROM potions LEFT JOIN orders_potions WHERE id_order = ";
        query += orderID;
        query += " AND orders_potions.id_potion = potions.id_potion;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<Potion> res = new List<Potion>();
        while (dataReader.Read())
        {
            res.Add(new Potion(dataReader));
        }

        return res;
    }

    private List<Clients> getAllClients()
    {
        string query = "SELECT * FROM clients;";
        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<Clients> res = new List<Clients>();
        while (dataReader.Read())
        {
            res.Add(new Clients(dataReader));
        }

        return res;
    }

    private void saveUsersMoney(string usrnm, int newMoney)
    {
        string query = "UPDATE users SET money = ";
        query += newMoney;
        query += " WHERE name = \"";
        query += usrnm;
        query += "\";";

        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();
    }

    private List<User> findUsernames(string usrnm)
    {
        string query = "SELECT * FROM users WHERE name = \"";
        query += usrnm;
        query += "\"";

        cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;
        dataReader = cmd.ExecuteReader();

        List<User> res = new List<User>();
        while (dataReader.Read())
        {
            res.Add(new User(dataReader));
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

    /*Accesores de Ordenes*/
    public List<OrdersPotion> GetOrders { get { return orders; } set { orders = value; } }
    public List<Potion> GetOrdersPotions(int id) { return getOrdersPotions(id); }
    public List<Clients> GetClients { get { return clients; } set { clients = value; } }

    /*Users*/
    public List<User> FindUsernames(string username) { return findUsernames(username); }
    public void SaveUsersMoney(string username, int money) { saveUsersMoney(username, money); }
}
