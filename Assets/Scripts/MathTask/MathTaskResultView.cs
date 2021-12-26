using UnityEngine;

public class MathTaskResultView : IMathTaskResult
{
    private int _result;
    private int _sideCorrectResult;

    public void SetResult(int firstNumber, char sign, int lastNumber)
    {
        _result = sign switch
        {
            '+' => firstNumber + lastNumber,
            '-' => firstNumber - lastNumber,
            '*' => firstNumber * lastNumber,
            _ => _result
        };
    }

    public void ShowResults(IMathTaskUI mathTaskUI)
    {
        _sideCorrectResult = Random.Range(0, 1);
        var incorrectResult = _result + Random.Range(-3, 5);
        
        if (incorrectResult - _result == 0)
            incorrectResult++;

        if (_sideCorrectResult == 1)
        {
            mathTaskUI.SetLeftAnswer(incorrectResult.ToString());
            mathTaskUI.SetRightAnswer(_result.ToString());
        }
        else
        {
            mathTaskUI.SetLeftAnswer(_result.ToString());
            mathTaskUI.SetRightAnswer(incorrectResult.ToString());
        }
    }

    public int GetSideCorrectResult() => _sideCorrectResult;
}

public interface IMathTaskResult
{
    void ShowResults(IMathTaskUI mathTaskUI);
    void SetResult(int firstNumber, char sign, int lastNumber);
    int GetSideCorrectResult();
}