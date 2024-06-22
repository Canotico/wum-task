
public class ContainerInstance : ItemInstanceBase
{
    /// <summary>
    /// Definition that this Instance is based on.
    /// We populate this on creation (either manually or through the item dictionary if deserializing)
    /// and use it to determine the qualities of this item beyond it's current state in the inventory.
    /// 
    /// NOTE: Ideally this would be defined in ItemInstanceBase since it's also used in StackableInstance
    /// </summary>
    private ContainerDefinition myDefinition;
    public ItemInstanceBase[] containedItems;
    /// <summary>
    /// A container has a fixed set of slots, and these can become empty/filled on demand.
    /// We store the 'nextEmptySlot' after operations such as Add/Remove/Move to facilitate
    /// finding the next available item slot and avoid cycling through the entire array.
    /// </summary>
    private int nextEmptySlot;

    /// <summary>
    /// Used during deserealization to obtain the associated ItemDefinition through
    /// the itemDictionary.
    /// 
    /// NOTE: This constructor should live in the parent since it's duplicated in StackableInstance
    /// </summary>
    public ContainerInstance()
    {
        if (string.IsNullOrEmpty(definitionUniqueName)) return;

        if(Inventory.Instance.itemDictionary.dictionary.ContainsKey(definitionUniqueName))
        {
            Initialize(Inventory.Instance.itemDictionary.dictionary[definitionUniqueName] as ContainerDefinition);
        }
    }

    /// <summary>
    /// Used if we know the ItemDefinition this ItemInstance is associated with.
    /// 
    /// NOTE: should be moved to the parent class
    /// </summary>
    /// <param name="definition"></param>
    public ContainerInstance(ContainerDefinition definition)
    {
        Initialize(definition);
    }

    private void Initialize(ContainerDefinition definition)
    {
        myDefinition = definition;
        //The name of a SO is enforced to be unique by the operating system, so we use it as a unique id
        definitionUniqueName = myDefinition.name;
        containedItems = new ItemInstanceBase[myDefinition.size];
        nextEmptySlot = 0;
    }

    /// <summary>
    /// Not fully functioning, but the idea is to add an item in the closest slot.
    /// An alternate version would specify the index.
    /// </summary>
    /// <param name="newItem"></param>
    public void AddItem(ItemInstanceBase newItem)
    {
        if (nextEmptySlot >= containedItems.Length) return;

        containedItems[nextEmptySlot] = newItem;
        nextEmptySlot++;
    }
}
