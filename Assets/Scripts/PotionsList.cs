using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
            GameObject potion = Instantiate(PotionPrefab, parent: transform);
            Texture2D texture = Resources.Load(dbManager.Potions[i].iconPath) as Texture2D;
            new PotionsModel(potion, dbManager.Potions[i]);
        }
    }
}

public class PotionsModel
{
    public Image icon;
    public TextMeshProUGUI text;

    public PotionsModel(GameObject go, Potion ing)
    {
        icon = go.transform.GetChild(1).GetComponent<Image>();
        text = go.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        Texture2D texture = Resources.Load(ing.iconPath) as Texture2D;
        text.text = ing.name;

        go.name = ing.name;

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        icon.sprite = sprite;
    }
}
