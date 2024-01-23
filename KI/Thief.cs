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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position + Vector3.up * 1.5f, 0.25f);
    }
}
