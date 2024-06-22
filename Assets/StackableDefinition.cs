using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an item that can be stacked a number of times
/// </summary>
[CreateAssetMenu(fileName = "NewStackableDefinition", menuName = "Inventory/Stackable Item")]
public class StackableDefinition : ItemDefinitionBase
{
    [Min(1)]
    public int maxStackCount = 1;
}
