using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    #region Parameters

    [SerializeField] private State currentState;

    [SerializeField] private Dictionary<State, List<Transition>> transitions;

    #endregion

    #region Tick

    /// <summary>
    /// Checks if the State has to change
    /// </summary>
    public void Tick()
    {
        State nextState = GetNextState();

        if (nextState != null) SwitchState(nextState);

        currentState.OnStateUpdate();
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor of the StateMachine Class
    /// </summary>
    /// <param name="startState"></param>
    /// <param name="transitions"></param>
    public StateMachine(State startState, Dictionary<State, List<Transition>> transitions)
    {
        this.transitions = transitions;
        this.currentState = startState;
    }

    #endregion

    #region GetNextState

    /// <summary>
    /// Gets the next state from the transition 
    /// </summary>
    /// <returns></returns>
    private State GetNextState()
    {
        List<Transition> currentTransitions = transitions[currentState];

        foreach (Transition transition in currentTransitions)
        {
            if (transition.Condition()) return transition.TargetState;
        }

        return null;
    }

    #endregion

    #region SwitchState

    /// <summary>
    /// Switches the state if the currentState == targetState
    /// </summary>
    /// <param name="targetState"></param>
    private void SwitchState(State targetState)
    {
        if (currentState == targetState) return;

        currentState.OnStateExit();
        targetState.OnStateEnter();

        currentState = targetState;
    }

    #endregion
}
