using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;

    NavMeshAgent agent;
    Transform target;
    CharacterCombat combat;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        combat = GetComponent<CharacterCombat>();
	}
	

	void Update () {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance) {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if(targetStats != null) {
                    combat.Attack(targetStats);
                }
                FaceTarget();
            }
        }
	}

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
