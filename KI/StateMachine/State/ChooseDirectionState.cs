using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDirectionState : State
{

    public ChooseDirectionState(NPC human) : base(human) { }

    #region OnStateEnter

    public override void OnStateEnter()
    {
        var destination = human.Agent.SetDestination(new Vector3(Random.Range(-28, 28), 0, Random.Range(-75, 6)));
        human.CurrentWalkingTime = 0.0f;
        human.MaxWalkingTime = Random.Range(4f, 6f);
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
