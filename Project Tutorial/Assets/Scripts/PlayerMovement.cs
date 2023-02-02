using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpPower = 3f;
    Vector2 velocityVector = new Vector2();
    Rigidbody2D rb2d;
    Vector3 myRotation = new Vector3(0f, 0f, 0f);

    [SerializeField] LayerMask groundLayerMask = 0;
    [SerializeField] float groundDistanceDetection = 0.01f;
    [SerializeField] float groundDetectionPadding = 0.01f;
    Collider2D myCollider;
    Vector2 rayOrigin = new Vector2();
    bool onGround;

    public bool OnGround { get => onGround; }
    public Rigidbody2D Rb2d { get => rb2d; }

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnGround();
    }

    public void Move(float _direction)
    {
        velocityVector.Set(_direction * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = velocityVector;

        CheckLookDirection(_direction);
    }

    void CheckLookDirection(float _direction)
    {
        if (_direction == 0)
            return;

        float _rotation = 0f;
        if (_direction == 1)
            _rotation = 0f;
        else
            _rotation = 180f;

        myRotation.y = _rotation;
        transform.rotation = Quaternion.Euler(myRotation);
    }

    public void Jump()
    {
        if (!onGround)
            return;

        velocityVector.y = jumpPower;
        rb2d.velocity = velocityVector;
    }

    void CheckOnGround()
    {
        rayOrigin.Set(transform.position.x - myCollider.bounds.extents.x + groundDetectionPadding + myCollider.offset.x, transform.position.y - myCollider.bounds.extents.y - groundDistanceDetection + myCollider.offset.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, (myCollider.bounds.extents.x - groundDetectionPadding) * 2, groundLayerMask);
        if (hit)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Vector2 rayDest = rayOrigin;
            rayDest.x += (myCollider.bounds.extents.x - groundDetectionPadding) * 2;
            Gizmos.DrawLine(rayOrigin, rayDest);
        }
    }
}
