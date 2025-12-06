using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected bool isMoving;
    protected Animator animator;
    protected AIPawn _aiPawn;


    protected void Awake()
    {
        animator = TryGetComponent<Animator>(out var anim) ? anim : null;
        _aiPawn = TryGetComponent<AIPawn>(out var aiPawn) ? aiPawn : null;
    }

    public void MoveToPosition(Vector3 position)
    {
        if (_aiPawn != null)
        {
            _aiPawn.SetDestination(position);

        }
    }
}