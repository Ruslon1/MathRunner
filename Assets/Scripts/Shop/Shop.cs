using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopSkin> _listOfSkins;

    [HideInInspector] [SerializeField] private List<Skin> _boughtSkins;
    private int _money => PlayerPrefs.GetInt("Money");
    private ShopSerialization _serialization = new ShopSerialization();

    public event Action Opened;
    public event Action Closed;

    public void Open()
    {
        _boughtSkins = (List<Skin>) _serialization.Load("BoughtSkins") ?? new List<Skin>();

        Opened?.Invoke();
    }

    public void Close()
    {
        Closed?.Invoke();
    }

    public void TryBuySkin(ShopSkin shopSkin)
    {
        if (_money >= shopSkin.Price)
        {
            Debug.Log(shopSkin);
            Debug.Log(shopSkin.Skin);
            Debug.Log(_boughtSkins);
            _boughtSkins.Add(shopSkin.Skin);
            _serialization.Save("BoughtSkins", _boughtSkins);
        }
    }

    public void TrySelectSkin(ShopSkin shopSkin)
    {
        if (_boughtSkins.Any(boughtSkin => boughtSkin == shopSkin.Skin))
        {
            shopSkin.Select();
        }
    }
}