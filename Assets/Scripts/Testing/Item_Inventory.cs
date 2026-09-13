using Unity.Collections;
using UnityEngine;

public enum ItemId
{
    Gem, Talisman, KeyFragment
}

public class Item_Inventory : MonoBehaviour
{
    [SerializeField] private ItemId id;
    public ItemId Id => id;
}
