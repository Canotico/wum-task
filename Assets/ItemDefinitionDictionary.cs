using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This object's purpose is to centralize all the ItemDefinitions that we have and pair them with their
/// file name so that when deserealizing ItemInstances, we can match the names with the proper definitions
/// </summary>
[CreateAssetMenu(fileName = "ItemDefinitionDictionary", menuName = "Inventory/Dictionary")]
public class ItemDefinitionDictionary : ScriptableObject
{
    public Dictionary<string, ItemDefinitionBase> dictionary;
}
