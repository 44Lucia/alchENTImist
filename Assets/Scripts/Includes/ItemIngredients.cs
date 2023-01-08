using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIngredients : MonoBehaviour
{
    [SerializeField] private Ingredient ingredient;
    public Ingredient SavedIngredients { get { return ingredient; } set { ingredient = value; } }
}
