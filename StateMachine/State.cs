using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    #region Parameters

    [SerializeField] protected NPC human;

    [SerializeField] protected Thief thief;

    private const string TextNoExit = "There is no exit in this state!";

    #endregion


    #region Constructor

    protected State(NPC human)
    {
        this.human = human;
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
        Debug.LogWarning(TextNoExit);
    }

    #endregion
}
