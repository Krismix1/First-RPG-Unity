using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public LayerMask groundLayer;
    public Interactable focus;

    PlayerMotor motor;

    // Use this for initialization
    void Start() {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit, 100, groundLayer)) {
                motor.MoveToPoint(rayHit.point);
            }
            RemoveFocus();
        }

        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit)) {
                Interactable interactable = rayHit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus) {
        if (newFocus != focus) {
            if (focus != null) {
                focus.OnDefocus();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocus(transform);
    }

    void RemoveFocus() {
        focus = null;
        motor.StopFollowingTarget();
        if (focus) {
            focus.OnDefocus();
        }
    }
}
