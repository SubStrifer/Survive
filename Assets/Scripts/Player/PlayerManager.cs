using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject player => _player;
    public ItemContainer inventory => _player.GetComponent<ItemContainer>();

    [SerializeField]
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
