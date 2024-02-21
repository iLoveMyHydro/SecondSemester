using System;
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

    /// <summary>
    /// Constructor of the Transition Class
    /// </summary>
    /// <param name="targetState"></param>
    /// <param name="condition"></param>
    public Transition(State targetState, Func<bool> condition)
    {
        this.targetState = targetState;
        this.condition = condition;
    }


    #endregion
}
