using TMPro;
using UnityEngine;

public class MathTaskUIView : IMathTaskUI
{
    private readonly Canvas _taskCanvas;
    private readonly TMP_Text _taskText;
    private readonly TMP_Text _rightAnswer;
    private readonly TMP_Text _leftAnswer;
    private readonly Animator _animator;

    public MathTaskUIView(Canvas taskCanvas, TMP_Text taskText, TMP_Text rightAnswer, TMP_Text leftAnswer, Animator animator)
    {
        _taskCanvas = taskCanvas;
        _taskText = taskText;
        _rightAnswer = rightAnswer;
        _leftAnswer = leftAnswer;
        _animator = animator;
    }

    public void EnableTaskCanvas()
    {
        _taskCanvas.gameObject.SetActive(true);
        _animator.Play("EnableCanvas");
    }

    public void SetTask(string context)
    {
        _taskText.text = context;
    }

    public void SetRightAnswer(string context)
    {
        _rightAnswer.text = context;
    }

    public void SetLeftAnswer(string context)
    {
        _leftAnswer.text = context;
    }

    public void DisableTaskCanvas()
    {
        _animator.SetTrigger("DisableCanvas");
        
        _taskCanvas.gameObject.SetActive(false);
    }
}

public interface IMathTaskUI
{
    void EnableTaskCanvas();
    void SetTask(string context);
    void SetRightAnswer(string context);
    void SetLeftAnswer(string context);
    void DisableTaskCanvas();
}