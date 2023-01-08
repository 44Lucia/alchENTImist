using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeHandler : MonoBehaviour
{
    private DBManager dbManager;

    private int currentRecipe;
    private int totalRecipes;
    private List<Potion> potionsList;
    private Sprite newSprite;

    [SerializeField] private TextMeshProUGUI pageText;
    [SerializeField] private TextMeshProUGUI potionNameText;
    [SerializeField] private List<Image> potionIngredientIcon;
    [SerializeField] private Image potionImg;

    // Start is called before the first frame update
    void Start()
    {
        dbManager = FindObjectOfType<DBManager>();
        currentRecipe = 1;

        potionsList = dbManager.Potions;
        totalRecipes = potionsList.Count;

        LoadRecipes(currentRecipe);
    }

    private void LoadRecipes(int numRecipe) 
    {
        //Set the current Page
        pageText.text = numRecipe.ToString() + " / " + totalRecipes.ToString();
        //Set the Potion name
        potionNameText.text = potionsList[numRecipe - 1].name + " potion";

        //Set the potion Image
        newSprite = Resources.Load<Sprite>(potionsList[numRecipe -1].iconPath);
        if (newSprite == null){
            Debug.Log(potionsList[numRecipe -1].iconPath);
        }
        potionImg.sprite = newSprite;

        //Get the Potion Ingredients
        List<Ingredient> ingredients = dbManager.GetPotionIngredients(numRecipe);
        //Disable all slots
        for (int i = 0; i < potionIngredientIcon.Count; i++) {
            potionIngredientIcon[i].enabled = false;
        }
        //Set slots
        for (int i = 0; i < ingredients.Count; i++) {
            newSprite = Resources.Load<Sprite>(ingredients[i].iconPath);
            Debug.Log(ingredients[i].iconPath);
            potionIngredientIcon[i].enabled = true;
            potionIngredientIcon[i].sprite = newSprite;
        }
    }

    public void NextPage() {
        if (currentRecipe < totalRecipes){
            currentRecipe++;
            LoadRecipes(currentRecipe);
        }
    }

    public void PreviousPage() {
        if (currentRecipe > 1){
            currentRecipe--;
            LoadRecipes(currentRecipe);
        }
    }
}
