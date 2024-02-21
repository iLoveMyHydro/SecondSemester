using UnityEngine;

public class ChooseDirectionState : State
{
    public ChooseDirectionState(NPC human) : base(human) { }

    #region OnStateEnter

    /// <summary>
    /// Gets the destination for the NPC/Thief -> Sets the Destination between -28/28 on the X Axis and between -75/6 on the z Axis 
    /// Also sets the MaxWalkingTime between 4 to 6 
    /// </summary>
    public override void OnStateEnter()
    {
        var destination = human.Agent.SetDestination(new Vector3(Random.Range(-28, 28), 0, Random.Range(-75, 6)));
        human.CurrentWalkingTime = 0.0f;
        human.MaxWalkingTime = Random.Range(4f, 6f);
    }

    #endregion

    #region OnStateUpdate

    /// <summary>
    /// Nothing Happens here
    /// </summary>
    public override void OnStateUpdate()
    {
    }

    #endregion

    #region OnStateExit

    /// <summary>
    /// Nothing Happens here
    /// </summary>
    public override void OnStateExit()
    {
    }

    #endregion
}
