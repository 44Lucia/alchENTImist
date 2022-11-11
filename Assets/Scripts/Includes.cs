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