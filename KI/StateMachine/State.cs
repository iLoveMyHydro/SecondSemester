using UnityEngine;

public abstract class State
{
    #region Parameters

    [SerializeField] protected NPC human;

    [SerializeField] protected Thief thief;

    private const string TextNoExit = "There is no exit in this state!";

    #endregion


    #region Constructor

    /// <summary>
    /// Constructor for the State Class
    /// </summary>
    /// <param name="human"></param>
    protected State(NPC human)
    {
        this.human = human;
    }


    #endregion

    #region OnStateEnter

    /// <summary>
    /// On State Enter Method -> Will be coded in the inherited classes
    /// </summary>
    public virtual void OnStateEnter()
    {

    }

    #endregion

    #region OnStateUpdate

    /// <summary>
    /// Updates the States -> Will be coded in the inherited classes
    /// </summary>
    public virtual void OnStateUpdate()
    {

    }


    #endregion

    #region OnStateExit

    /// <summary>
    /// Exits the States -> Will be coded in the inherited classes
    /// </summary>
    public virtual void OnStateExit()
    {
        Debug.LogWarning(TextNoExit);
    }

    #endregion
}
