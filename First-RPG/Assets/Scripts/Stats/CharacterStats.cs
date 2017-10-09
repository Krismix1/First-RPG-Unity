using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public Stat damage;
    public Stat armour;

    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    // Use this for initialization
    void Awake() {
        CurrentHealth = maxHealth;
    }

    private void Update() {
        // For testing taking of damage and armour reduction
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage) {
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (CurrentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        Debug.Log(transform.name + " died.");
    }
}
