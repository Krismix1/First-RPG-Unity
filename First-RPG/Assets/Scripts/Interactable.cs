using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionPoint;

    Transform player;

    bool isFocused = false;
    bool hasInteracted = false;

    public virtual void Interact() {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update() {
        if (isFocused && !hasInteracted) {
            float distance = Vector3.Distance(transform.position, interactionPoint.position);
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
