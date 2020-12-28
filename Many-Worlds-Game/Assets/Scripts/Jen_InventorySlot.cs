using UnityEngine;
using UnityEngine.UI;

public class Jen_InventorySlot : MonoBehaviour
{
    public Image icon;

    Jen_Item item;

    public void AddItem (Jen_Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
