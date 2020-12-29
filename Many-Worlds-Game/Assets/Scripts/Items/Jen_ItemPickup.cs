using UnityEngine;

public class Jen_ItemPickup : Jen_Interactable
{
    public Jen_Item item;
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up item." + item.name);
        bool wasPickedUp = Jen_Inventory.instance.Add(item);
        
        if (wasPickedUp)
            Destroy(gameObject);
    }
}
