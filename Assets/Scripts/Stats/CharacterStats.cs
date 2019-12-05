using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth { get; private set;}

    public Stat damage;
    public Stat health;

    private void Awake() {
        currentHealth = maxHealth;    
    }
    
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            takeDamage(10);
        }
    }

    public void takeDamage (int damage){
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    } 

    public void giveHealth (int health) {
        currentHealth += health;
    }

    public virtual void Die() {

    }

}
