using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkin : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private PlayerSkinSwitcher _skinSwitcher;
    [SerializeField] private SkinAvatar skinAvatar;
    [SerializeField] private Text _priceText;

    private Skin _skin;

    public Skin Skin => _skin;
    public int Price => _price;

    private void OnValidate()
    {
        if (_price < 0)
            _price = 0;
    }

    private void Awake()
    {
        _skin = new Skin(this);
        _priceText.text = _price.ToString();
    }

    public void Select()
    {
        _skinSwitcher.Switch(this);
    }

    public Mesh GetMesh()
    {
        return skinAvatar.SkinnedMeshRenderer.sharedMesh;
    }
}