using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LateralPanel : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject recipesBook;
    [SerializeField] private GameObject ordersBook;
    private bool recipeBookFunc;
    private bool ordersBookFunc;

    public void OpenAndCloseRecipeBook() 
    {
        recipeBookFunc = !recipeBookFunc;
        gamePanel.SetActive(!gamePanel.activeSelf);
        recipesBook.SetActive(!recipesBook.activeSelf);
    }

    public void OpenAndCloseOrdersBook()
    {
        ordersBookFunc = !ordersBookFunc;
        gamePanel.SetActive(!gamePanel.activeSelf);
        ordersBook.SetActive(!ordersBook.activeSelf);
    }
}
