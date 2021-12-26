using TMPro;
using UnityEngine;

public class PlayerUIView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private Canvas _endLevelCanvas;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _currentScoreText;

    private void OnEnable()
    {
        _player.AddedScore += OnAddedScore;
        _player.TookHealth += OnTookHealth;
        _player.EndedLevel += OnLevelEnded;
    }

    private void OnDisable()
    {
        _player.AddedScore -= OnAddedScore;
        _player.TookHealth -= OnTookHealth;
        _player.EndedLevel -= OnLevelEnded;
    }

    private void OnLevelEnded(int score)
    {
        _score.gameObject.SetActive(false);
        _endLevelCanvas.gameObject.SetActive(true);
        _currentScoreText.text = score.ToString();
        _bestScoreText.text = AchievementSaver.BestScore.ToString();
    }

    private void OnTookHealth()
    {
    }

    private void OnAddedScore()
    {
        _score.text = _player.Score.ToString();
    }
}