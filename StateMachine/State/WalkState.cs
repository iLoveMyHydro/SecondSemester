using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    #region Constructor

    public WalkState(NPC human) : base(human)
    {
        this.human = human;
    }

    #endregion

    #region OnStateEnter

    public override void OnStateEnter()
    {
        human.MeshRenderer.material.color = Color.blue;
    }

    #endregion

    #region OnStateUpdate

    public override void OnStateUpdate()
    {
        human.CurrentWalkingTime += Time.deltaTime;
    }

    #endregion

    #region OnStateExit

    public override void OnStateExit()
    {
        human.MeshRenderer.material.color = Color.white;
    }

    #endregion

}
