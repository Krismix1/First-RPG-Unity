using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    public float attackDelay = .6f;
    public float attackSpeed = 1f;

    // Create a delegate with void return type and no parameters
    public event System.Action OnAttack;

    private float attackCooldown = 0f;
    private CharacterStats myStats;


	void Start () {
        myStats = GetComponent<CharacterStats>();
	}
	

	void Update () {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats target) {
        if(attackCooldown <= 0) {
            StartCoroutine(DoDamage(target, attackDelay));
            if(OnAttack != null) {
                OnAttack();
            }
            attackCooldown = 1 / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats target, float delay) {
        yield return new WaitForSeconds(delay);
        if (target != null) {
            target.TakeDamage(myStats.damage.GetValue());
        }
    }
}
