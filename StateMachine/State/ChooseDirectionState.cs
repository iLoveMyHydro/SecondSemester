using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDirectionState : State
{

    public ChooseDirectionState(NPC human) : base(human) { }

    #region OnStateEnter

    public override void OnStateEnter()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        human.MovementDirection = new Vector3(randomDirection.x, 0.0f, randomDirection.y);
        human.CurrentWalkingTime = 0.0f;
        human.MaxWalkingTime = Random.Range(0f, 6f);
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
