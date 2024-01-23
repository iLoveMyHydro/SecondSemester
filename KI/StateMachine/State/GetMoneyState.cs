using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoneyState : State
{
    #region Constructor

    public GetMoneyState(NPC npc) : base(npc) { }

    #endregion

    #region OnStateEnter

    public override void OnStateEnter()
    {
        if (human.Money <= 0)
        {
            human.Money = Random.Range(1, 101);
        }
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

    }

    #endregion
}
