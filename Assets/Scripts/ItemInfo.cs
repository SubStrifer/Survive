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

    public string itemName => _itemName;
    public GameObject prefab => _prefab;
}
