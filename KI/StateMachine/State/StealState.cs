using UnityEngine;

public class StealState : State
{
    #region Constructor

    /// <summary>
    /// Constructor for the StealState Class
    /// </summary>
    /// <param name="thief"></param>
    public StealState(Thief thief) : base(thief)
    {
        this.thief = thief;
    }

    #endregion

    #region OnStateEnter

    /// <summary>
    /// Changes the Color to red when enter this state
    /// Gets the Component of the NPC
    /// thief robs the Money from the NPC 
    /// NPCs money will be 0
    /// </summary>
    public override void OnStateEnter()
    {
        thief.MeshRenderer.material.color = Color.red;
        var npc = thief.Npc.GetComponent<NPC>();
        thief.StolenMoney += npc.Money;
        npc.Money = 0;
    }

    #endregion

    #region OnStateUpdate

    /// <summary>
    /// Nothing happens in here
    /// </summary>
    public override void OnStateUpdate()
    {

    }

    #endregion

    #region OnStateExit

    /// <summary>
    /// Changes the color back to white
    /// </summary>
    public override void OnStateExit()
    {
        thief.MeshRenderer.material.color = Color.white;
    }

    #endregion
}
