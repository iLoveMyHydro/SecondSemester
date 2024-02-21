using UnityEngine;

public class GetMoneyState : State
{
    #region Constructor

    /// <summary>
    /// Constructor of the GetMoneyState Class
    /// </summary>
    /// <param name="npc"></param>
    public GetMoneyState(NPC npc) : base(npc) { }

    #endregion

    #region OnStateEnter

    /// <summary>
    /// When the NPC has 0 or lower Money he will get something between 1-100
    /// </summary>
    public override void OnStateEnter()
    {
        if (human.Money <= 0)
        {
            human.Money = Random.Range(1, 101);
        }
    }

    #endregion

    #region OnStateUpdate

    /// <summary>
    /// Nothing Happens here
    /// </summary>
    public override void OnStateUpdate()
    {

    }

    #endregion

    #region OnStateExit

    /// <summary>
    /// Nothing Happens here
    /// </summary>
    public override void OnStateExit()
    {

    }

    #endregion
}
