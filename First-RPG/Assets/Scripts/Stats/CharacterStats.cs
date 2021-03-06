﻿using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public Stat damage;
    public Stat armour;

    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }


    void Awake() {
        CurrentHealth = maxHealth;
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
