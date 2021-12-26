using System;
using UnityEngine;
using DG.Tweening;

public class PlayerMover : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sideSpeed;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isRunning", true);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }

    public void MoveRight()
    {
        var targetXPosition = transform.position.x + 1.5f;
        transform.DOMoveX(targetXPosition, _sideSpeed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        var targetXPosition = transform.position.x - 1.5f;
        transform.DOMoveX(targetXPosition, _sideSpeed * Time.deltaTime);
    }

    public void ReturnToDefaultSide()
    {
        const float targetXPosition = -3.79f;
        transform.DOMoveX(targetXPosition, _sideSpeed * Time.deltaTime);
    }
}