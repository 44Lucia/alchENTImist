using UnityEngine;
using TMPro;

public class IngredientsList : MonoBehaviour
{
    [SerializeField] private DBManager dbManager;
    [SerializeField] private GameObject ingredientPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dbManager = FindObjectOfType<DBManager>();
        GenerateIngredients();
    }

    private void GenerateIngredients() {
        for (int i = 0; i < dbManager.IngredientsAmount; i++){
            GameObject ingredient = Instantiate(ingredientPrefab, parent: transform);
            ingredient.name = dbManager.IngredientsName[i];
            ingredient.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dbManager.IngredientsName[i];
        }
    }
}
