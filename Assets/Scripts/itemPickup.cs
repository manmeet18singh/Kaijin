using UnityEngine;

public class itemPickup : Interactable
{
    public Item item;
    
    public override void Interact() {
        base.Interact();

        PickUp();
    }

    void PickUp () {
        Debug.Log("Picked Up Heart");
        Destroy(gameObject);
    }
}
