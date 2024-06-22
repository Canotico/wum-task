using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStackableDefinition", menuName = "Inventory/Stackable Item")]
public class StackableDefinition : ItemDefinitionBase
{
    [Min(1)]
    public int maxStackCount = 1;
}
