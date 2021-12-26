using System;
using UnityEngine;

public class MathTaskPoint : MonoBehaviour
{
    [SerializeField] private MathTaskInitialization _taskInitialization;
    private MathTask _mathTask;

    private void Start()
    {
        _mathTask = _taskInitialization.GetMathTask();
    }

    public void ShowTask()
    {
        _mathTask.ShowAllContext();
    }
}