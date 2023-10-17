using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStateMachine : MonoBehaviour
{
    #region Parameters

    [SerializeField] private List<NPC> people;

    [SerializeField] private List<Thief> thiefs;

    [SerializeField] private List<StateMachine> stateMachine = new List<StateMachine>();

    #endregion

    #region Start

    public void Start()
    {
        foreach (NPC npc in people)
        {
            CreateStateMachineNpc(npc);
        }

        foreach (Thief thief in thiefs)
        {
            CreateStateMachineThief(thief);
        }
    }

    #endregion

    #region Update

    public void Update()
    {
        foreach (StateMachine stateMachine in stateMachine)
        {
            stateMachine.Tick();
        }
    }

    #endregion

    #region CreateStateMachine

    private void CreateStateMachineNpc(NPC npc)
    {
        ChooseDirectionState chooseDirectionState = new ChooseDirectionState(npc);
        WalkState walkState = new WalkState(npc);
        GetMoneyState getMoneyState = new GetMoneyState(npc);


        Dictionary<State, List<Transition>> transitionsNpc = new Dictionary<State, List<Transition>>()
        {
            [chooseDirectionState] = new List<Transition>()
            {
                new Transition(walkState, () => true)
            },

            [walkState] = new List<Transition>()
            {
                new Transition(chooseDirectionState, () => npc.CurrentWalkingTime>= npc.MaxWalkingTime),
                new Transition(getMoneyState, () => npc.Money <= 0)
            },

            [getMoneyState] = new List<Transition>()
            {
                new Transition(chooseDirectionState, () => true)
            }
        };

        stateMachine.Add(new StateMachine(chooseDirectionState, transitionsNpc));
    }

    #endregion

    #region CreateStateMachineThief
    private void CreateStateMachineThief(Thief thief)
    {
        ChooseDirectionState chooseDirectionState = new ChooseDirectionState(thief);
        WalkState walkState = new WalkState(thief);
        StealState stealState = new StealState(thief);
        RunAwayState runAwayState = new RunAwayState(thief);

        Dictionary<State, List<Transition>> transitionsThief = new Dictionary<State, List<Transition>>()
        {
            [chooseDirectionState] = new List<Transition>()
            {
                new Transition(walkState, () => true)
            },
            [walkState] = new List<Transition>()
            {
                new Transition(chooseDirectionState, () => thief.CurrentWalkingTime >= thief.MaxWalkingTime),
                new Transition(stealState, () => CheckForNPC(thief) == true)
            },
            [stealState] = new List<Transition>()
            {
                new Transition(chooseDirectionState, () => thief.CurrentWalkingTime>= thief.MaxWalkingTime),
                new Transition(runAwayState, () => true)
            },
            [runAwayState] = new List<Transition>()
            {
                new Transition(chooseDirectionState, () => CheckForNPC(thief) == false)
            }
        };
        stateMachine.Add(new StateMachine(chooseDirectionState, transitionsThief));
    }

    #endregion

    #region CheckForNPC

    private bool CheckForNPC(Thief thief)
    {
        Collider[] colliders = Physics.OverlapSphere(thief.transform.position, thief.AttentionRadius, thief.Mask);


        if (colliders.Length > 0)
        {
            thief.Npc = colliders[0].transform;
            return true;
        }
        thief.Npc = null;
        return false;
    }

    #endregion
}
