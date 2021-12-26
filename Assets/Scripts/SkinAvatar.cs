using UnityEngine;

public class SkinAvatar : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    public SkinnedMeshRenderer SkinnedMeshRenderer => _skinnedMeshRenderer;
}