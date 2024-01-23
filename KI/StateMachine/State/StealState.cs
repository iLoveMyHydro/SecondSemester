using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealState : State
{

    #region Constructor

    public StealState(Thief thief) : base(thief)
    {
        this.thief = thief;
    }

    #endregion

    #region OnStateEnter

    public override void OnStateEnter()
    {
        thief.MeshRenderer.material.color = Color.red;
        var npc = thief.Npc.GetComponent<NPC>();
        thief.StolenMoney += npc.Money;
        npc.Money = 0;
    }

    #endregion

    #region OnStateUpdate

    public override void OnStateUpdate()
    {

    }

    #endregion

    #region OnStateExit

    public override void OnStateExit()
    {
        thief.MeshRenderer.material.color = Color.white;
    }

    #endregion

}
