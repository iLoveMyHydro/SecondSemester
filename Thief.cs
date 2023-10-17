using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : NPC
{
    #region Parameters

    [SerializeField] private float stolenMoney = -1f;

    private Transform npc;

    public float StolenMoney { get => stolenMoney; set => stolenMoney = value; }

    public Transform Npc { get => npc; set => npc = value; }

    #endregion
}
