using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class PlayerObject
{
    public BoltEntity character;
    public BoltConnection connection;

    public bool IsServer
    {
        get { return connection == null; }
    }

    public bool IsClient
    {
        get { return connection != null; }
    }
    public void Spawn()
    {
        if (!character)
        {
            
            float posX = Random.Range(-9, 9);
            character = BoltNetwork.Instantiate(BoltPrefabs.Player, new Vector2(posX,0), Quaternion.identity);

            if (IsServer)
            {
                character.TakeControl();
            }
            else
            {
                character.AssignControl(connection);
            }
        }

    }
}
