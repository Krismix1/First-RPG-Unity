using UnityEngine;
using System;

public abstract class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionPoint;

    Transform player;

    bool isFocused = false;
    bool hasInteracted = false;

    private void Start() {
        if(radius <= 0) {
            throw new ArgumentOutOfRangeException("Radius < 0");
        }
    }

    public abstract void Interact();

    private void Update() {
        if (isFocused && !hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionPoint.position);
            if (distance <= radius) {
                hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocus(Transform player) {
        isFocused = true;
        this.player = player;
        hasInteracted = false;
    }

    public void OnDefocus() {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }
}
