using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;

public class ItemDictionaryUtils : MonoBehaviour
{
    [MenuItem("Inventory/Update Dictionary")]
    static void UpdateDictionary()
    {
        ItemDefinitionDictionary itemsDictionary = Resources.Load<ItemDefinitionDictionary>("Items/ItemDictionary");
        ItemDefinitionBase[] allItemDefs = Resources.LoadAll<ItemDefinitionBase>("Items");

        if (itemsDictionary == null)
        {
            Debug.LogError("Failed to find items dictionary");
            return;
        }

        if (itemsDictionary.dictionary == null)
            itemsDictionary.dictionary = new Dictionary<string, ItemDefinitionBase>();
        else
            itemsDictionary.dictionary.Clear();

        foreach (var itemDef in allItemDefs)
        {
            itemsDictionary.dictionary.Add(itemDef.name, itemDef);
            Debug.Log($"Added {itemDef.name} to ItemDictionary {itemsDictionary.name}");
        }
    }
}
