using System.Collections.Generic;
using UnityEngine;

public class CreateStateMachine : MonoBehaviour
{
    #region Parameters

    [SerializeField] private float leastMoney = -1f;

    [SerializeField] private List<NPC> people;

    [SerializeField] private List<Thief> thiefs;

    [SerializeField] private List<StateMachine> stateMachine = new List<StateMachine>();

    #endregion

    #region Start

    /// <summary>
    /// Goes through the List of NPC and Thiefs and creates the StateMachines for everyone
    /// </summary>
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

    /// <summary>
    /// Updates the StateMachine every "Tick"
    /// </summary>
    public void Update()
    {

        foreach (StateMachine stateMachine in stateMachine)
        {
            stateMachine.Tick();
        }
    }

    #endregion

    #region CreateStateMachineNpc

    /// <summary>
    /// Creates the StateMachine for the NPC
    /// </summary>
    /// <param name="npc"></param>
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

    /// <summary>
    /// Creates the StateMachine for the Thief
    /// </summary>
    /// <param name="thief"></param>
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

    /// <summary>
    /// Checks if in the Range of the Thief a NPC is and if he got enough Money and if it is worth the rob
    /// </summary>
    /// <param name="thief"></param>
    /// <returns></returns>
    private bool CheckForNPC(Thief thief)
    {
        Collider[] colliders = Physics.OverlapSphere(thief.transform.position, thief.AttentionRadius, thief.Mask);

        var viableNPCs = new List<Transform>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out NPC npc) && npc.Money >= leastMoney)
            {

                viableNPCs.Add(colliders[i].transform);
            }
        }
        if (viableNPCs.Count > 0)
        {
            thief.Npc = viableNPCs[0];
            return true;
        }
        thief.Npc = null;
        return false;
    }
    #endregion
}
