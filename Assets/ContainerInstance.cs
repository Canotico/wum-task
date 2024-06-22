
public class ContainerInstance : ItemInstanceBase
{
    private ContainerDefinition myDefinition;
    public ItemInstanceBase[] containedItems;
    private int nextEmptySlot;

    public ContainerInstance()
    {
        if (string.IsNullOrEmpty(definitionUniqueName)) return;

        if(Inventory.Instance.itemDictionary.dictionary.ContainsKey(definitionUniqueName))
        {
            Initialize(Inventory.Instance.itemDictionary.dictionary[definitionUniqueName] as ContainerDefinition);
        }
    }

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

    public void AddItem(ItemInstanceBase newItem)
    {
        if (nextEmptySlot >= containedItems.Length) return;

        containedItems[nextEmptySlot] = newItem;
        nextEmptySlot++;
    }
}
