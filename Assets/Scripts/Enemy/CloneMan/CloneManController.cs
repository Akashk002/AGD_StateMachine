
using UnityEngine;
using StatePattern.Enemy;
using StatePattern.Player;
using StatePattern.StateMachine;
using StatePattern.Main;

public class CloneManController : EnemyController
{
    private CloneManStateMachine stateMachine;
    public int CloneCountLeft { get; private set; }

    public CloneManController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
    {
        SetCloneCount(enemyScriptableObject.CloneCount);
        enemyView.SetController(this);
        ChangeColor(EnemyColorType.Default);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
    }

    private void CreateStateMachine() => stateMachine = new CloneManStateMachine(this);

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    // Initiates shooting and changes the state to TELEPORTING.
    public override void Shoot()
    {
        base.Shoot();
        stateMachine.ChangeState(States.TELEPORTING);
    }

    public override void Die()
    {
      if(CloneCountLeft > 0)
        stateMachine.ChangeState(States.ClONING);

        base.Die();
    }

    // Player enters range, change to CHASING state.
    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.CHASING);
    }

    // Player exits range, change to IDLE state.
    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);

    public void SetCloneCount(int cloneCountToSet) => CloneCountLeft = cloneCountToSet;

    public void Teleport() => stateMachine.ChangeState(States.TELEPORTING);

    public void SetDefaultColor(EnemyColorType colorType) => enemyView.SetDefaultColor(colorType);

    public void ChangeColor(EnemyColorType colorType) => enemyView.ChangeColor(colorType);
}
