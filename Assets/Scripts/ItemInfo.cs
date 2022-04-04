using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Survive/ItemInfo", order = 1)]
public class ItemInfo : ScriptableObject
{
    [SerializeField]
    private string _itemName;
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private ItemInfo[] _recipe;

    public ItemInfo _waterBottle;

    public string itemName => _itemName;
    public GameObject prefab => _prefab;
    public Sprite sprite => _sprite;
    public ItemInfo[] recipe => _recipe;

    public bool Use()
    {
        if (itemName == "Cranberry")
        {
            PlayerManager.Instance.GetComponentInParent<PlayerStats>().changeFood(-100);
            return true;
        }
        else if (itemName == "Blueberry")
        {
            PlayerManager.Instance.GetComponentInParent<PlayerStats>().changeFood(20);
            return true;
        }
        else if (itemName == "Water")
        {
            PlayerManager.Instance.GetComponentInParent<PlayerStats>().changeWater(25);
            PlayerManager.Instance.inventory.Add(_waterBottle);
            return true;
        }
        return false;
    }
}
