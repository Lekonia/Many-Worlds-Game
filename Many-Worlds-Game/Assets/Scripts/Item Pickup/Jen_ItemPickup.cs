using UnityEngine;

public class Jen_ItemPickup : Jen_Interactable
{
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up item.");
        // Add to inventory
        Destroy(gameObject);
    }
}
