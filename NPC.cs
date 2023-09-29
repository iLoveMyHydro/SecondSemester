using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    #region Paramters

    public new string name = "Kay";

    [SerializeField] protected float money = -1f;

    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected MeshRenderer meshRenderer;

    [SerializeField] protected float walkingSpeed = 5f;

    [SerializeField] protected float runSpeed = 10f;

    [SerializeField] protected Vector3 movementDirection = Vector3.zero;

    [SerializeField] protected float currentWalkingTime = 0f;

    [SerializeField] protected float maxWalkingTime = 20f;

    [SerializeField] protected float attentionRadius = 50f;

    [SerializeField] protected LayerMask mask;

    #endregion


    #region Start

    private void Start()
    {

    }

    #endregion

    #region Update

    private void Update()
    {

    }

    #endregion
}
