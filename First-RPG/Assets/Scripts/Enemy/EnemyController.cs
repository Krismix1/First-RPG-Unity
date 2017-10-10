using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;

    NavMeshAgent agent;
    Transform target;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance) {
                // Attack player
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
