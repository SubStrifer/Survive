using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject player => _player;
    public ItemContainer inventory => _player.GetComponent<ItemContainer>();
    public bool cursorLocked => Cursor.lockState == CursorLockMode.Locked;
    public GameObject inventoryUI;

    [SerializeField]
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        LockCursor(true);
        inventory.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            LockCursor(!inventoryUI.activeSelf);
        }
    }

    public void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}
