using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
       // Vector2 randomPos = new Vector2(Random.Range(minX, transform.position.y), Random.Range(maxX, transform.position.y));
        float posX = Random.Range(minX, maxX);
        PhotonNetwork.Instantiate(player.name, new Vector2(posX,transform.position.y), Quaternion.identity);
    }
}
