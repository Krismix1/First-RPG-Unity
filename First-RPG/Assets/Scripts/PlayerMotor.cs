using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;

    Transform target;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (target != null) {
            //TODO: Transform the following into a courutine for optimazation
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point) {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable interactable) {
        target = interactable.transform;
        agent.stoppingDistance = interactable.radius * .8f;
        agent.updateRotation = false;
    }

    public void StopFollowingTarget() {
        target = null;
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0f;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
