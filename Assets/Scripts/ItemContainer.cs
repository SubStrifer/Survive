using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public ReadOnlyCollection<ItemInfo> items => _items.AsReadOnly();

    public event EventHandler<EventArgs<ItemInfo>> ItemAdded;
    public event EventHandler<EventArgs<ItemInfo>> ItemRemoved;

    private List<ItemInfo> _items;

    void Start()
    {
        _items = new List<ItemInfo>();
    }

    public void Add(ItemInfo item)
    {
        _items.Add(item);
        ItemAdded?.Invoke(this, new EventArgs<ItemInfo>(item));
    }

    public bool Remove(ItemInfo item)
    {
        ItemRemoved?.Invoke(this, new EventArgs<ItemInfo>(item));
        return _items.Remove(item);
    }

    public bool Remove(string item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].itemName == item)
            {
                return Remove(_items[i]);
            }
        }
        return false;
    }

    public void Clear()
    {
        _items.Clear();
    }

}