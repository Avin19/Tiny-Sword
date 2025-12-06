using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    [SerializeField] protected bool isMoving;
    [SerializeField] protected bool isTargeted;
    protected Animator animator;
    protected AIPawn _aiPawn;

    protected SpriteRenderer _spriteRenderer;
    protected Material originalMaterial;
    protected Material highlightMaterial;

    protected void Awake()
    {
        animator = TryGetComponent<Animator>(out var anim) ? anim : null;
        _aiPawn = TryGetComponent<AIPawn>(out var aiPawn) ? aiPawn : null;
        _spriteRenderer = TryGetComponent<SpriteRenderer>(out var spriteRenderer) ? spriteRenderer : null;
        originalMaterial = _spriteRenderer != null ? _spriteRenderer.material : null;
        highlightMaterial = Resources.Load<Material>("Material/Outline");
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

    public void Select()
    {
        HighLight();
        isTargeted = true;
    }

    public void Deselect()
    {
        UnHighLight();
        isTargeted = false;
    }

    private void HighLight()
    {
        if (_spriteRenderer != null && highlightMaterial != null)
        {
            _spriteRenderer.material = highlightMaterial;
        }
    }
    private void UnHighLight()
    {
        if (_spriteRenderer != null && originalMaterial != null)
        {
            _spriteRenderer.material = originalMaterial;
        }
    }
}