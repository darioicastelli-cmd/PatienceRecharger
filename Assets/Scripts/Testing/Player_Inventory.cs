using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    private Dictionary<ItemId, int> inventory = new Dictionary<ItemId, int>();

    //La función devuelve un ItemId y un int, que se agrega al Diccionario.
    public void AddItem(ItemId itemId)
    {
        // Si ya tengo de ese item le agrego 1 más de lo que ya tengo.
        if (inventory.ContainsKey(itemId))
        {
            inventory[itemId] += 1;
        }
        //Si no tengo el item lo agrego a la lista de Id y le pongo 1.
        else
        {
            inventory.Add(itemId, 1);
        }
        Debug.Log("tenes " + inventory[itemId] + " " + itemId);
    }

}
