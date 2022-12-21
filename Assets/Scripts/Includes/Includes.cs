using System.Data;
public struct Ingredient
{

    public int id;
    public string name;
    public float cost;
    public string iconPath;
    public string description;

    public Ingredient(IDataReader p_reader)
    {
        id = p_reader.GetInt32(0);
        name = p_reader.GetString(1);
        cost = p_reader.GetFloat(2);
        iconPath = p_reader.GetString(3);
        description = p_reader.GetString(4);
    }
}

public struct Potion
{

    public int id;
    public string name;
    public float cost;
    public string iconPath;
    public string description;
    public int id_potion_type;

    public Potion(IDataReader p_reader)
    {
        id = p_reader.GetInt32(0);
        name = p_reader.GetString(1);
        cost = p_reader.GetFloat(2);
        iconPath = p_reader.GetString(3);
        description = p_reader.GetString(4);
        id_potion_type = p_reader.GetInt32(5);
    }
}

public struct IgrendientsPotion 
{
    public int id_potion_ingredient;
    public int quantity;
    public int id_potion;
    public int id_ingredient;

    public IgrendientsPotion(IDataReader p_reader) 
    {
        id_potion_ingredient = p_reader.GetInt32(0);
        quantity = p_reader.GetInt32(1);
        id_potion = p_reader.GetInt32(2);
        id_ingredient= p_reader.GetInt32(3);
    }
}

public struct OrdersPotion
{
    public int id_order;
    public string date;
    public int id_client;
    public int id_user;

    public OrdersPotion(IDataReader p_reader)
    {
        id_order = p_reader.GetInt32(0);
        date = p_reader.GetString(1);
        id_client = p_reader.GetInt32(2);
        id_user = p_reader.GetInt32(3);
    }
}

public struct Clients
{
    public int id_customer;
    public string name;
    public string avatar;

    public Clients(IDataReader p_reader)
    {
        id_customer = p_reader.GetInt32(0);
        name = p_reader.GetString(1);
        avatar = p_reader.GetString(2);
    }
}

public struct User
{
    public int id_user;
    public string name;
    public string date;
    public string password;
    public int money;

    public User(IDataReader p_reader)
    {
        id_user = p_reader.GetInt32(0);
        name = p_reader.GetString(1);
        date = p_reader.GetString(2);
        password = p_reader.GetString(3);
        money = p_reader.GetInt32(4);
        
    }
}