using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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