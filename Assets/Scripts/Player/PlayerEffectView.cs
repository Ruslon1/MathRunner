using UnityEngine;

public class PlayerEffectView : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _victoriousEffects;
    [SerializeField] private ParticleSystem[] _defeatEffects;

    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.AddedScore += OnAddedScore;
        _player.TookHealth += OnTookHealth;
    }

    private void OnDisable()
    {
        _player.AddedScore -= OnAddedScore;
        _player.TookHealth -= OnTookHealth;
    }

    private void OnTookHealth()
    {
        foreach (var defeatEffect in _defeatEffects)
            defeatEffect.Play();
    }

    private void OnAddedScore()
    {
        foreach (var victoriousEffect in _victoriousEffects)
            victoriousEffect.Play();
    }
}