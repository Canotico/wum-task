using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDefinitionDictionary", menuName = "Inventory/Dictionary")]
public class ItemDefinitionDictionary : ScriptableObject
{
    public Dictionary<string, ItemDefinitionBase> dictionary;
}
