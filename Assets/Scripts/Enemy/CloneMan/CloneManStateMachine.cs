using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatePattern.Enemy;
using StatePattern.Player;
using StatePattern.StateMachine;

public class CloneManStateMachine : GenericStateMachine<CloneManController>
{
    public CloneManStateMachine(CloneManController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(StatePattern.StateMachine.States.IDLE, new IdleState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.PATROLLING, new PatrollingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.CHASING, new ChasingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.SHOOTING, new ShootingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.TELEPORTING, new TeleportingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.ClONING, new CloningState<CloneManController>(this));
    }
}
