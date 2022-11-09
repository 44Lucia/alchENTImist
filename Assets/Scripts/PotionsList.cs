using UnityEngine;
using TMPro;

public class PotionsList : MonoBehaviour
{
    [SerializeField] private DBManager dbManager;
    [SerializeField] private GameObject PotionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dbManager = FindObjectOfType<DBManager>();
        GenerateIngredients();
    }

    private void GenerateIngredients()
    {
        for (int i = 0; i < dbManager.PotionsAmount; i++)
        {
            GameObject ingredient = Instantiate(PotionPrefab, parent: transform);
            ingredient.name = dbManager.PotionsName[i];
            ingredient.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dbManager.PotionsName[i];
        }
    }
}
