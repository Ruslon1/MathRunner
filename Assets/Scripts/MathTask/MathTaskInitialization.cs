using TMPro;
using UnityEngine;

public class MathTaskInitialization : MonoBehaviour
{
    [SerializeField] private Canvas _taskCanvas;
    [SerializeField] private TMP_Text _taskText;
    [SerializeField] private TMP_Text _rightAnswer;
    [SerializeField] private TMP_Text _leftAnswer;
    [SerializeField] private Animator _canvasAnimator;

    private MathTask _mathTask;
    private IMathTaskResult _mathTaskResult;

    private void Awake() => Init();

    private void Init()
    {
        IMathTaskUI mathTaskUIView =
            new MathTaskUIView(_taskCanvas, _taskText, _rightAnswer, _leftAnswer, _canvasAnimator);
        _mathTaskResult = new MathTaskResultView();

        _mathTask = new MathTask(mathTaskUIView, _mathTaskResult);
    }

    public MathTask GetMathTask() => _mathTask;

    public IMathTaskResult GetMathTaskResultView() => _mathTaskResult;
}