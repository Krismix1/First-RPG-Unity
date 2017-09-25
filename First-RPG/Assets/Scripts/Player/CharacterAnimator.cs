using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    const float LocomotionAnimationSmoothTime = .1f;

    Animator animator;
    NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed Percent", speedPercent, LocomotionAnimationSmoothTime, Time.deltaTime);
    }
}
