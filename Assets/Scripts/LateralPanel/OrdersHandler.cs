using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrdersHandler : MonoBehaviour
{
    private DBManager dbManager;

    private int currentOrder;
    private int oldOrder;
    private int totalOrders;
    private List<OrdersPotion> ordersList;
    private List<Clients> m_customerList;
    private Sprite newSprite;

    [SerializeField] private TextMeshProUGUI m_orderText;
    [SerializeField] private TextMeshProUGUI m_CustomerNameText;
    [SerializeField] private Image m_customerIcon;

    [SerializeField] private List<Image> m_orderPotionsIcon;

    private void Start()
    {
        dbManager = FindObjectOfType<DBManager>();
        currentOrder = 1;
        oldOrder = currentOrder;

        ordersList = dbManager.GetOrders;
        totalOrders = ordersList.Count;

        m_customerList = dbManager.GetClients;

        RandomizeOrdersOrder();
        LoadOrder(currentOrder);

        gameObject.SetActive(false);
    }

    private void LoadOrder(int orderNum)
    {
        //Set the current Order
        m_orderText.text = "Order Number " + orderNum;
        //Set the Client name
        int customerID = ordersList[orderNum - 1].id_client;
        m_CustomerNameText.text = m_customerList[customerID - 1].name;

        //Set the Client Image
        newSprite = Resources.Load<Sprite>(m_customerList[customerID - 1].avatar);
        m_customerIcon.sprite = newSprite;

        //Get the Order Potions
        List<Potion> orderPotions = dbManager.GetOrdersPotions(ordersList[orderNum - 1].id_order);

        //Disable all potion slots image
        for (int i = 0; i < m_orderPotionsIcon.Count; i++){
            m_orderPotionsIcon[i].enabled = false;
        }

        //Set slots new image
        for (int i = 0; i < orderPotions.Count; i++) {
            newSprite = Resources.Load<Sprite>(orderPotions[i].iconPath);

            m_orderPotionsIcon[i].enabled = true;
            m_orderPotionsIcon[i].sprite = newSprite;
        }
    }

    private void RandomizeOrdersOrder()
    {
        for (int i = 0; i < ordersList.Count; i++){
            OrdersPotion temp = ordersList[i];
            int randomIndex = Random.Range(i, ordersList.Count);
            ordersList[i] = ordersList[randomIndex];
            ordersList[randomIndex] = temp;
        }
    }

    public void SetNextOrder()
    {
        List<Potion> orderPotions = dbManager.GetOrdersPotions(ordersList[currentOrder - 1].id_order);
        //Add the money to player
        dbManager.SaveUsersMoney(SessionsHolder.CurrentUser.name, SessionsHolder.CurrentUser.money + orderPotions.Count * 12);
        SessionsHolder.CurrentUser = dbManager.FindUsernames(SessionsHolder.CurrentUser.name)[0];

        currentOrder++;
        if (currentOrder > ordersList.Count) { currentOrder = 1; RandomizeOrdersOrder(); }
        LoadOrder(currentOrder);
    }

    public int GetCurrentOrderID { get { return ordersList[currentOrder - 1].id_order; } }
}
