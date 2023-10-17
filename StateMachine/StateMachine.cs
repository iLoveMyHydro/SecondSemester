using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    #region Parameters

    [SerializeField] private State currentState;

    [SerializeField] private Dictionary<State, List<Transition>> transitions;

    #endregion

    #region Tick

    public void Tick()
    {
        State nextState = GetNextState();

        if (nextState != null) SwitchState(nextState);

        currentState.OnStateUpdate();
    }

    #endregion

    #region Constructor

    public StateMachine(State startState, Dictionary<State, List<Transition>> transitions)
    {
        this.transitions = transitions;
        this.currentState = startState;
    }

    #endregion

    #region GetNextState

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

    private void SwitchState(State targetState)
    {
        if (currentState == targetState) return;

        currentState.OnStateExit();
        targetState.OnStateEnter();

        currentState = targetState;
    }

    #endregion
}
