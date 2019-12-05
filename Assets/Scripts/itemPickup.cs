using UnityEngine;

public class ItemPickup : Interactable
{  
    CharacterStats myStats;

    void Start() {
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact(){
        base.Interact();
        PickUp();
    }

    void PickUp () {
        myStats.giveHealth(10);
        Debug.Log("health is: " + myStats.health);
        Destroy(gameObject);
    }
}
