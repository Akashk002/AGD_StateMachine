using StatePattern.Enemy;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Represents a teleporting state for an enemy of type T.
public class TeleportingState<T> : IState where T : EnemyController
{
    public EnemyController Owner { get; set; }
    private GenericStateMachine<T> stateMachine;

    public TeleportingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        // Teleport the enemy to a random position.
        TeleportToRandomPosition();

        // Transition to the CHASING state after teleporting.
        stateMachine.ChangeState(States.CHASING);
    }

    public void Update() { }

    public void OnStateExit() { }

    // Teleports the owner to a random NavMesh position within a specified radius.
    private void TeleportToRandomPosition() => Owner.Agent.Warp(GetRandomNavMeshPoint());

    // Generates a random NavMesh position within the teleporting radius.
    private Vector3 GetRandomNavMeshPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 5f + Owner.Position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 5f, NavMesh.AllAreas))
            return hit.position;
        else
            return Owner.Data.SpawnPosition;
    }
}
