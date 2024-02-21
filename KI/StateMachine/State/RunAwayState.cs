using UnityEngine;

public class RunAwayState : State
{
    #region Constructor 

    /// <summary>
    /// Constructor of the RunAwayState Class
    /// </summary>
    /// <param name="thief"></param>
    public RunAwayState(Thief thief) : base(thief)
    {
        this.thief = thief;
    }

    #endregion

    #region OnStateEnter

    /// <summary>
    /// Changes the Color to Cyan if the State is entered
    /// </summary>
    public override void OnStateEnter()
    {
        thief.MeshRenderer.material.color = Color.cyan;
    }

    #endregion

    #region OnStateUpdate

    /// <summary>
    /// The Thief will go away from the NPC he stole money 
    /// </summary>
    public override void OnStateUpdate()
    {
        thief.Agent.destination = thief.transform.position +
            (thief.transform.position - thief.Npc.position).normalized;
    }

    #endregion

    #region OnStateExit

    /// <summary>
    /// Changes the Color back to white
    /// </summary>
    public override void OnStateExit()
    {
        thief.MeshRenderer.material.color = Color.white;
    }

    #endregion
}
