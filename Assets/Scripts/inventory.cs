using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    public void AddItem(Item item)
    {
        inventory.Add(item);
        // Update inventory UI goes here
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
        // Update inventory UI goes here
    }

    public void UseItem(Item item)
    {
        // Use item logic goes here
    }
}



