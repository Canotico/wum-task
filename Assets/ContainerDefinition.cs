using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewContainerDefinition", menuName = "Inventory/Container Item")]
public class ContainerDefinition : ItemDefinitionBase
{
    [Min(1)]
    public int size = 4;
}
