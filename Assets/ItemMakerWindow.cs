using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemMakerWindow : EditorWindow
{
    enum ItemType
    {
        STACKABLE,
        CONTAINER
    }

    [MenuItem("Inventory/Item Maker")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ItemMakerWindow));
    }

    private ItemType selectedType;
    private int maxStackCount;
    private int containerSize;
    private Sprite itemIcon;
    private string itemName;
    private string itemDescription;

    private void OnGUI()
    {
        itemName = EditorGUILayout.TextField("Name: ", itemName);

        itemDescription = EditorGUILayout.TextField("Description: ", itemDescription);

        selectedType = (ItemType)EditorGUILayout.EnumPopup("Type:", (ItemType)selectedType);

        itemIcon = EditorGUILayout.ObjectField("Icon:", itemIcon, typeof(Sprite), false) as Sprite;

        switch (selectedType)
        {
            case ItemType.STACKABLE:
                maxStackCount = EditorGUILayout.IntField("Max Stacks:", maxStackCount);
                break;
            case ItemType.CONTAINER:
                containerSize = EditorGUILayout.IntField("Size:", containerSize);
                break;
            default: break;
        }

        if (GUILayout.Button("Create Item"))
        {
            switch(selectedType)
            {
                case ItemType.STACKABLE:
                    CreateStackableItem();
                    break;
                case ItemType.CONTAINER:
                    CreateContainerItem();
                    break;
                default: break;
            }
        }
    }

    private void CreateStackableItem()
    {
        StackableDefinition newStackableItem = ScriptableObject.CreateInstance<StackableDefinition>();
        newStackableItem.icon = itemIcon;
        newStackableItem.name = itemName;
        newStackableItem.maxStackCount = maxStackCount;
        newStackableItem.description = itemDescription;

        FinishItemCreation(newStackableItem);
    }

    private void CreateContainerItem()
    {
        ContainerDefinition newContainerItem = ScriptableObject.CreateInstance<ContainerDefinition>();
        newContainerItem.icon = itemIcon;
        newContainerItem.itemName = itemName;
        newContainerItem.size = containerSize;
        newContainerItem.description = itemDescription;

        FinishItemCreation(newContainerItem);
    }

    private void FinishItemCreation(ScriptableObject newItem)
    {
        AssetDatabase.CreateAsset(newItem, "Assets/Resources/Items/" + itemName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        ItemDictionaryUtils.UpdateDictionary();
    }
}
