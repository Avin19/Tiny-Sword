using System;
using UnityEngine;
public class HumanoidUnit : Unit
{
    protected Vector2 velocity;
    protected Vector3 lastPosition;
    public float CurrentSpeed => velocity.magnitude;


    protected void Update()
    {
        velocity = new Vector2(
            (transform.position.x - lastPosition.x) / Time.deltaTime,
            (transform.position.z - lastPosition.z) / Time.deltaTime
        );

        lastPosition = transform.position;
        isMoving = velocity.magnitude > 0.1f;

        if (animator != null)
        {

            animator.SetFloat("Speed", CurrentSpeed);
        }
    }
    void Start()
    {

        GameManager.Instance.Test();


    }
}