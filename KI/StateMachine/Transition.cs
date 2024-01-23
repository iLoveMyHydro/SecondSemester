using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    #region Parameters

    [SerializeField] private Func<bool> condition;

    [SerializeField] private State targetState;

    public Func<bool> Condition => condition;

    public State TargetState => targetState;

    #endregion


    #region Constructor

    public Transition(State targetState, Func<bool> condition)
    {
        this.targetState = targetState;
        this.condition = condition;
    }


    #endregion
}
