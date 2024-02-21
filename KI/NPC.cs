using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MeshRenderer), typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{
    #region Parameters


    [SerializeField] private float money = 1f;

    private NavMeshAgent agent;

    private MeshRenderer meshRenderer;

    [SerializeField] private float walkingSpeed = 5f;

    private Vector3 movementDirection = Vector3.zero;

    [SerializeField] private float currentWalkingTime = 0f;

    [SerializeField] private float maxWalkingTime = 0f;

    [SerializeField] private float attentionRadius = 5f;

    [SerializeField] private LayerMask mask;

    public float Money { get => money; set => money = value; }
    public NavMeshAgent Agent { get => agent; }
    public MeshRenderer MeshRenderer { get => meshRenderer; }
    public float WalkingSpeed { get => walkingSpeed; }
    public Vector3 MovementDirection { get => movementDirection; set => movementDirection = value; }
    public float CurrentWalkingTime { get => currentWalkingTime; set => currentWalkingTime = value; }
    public float MaxWalkingTime { get => maxWalkingTime; set => maxWalkingTime = value; }
    public float AttentionRadius { get => attentionRadius; }
    public LayerMask Mask { get => mask; }

    #endregion


    #region Start

    /// <summary>
    /// Gets the MeshRenderer and the NavMeshAgent for everyone
    /// </summary>
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    #endregion
}
