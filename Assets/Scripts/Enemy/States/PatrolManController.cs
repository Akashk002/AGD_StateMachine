using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for a patrolling enemy character.
public class PatrolManController : EnemyController
{
    private PatrolManStateMachine stateMachine;

    // Constructor initializes the controller and sets the initial state to IDLE.
    public PatrolManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        enemyView.SetController(this);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }

    private void CreateStateMachine() => stateMachine = new PatrolManStateMachine(this);

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.SHOOTING);
    }

    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);
}
