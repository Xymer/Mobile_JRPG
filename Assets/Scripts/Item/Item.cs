using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item",menuName ="Items/Item")]
public class Item : ScriptableObject, IItem
{
    [SerializeField] bool isEquippable = false;
    [SerializeField] bool isUsable = true;
    [SerializeField] ItemStats itemStats;
    [SerializeField] ItemType itemType = ItemType.Helm;

    public void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
