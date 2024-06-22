
public class StackableInstance : ItemInstanceBase
{
    private StackableDefinition myDefinition;
    public int currentStackCount;

    public StackableInstance()
    {
        if (string.IsNullOrEmpty(definitionUniqueName)) return;

        if (Inventory.Instance.itemDictionary.dictionary.ContainsKey(definitionUniqueName))
        {
            Initialize(Inventory.Instance.itemDictionary.dictionary[definitionUniqueName] as StackableDefinition);
        }
    }

    public StackableInstance(StackableDefinition definition)
    {
        Initialize(definition);
    }

    private void Initialize(StackableDefinition definition)
    {
        myDefinition = definition;
        //The name of a SO is enforced to be unique by the operating system, so we use it as a unique id
        definitionUniqueName = myDefinition.name;
        currentStackCount = 1;
    }
}
