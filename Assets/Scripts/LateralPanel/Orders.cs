using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Orders : MonoBehaviour
{
    private DBManager dbManager;

    [SerializeField] private OrdersHandler ordersHandler;
    [SerializeField] private TextMeshProUGUI m_CustomerNameText;
    [SerializeField] private Image m_customerIcon;

    [SerializeField] private List<GameObject> potionFrameworks;

    private void Start()
    {
        dbManager = FindObjectOfType<DBManager>();
    }

    private void Update()
    {
        if (ordersHandler == null) { return; }

        OrderComprobation();
    }

    private void OrderComprobation()
    {
        bool potions_found = false;
        //Get current order ID
        List<Potion> m_orderPotions = dbManager.GetOrdersPotions(ordersHandler.GetCurrentOrderID);

        //Get a Framework copy
        List<Potion> frameworkPotionsCOPY = new List<Potion>();
        for (int i = 0; i < potionFrameworks.Count; i++)
        {
            try { frameworkPotionsCOPY.Add(potionFrameworks[i].transform.GetComponentInChildren<ItemPotions>().SavedPotion); }
            catch { /*Nothing*/ }
        }

        //Return if potions needed amount not reached
        if (frameworkPotionsCOPY.Count != m_orderPotions.Count) { return; }

        //Check order potions
        for (int j = 0; j < m_orderPotions.Count; j++)
        {
            //Compare with the framework copy
            for (int k = 0; k < frameworkPotionsCOPY.Count; k++)
            {
                int frmWrkIngId = frameworkPotionsCOPY[k].id;
                if (m_orderPotions[j].id == frmWrkIngId)
                {
                    frameworkPotionsCOPY.Remove(frameworkPotionsCOPY[k]);
                    potions_found = true;
                    break;
                }
                else { potions_found = false; }
            }

            //Potion not found
            if (!potions_found) { break; }
        }

        //Order potions found!
        if (frameworkPotionsCOPY.Count == 0)
        {
            ordersHandler.SetNextOrder();
            CleanFrameworks();
        }
        //Order potions not found
        else { CleanFrameworks(); }
    }

    private void CleanFrameworks()
    {
        for (int i = 0; i < potionFrameworks.Count; i++)
        {
            try { Destroy(potionFrameworks[i].transform.GetChild(0).gameObject); }
            catch { }
        }
    }
}
