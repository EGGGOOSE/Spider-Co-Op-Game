using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    float dirInput;
    float jumped;
    void Update()
    {
        dirInput = Input.GetAxis("Horizontal");
    }
    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();
        networkInputData.direction = dirInput;
        return networkInputData;
    }
}
