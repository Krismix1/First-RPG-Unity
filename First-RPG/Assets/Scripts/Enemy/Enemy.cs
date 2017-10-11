using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class Enemy : Interactable {

    CharacterStats myStats;
    PlayerManager playerManager;

    private void Start() {
        myStats = GetComponent<EnemyStats>();
        playerManager = PlayerManager.instance;
    }

    public override void Interact() {
        // Attack the enemy
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat != null) {
            playerCombat.Attack(myStats);
        }
    }


}
