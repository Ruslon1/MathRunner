using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private MathTaskInitialization _taskInitialization;
    [SerializeField] [Range(0, 1)] private int _side;
    private IMathTaskResult _taskResult;
    private MathTask _mathTask;

    private void Start()
    {
        _taskResult = _taskInitialization.GetMathTaskResultView();
        _mathTask = _taskInitialization.GetMathTask();
    }

    public bool CorrectnessAnswer() => _taskResult.GetSideCorrectResult() == _side;

    public void HideTask() => _mathTask.HideAllContext();
}