using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotions : MonoBehaviour
{
    [SerializeField] private Potion potion;

    public Potion SavedPotion { get { return potion; } set { potion = value; } }
}
