using UnityEngine;

public class PlayerSkinSwitcher : MonoBehaviour, ISkinSwitcher
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    
    public void Switch(ShopSkin shopSkin)
    {
        _skinnedMeshRenderer.sharedMesh = shopSkin.GetMesh();
    }
}