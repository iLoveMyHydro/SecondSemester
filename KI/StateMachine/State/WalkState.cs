using UnityEngine;

public class WalkState : State
{
    #region Constructor

    /// <summary>
    /// Constructor of the WalkState Class
    /// </summary>
    /// <param name="human"></param>
    public WalkState(NPC human) : base(human)
    {
        this.human = human;
    }

    #endregion

    #region OnStateEnter

    /// <summary>
    /// Changes the material color to blue -> So you can see when the States change 
    /// </summary>
    public override void OnStateEnter()
    {
        human.MeshRenderer.material.color = Color.blue;
    }

    #endregion

    #region OnStateUpdate

    /// <summary>
    /// adds the deltaTime to the Current Walking Time
    /// </summary>
    public override void OnStateUpdate()
    {
        human.CurrentWalkingTime += Time.deltaTime;
    }

    #endregion

    #region OnStateExit

    /// <summary>
    /// When you exit this State the Material Color will change to white 
    /// </summary>
    public override void OnStateExit()
    {
        human.MeshRenderer.material.color = Color.white;
    }

    #endregion

}
