using UnityEngine;

/// <summary>
/// Represents the very basic building blocks of what an Item is
/// </summary>
public class ItemDefinitionBase : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
}
