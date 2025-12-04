using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected bool isMoving;
    protected Animator animator;


    protected void Awake()
    {
        animator = TryGetComponent<Animator>(out var anim) ? anim : null;
    }
}