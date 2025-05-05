using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : IState
{
    public EnemyController Owner { get; set; }
    private IStateMachine stateMachine;

    // Initialize the current patrolling index to -1 to start from the first waypoint.
    private int currentPatrollingIndex = -1;

    // Store the destination for the enemy's patrolling behavior.
    private Vector3 destination;

    public PatrollingState(IStateMachine stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter() { }

    public void Update() { }

    public void OnStateExit() { }
}
