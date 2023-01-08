using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingPotions : MonoBehaviour
{
    [SerializeField] private List<GameObject> ingredientsSlots;
    [SerializeField] private GameObject potionContainer;
    [SerializeField] private GameObject potionPrfb;

    private DBManager dbManager;
    private List<Potion> potions;

    // Start is called before the first frame update
    void Start()
    {
        dbManager = FindObjectOfType<DBManager>();
        potions = dbManager.Potions;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CraftPotion()
    {
        Debug.Log("crafting");
        bool ingredients_found;
        Potion resultPotion = new Potion();

        //Check every potion
        for (int i = 0; i < potions.Count; i++)
        {
            ingredients_found = false;

            List<Ingredient> potion_ingredients = dbManager.GetPotionIngredients(i + 1);
            //Copy Framework
            List<Ingredient> framework_ingredientsCOPY = new List<Ingredient>();
            for (int p = 0; p < ingredientsSlots.Count; p++)
            {
                try { framework_ingredientsCOPY.Add(ingredientsSlots[p].transform.GetComponentInChildren<ItemIngredients>().SavedIngredients); }
                catch { }
            }

            //Check potion ingredients
            for (int j = 0; j < potion_ingredients.Count; j++)
            {
                //Compare with a framework copy
                for (int k = 0; k < framework_ingredientsCOPY.Count; k++)
                {
                    int frmWrkIngId = framework_ingredientsCOPY[k].id;
                    if (potion_ingredients[j].id == frmWrkIngId)
                    {
                        framework_ingredientsCOPY.Remove(framework_ingredientsCOPY[k]);
                        ingredients_found = true;
                        break;
                    }
                    else { ingredients_found = false; }
                }

                //Ingredient not found
                if (!ingredients_found) { Debug.Log("ingredient not found"); break; }
            }
            //Potion found!
            if (framework_ingredientsCOPY.Count == 0)
            {
                resultPotion = potions[i];
                break;
            }
        }

        //Craft Potion
        if (resultPotion.name != null)
        {
            GameObject potion = Instantiate(potionPrfb, potionContainer.transform);
            potion.GetComponent<ItemPotions>().SavedPotion = resultPotion;
            potion.name = resultPotion.name;

            Sprite potionSprite = Resources.Load<Sprite>(resultPotion.iconPath);
            potion.GetComponent<Image>().sprite = potionSprite;
        }
        else { Debug.Log("Potion null"); }
    }
}
