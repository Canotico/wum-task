using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI stackCount;
    private ItemInstanceBase itemInstance;

    public void SetItem(ItemInstanceBase item)
    {
        if(item == null)
        {
            icon.enabled = stackCount.enabled = false;
            return;
        }

        icon.enabled = true;

        if(item is ContainerInstance)
        {
            stackCount.enabled = false;
        }
        else if(item is StackableInstance)
        {
            stackCount.enabled = false;
            stackCount.text = (itemInstance as StackableInstance).currentStackCount.ToString();
        }
    }
}
