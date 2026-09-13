using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;



public class Player_Pickup : MonoBehaviour
{
    [SerializeField] private Player_Inventory inventory;
    private void OnTriggerEnter(Collider other)
    {
        
        Item_Inventory item = other.GetComponent<Item_Inventory>();

        //Chequeo que tenga el componente Item_Inventory
        if (item != null)
        {
            // llamo a la función AddItem para ponerlo en el inventario
            inventory.AddItem(item.Id);
            // Destruye el item agarado
            Destroy(other.gameObject);
        }
    }
}
