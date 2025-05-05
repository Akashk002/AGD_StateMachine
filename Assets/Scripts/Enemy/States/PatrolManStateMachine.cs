using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManStateMachine : IStateMachine
{
    private PatrolManController Owner;
    private IState currentState;
    protected Dictionary<States, IState> States = new Dictionary<States, IState>();

    public PatrolManStateMachine(PatrolManController Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(global::States.IDLE, new IdleState(this));
        States.Add(global::States.PATROLLING, new PatrollingState(this));
        States.Add(global::States.CHASING, new ChasingState(this));
        States.Add(global::States.SHOOTING, new ShootingState(this));
    }

    private void SetOwner()
    {
        foreach (IState state in States.Values)
        {
            state.Owner = Owner;
        }
    }

    public void Update() => currentState?.Update();

    protected void ChangeState(IState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(States newState) => ChangeState(States[newState]);
}
