using UnityEngine;

public class Jen_InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Jen_Inventory inventory;

    Jen_InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Jen_Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<Jen_InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }

            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
