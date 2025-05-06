using StatePattern.Enemy;
using StatePattern.StateMachine;

public class HitmanStateMachine : GenericStateMachine<HitmanController>
{
    public HitmanStateMachine(HitmanController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(StatePattern.StateMachine.States.IDLE, new IdleState<HitmanController>(this));
        States.Add(StatePattern.StateMachine.States.PATROLLING, new PatrollingState<HitmanController>(this));
        States.Add(StatePattern.StateMachine.States.CHASING, new ChasingState<HitmanController>(this));
        States.Add(StatePattern.StateMachine.States.SHOOTING, new ShootingState<HitmanController>(this));
        States.Add(StatePattern.StateMachine.States.TELEPORTING, new TeleportingState<HitmanController>(this));
    }
}
