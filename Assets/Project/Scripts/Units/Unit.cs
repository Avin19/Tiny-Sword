using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected bool isMoving;
    protected Animator animator;
    protected AIPawn _aiPawn;

    protected SpriteRenderer _spriteRenderer;


    protected void Awake()
    {
        animator = TryGetComponent<Animator>(out var anim) ? anim : null;
        _aiPawn = TryGetComponent<AIPawn>(out var aiPawn) ? aiPawn : null;
        _spriteRenderer = TryGetComponent<SpriteRenderer>(out var spriteRenderer) ? spriteRenderer : null;
    }

    public void MoveToPosition(Vector3 position)
    {
        var direction = (position - transform.position).normalized;
        _spriteRenderer.flipX = direction.x < 0;
        if (_aiPawn != null)
        {
            _aiPawn.SetDestination(position);

        }
    }
}