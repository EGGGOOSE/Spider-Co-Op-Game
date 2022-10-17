using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
//[BoltGlobalBehaviour]
public class SpawnPlayers : GlobalEventListener
{
    /*public float minX, maxX;
    void Start()
    {
        Debug.Log(4);
        SpawnPlayerEvent evnt = SpawnPlayerEvent.Create(GlobalTargets.AllClients);
        float posX = Random.Range(minX, maxX);
        // Vector2 randomPos = new Vector2(Random.Range(minX, transform.position.y), Random.Range(maxX, transform.position.y));       
        if (!BoltNetwork.IsServer)
        {
            BoltEntity entity = BoltNetwork.Instantiate(BoltPrefabs.Player, new Vector2(posX, transform.position.y), transform.rotation);
            Debug.Log("notServer");
            entity.TakeControl();
        }
        else
        {
            BoltEntity entity = BoltNetwork.Instantiate(BoltPrefabs.Player, new Vector2(posX, transform.position.y), transform.rotation);
            entity.TakeControl();
            Debug.Log("Server");
        }
        evnt.Send();
    }
    public void SpawnPLayer()
    {
        SpawnPlayerEvent evnt = SpawnPlayerEvent.Create();
        evnt.Send();
    }
    public override void SceneLoadLocalDone(string scene, IProtocolToken token)
    {
      
    }
        /*float posX = Random.Range(minX, maxX);
        BoltNetwork.Instantiate(BoltPrefabs.Player, new Vector2(posX, transform.position.y), transform.rotation);*/
        // SpawnPLayer();
        //}
        /* public override void SceneLoadLocalDone(string scene, IProtocolToken token)
         {
             if(BoltNetwork.IsConnected)
             SpawnPLayer();
         }*/
        /*public override void OnEvent(SpawnPlayerEvent evnt)
        {
            Debug.Log(12);
            float posX = Random.Range(minX, maxX);
            BoltEntity entity = BoltNetwork.Instantiate(BoltPrefabs.Player, new Vector2(posX, transform.position.y),Quaternion.identity);
            entity.AssignControl(evnt.RaisedBy);

        }*/

    }
