using UnityEngine;

public class MathTask
{
    private readonly char[] _signs = {'+', '-', '*'};
    private readonly IMathTaskUI _mathTaskUI;
    private readonly IMathTaskResult _mathTaskResult;

    public MathTask(IMathTaskUI mathTaskUI, IMathTaskResult mathTaskResult)
    {
        _mathTaskUI = mathTaskUI;
        _mathTaskResult = mathTaskResult;
    }

    public void ShowAllContext()
    {
        var task = GenerateTask();

        _mathTaskUI.EnableTaskCanvas();
        _mathTaskUI.SetTask(task);
        _mathTaskResult.ShowResults(_mathTaskUI);
    }

    public void HideAllContext()
    {        _mathTaskUI.DisableTaskCanvas();

        
    }

    private string GenerateTask()
    {
        var sign = _signs[Random.Range(0, _signs.Length)];
        var firstNumber = Random.Range(0, 10);
        var lastNumber = Random.Range(0, 10);

        _mathTaskResult.SetResult(firstNumber, sign, lastNumber);

        return $"{firstNumber} {sign} {lastNumber}";
    }
}