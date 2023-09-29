using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    #region Parameters

    [SerializeField] protected NPC npc;

    #endregion


    #region Constructor

    public State(NPC npc)
    {
        this.npc = npc;
    }

    #endregion

    #region OnStateEnter

    public virtual void OnStateEnter()
    {

    }

    #endregion

    #region OnStateUpdate

    public virtual void OnStateUpdate()
    {

    }


    #endregion

    #region OnStateExit

    public virtual void OnStateExit()
    {

    }

    #endregion
}
