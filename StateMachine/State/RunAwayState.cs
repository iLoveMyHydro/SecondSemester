using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayState : State
{
    #region Constructor 

    public RunAwayState(Thief thief) : base(thief)
    {
        this.thief = thief;
    }

    #endregion

    #region OnStateEnter

    public override void OnStateEnter()
    {
        thief.MeshRenderer.material.color = Color.cyan;
    }

    #endregion

    #region OnStateUpdate

    public override void OnStateUpdate()
    {
        thief.Agent.destination = thief.transform.position +
            (thief.transform.position - thief.Npc.position).normalized;
    }

    #endregion

    #region OnStateExit

    public override void OnStateExit()
    {
        thief.MeshRenderer.material.color = Color.white;
    }

    #endregion
}
