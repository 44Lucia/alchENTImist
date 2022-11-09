using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Recipes : MonoBehaviour
{
    [SerializeField] private GameObject panels;
    [SerializeField] private GameObject recipesBook;
    private bool recipeBookFunc;

    public void OpenAndCloseRecipeBook() {
        recipeBookFunc = !recipeBookFunc;
        panels.SetActive(!panels.activeSelf);
        recipesBook.SetActive(!recipesBook.activeSelf);
    }
}
