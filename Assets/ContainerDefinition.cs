using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an item capable of storing other items
/// </summary>
[CreateAssetMenu(fileName = "NewContainerDefinition", menuName = "Inventory/Container Item")]
public class ContainerDefinition : ItemDefinitionBase
{
    [Min(1)]
    public int size = 4;
}
