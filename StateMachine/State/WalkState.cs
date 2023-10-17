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
        human.Agent.destination = human.transform.position + human.MovementDirection;
        human.CurrentWalkingTime += Time.deltaTime;

        // human.Agent.SetDestination(new Vector3(Random.Range(-14, 15), 0, Random.Range(-14, 15)));

    }

    #endregion

    #region OnStateExit

    public override void OnStateExit()
    {
        human.MeshRenderer.material.color = Color.white;
    }

    #endregion

}
