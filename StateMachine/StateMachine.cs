using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    #region Parameters

    [SerializeField] private State targetState = null;

    [SerializeField] private Dictionary<State, List<Transition>> transitions;

    #endregion


    #region Start

    // Start is called before the first frame update
    void Start()
    {

    }

    #endregion

    #region Update

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Constructor

    public StateMachine(State targetState, Dictionary<State, List<Transition>> transitions)
    {
        this.transitions = transitions;
        this.targetState = targetState;
    }

    #endregion

    #region GetNextState

    private State GetNextState()
    {

    }

    #endregion

    #region SwitchState

    private void SwitchState(State targetState)
    {

    }

    #endregion
}
