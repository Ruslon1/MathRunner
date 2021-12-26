using System;
using UnityEngine;

public class ShopUIView : MonoBehaviour
{
    [SerializeField] private Shop _shop;

    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Canvas _shopCanvas;

    private void OnEnable()
    {
        _shop.Opened += OnShopOpened;
        _shop.Closed += OnShopClosed;
    }

    private void OnDisable()
    {
        _shop.Opened -= OnShopOpened;
        _shop.Closed -= OnShopClosed;
    }

    private void OnShopOpened()
    {
        _mainCanvas.gameObject.SetActive(false);
        _shopCanvas.gameObject.SetActive(true);
    }

    private void OnShopClosed()
    {
        _mainCanvas.gameObject.SetActive(true);
        _shopCanvas.gameObject.SetActive(false);
    }
}
