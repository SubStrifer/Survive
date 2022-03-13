using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //todo this is done here and in FPC but probably shouldn't
    private Inputs _input;
    private GameObject _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<Inputs>();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.fire)
        {
            //todo that shouldn't be happening the same is with jumping
            _input.fire = false;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3f, 1))
            {
                ItemPickup item;
                if(item = hit.transform.GetComponent<ItemPickup>())
                {
                    PlayerManager.Instance.inventory.Add(item.itemInfo);
                    Destroy(hit.transform.gameObject);
                }
            }
            
        }
    }
}
