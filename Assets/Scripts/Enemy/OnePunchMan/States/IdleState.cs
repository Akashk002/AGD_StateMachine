
using StatePattern.Enemy;
using UnityEngine;

// Define a state where the character is idle.
public class IdleState : IState
{
    public OnePunchManController Owner { get; set; }
    private OnePunchManStateMachine stateMachine;
    private float timer;

    public IdleState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() => ResetTimer();

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            stateMachine.ChangeState(OnePunchManStates.ROTATING);
    }

    public void OnStateExit() => timer = 0;

    private void ResetTimer() => timer = Owner.Data.IdleTime;
}