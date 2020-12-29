using UnityEngine;
using UnityEngine.UI;

public class Jen_InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Jen_Item item;

    public void AddItem (Jen_Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Jen_Inventory.instance.Remove(item);
    }

    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
