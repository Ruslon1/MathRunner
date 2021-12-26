using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private readonly TimeSlower _timeSlower = new TimeSlower();
    private PlayerInput _input;
    private IMovable _playerMover;

    private int _health;
    private int _score;

    public int Score => _score;
    public int Health => _health;
    
    public event Action TookHealth;
    public event Action<int> EndedLevel;
    public event Action AddedScore;
    
    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _input = GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out MathTaskPoint taskPoint))
        {
            taskPoint.ShowTask();
            _input.BeginToScanSwipe();
            StartCoroutine(_timeSlower.SlowDownTime());
        }

        if (other.gameObject.TryGetComponent(out Answer answer))
        {
            if (answer.CorrectnessAnswer())
                AddScore();
            else
                TakeHealth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Answer answer))
        {
            answer.HideTask();
            _playerMover.ReturnToDefaultSide();
        }
    }

    private void AddScore()
    {
        _score++;
        AddedScore?.Invoke();
    }

    private void TakeHealth()
    {
        TookHealth?.Invoke();
    }
    
    public void EndLevel()
    {
        Time.timeScale = 0;
        EndedLevel?.Invoke(_score);
    }
}