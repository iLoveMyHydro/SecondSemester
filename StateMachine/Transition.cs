using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    #region Parameters

    [SerializeField] private bool condition = false;

    [SerializeField] private State targetState { get; set; } = null;

    #endregion


    #region Constructor

    public Transition(State targetState, bool condition)
    {
        this.targetState = targetState;
        this.condition = condition;
    }


    #endregion
}
