using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public LayerMask groundLayer;

    Interactable focus;
    PlayerMotor motor;


    void Start() {
        motor = GetComponent<PlayerMotor>();
    }


    void Update() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            // Click on UI object
            return;
        }

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
        motor.StopFollowingTarget();
        if (focus) {
            focus.OnDefocus();
        }
        focus = null;
    }
}
