using StatePattern.Enemy;
using StatePattern.Main;
using StatePattern.StateMachine;
/// <summary>
/// State responsible for handling the cloning behavior of an enemy.
/// When entered, it creates two clones of the owner enemy.
/// </summary>
/// <typeparam name="T">Type of EnemyController this state operates on.</typeparam>
public class CloningState<T> : IState where T : EnemyController
{
    /// <summary>
    /// The enemy that owns this state. Set by the state machine.
    /// </summary>
    public EnemyController Owner { get; set; }

    /// <summary>
    /// Reference to the generic state machine managing this state.
    /// </summary>
    private GenericStateMachine<T> stateMachine;

    /// <summary>
    /// Constructor that sets the state machine reference.
    /// </summary>
    /// <param name="stateMachine">The state machine managing this state.</param>
    public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

    /// <summary>
    /// Called when the state is entered. Triggers the creation of two clones.
    /// </summary>
    public void OnStateEnter()
    {
        CreateAClone();
        CreateAClone();
    }

    /// <summary>
    /// Called every frame while this state is active. No update logic for cloning.
    /// </summary>
    public void Update() { }

    /// <summary>
    /// Called when the state is exited. No exit logic for cloning.
    /// </summary>
    public void OnStateExit() { }

    /// <summary>
    /// Creates a single clone of the owner enemy, configures its properties, and adds it to the enemy service.
    /// </summary>
    private void CreateAClone()
    {
        // Create a new clone using the owner's data
        CloneManController clonedRobot = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as CloneManController;
        // Decrement the clone count for the new clone
        clonedRobot.SetCloneCount((Owner as CloneManController).CloneCountLeft - 1);
        // Teleport the clone to a spawn location
        clonedRobot.Teleport();
        // Set the clone's color to indicate it is a clone
        clonedRobot.SetDefaultColor(EnemyColorType.Clone);
        clonedRobot.ChangeColor(EnemyColorType.Clone);
        // Register the clone with the enemy service
        GameService.Instance.EnemyService.AddEnemy(clonedRobot);
    }
}
