using System;
using UnityEngine;

public class AchievementSaver : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    public static int BestScore => PlayerPrefs.GetInt("BestScore");

    private void OnEnable()
    {
        _player.EndedLevel += TrySetBestScore;
        _player.EndedLevel += SetMoney;
    }

    private void OnDisable()
    {
        _player.EndedLevel -= TrySetBestScore;
        _player.EndedLevel -= SetMoney;
    }

    private void TrySetBestScore(int value)
    {
        if (value > BestScore)
            PlayerPrefs.SetInt("BestScore", value);
    }

    private void SetMoney(int value)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + value);
    }
}