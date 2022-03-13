using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    void Start()
    {
        //todo this probably shouldn't be using Find by name
        GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerCameraRoot");
    }

}
