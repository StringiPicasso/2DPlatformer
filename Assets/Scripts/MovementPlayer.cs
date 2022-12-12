using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class MovementPlayer : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string IsRun = "IsRun";
    private const string IsJump = "IsJump";
    private const string Jump = "Jump";

    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpForce;

    private Animator _animator;
    private Rigidbody2D _rigidbodyPlayer;

    private void Start()
    {
        _rigidbodyPlayer = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        OnJump();
        var movement = Input.GetAxis(Horizontal);
        HandleAnimation(movement);

        transform.position += new Vector3(movement, 0f, 0f) * Time.deltaTime * moveSpeed;
       
        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }

    private void OnJump()
    {
        if (Input.GetButtonDown(Jump) && Mathf.Abs(_rigidbodyPlayer.velocity.y) < 0.1f)
        {
            _rigidbodyPlayer.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
    
    private void HandleAnimation(float movement)
    {
        if (Mathf.Abs(_rigidbodyPlayer.velocity.y) > 0.1f)
        {
            _animator.SetBool(IsJump, true);
        }
        else
        {
            _animator.SetBool(IsJump, false);
        }

        if (!Mathf.Approximately(0, movement))
        {
            _animator.SetBool(IsRun, true);
        }
        else
        {
            _animator.SetBool(IsRun, false);
        }
    }
}
