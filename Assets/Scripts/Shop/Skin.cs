using System;

[Serializable]
public class Skin
{
    private readonly ShopSkin _shopSkin;

    public Skin(ShopSkin shopSkin)
    {
        _shopSkin = shopSkin;
    }

    public ShopSkin ShopSkin => _shopSkin;
}