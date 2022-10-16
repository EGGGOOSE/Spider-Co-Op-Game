using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Bolt;
using UdpKit;
using System;

public class Menu : GlobalEventListener
{
    public InputField createInput;
    public InputField joinInput;
    public void CreateServer()
    {
        BoltLauncher.StartServer();
    }
    public void CreateClient()
    {
        BoltLauncher.StartClient();
    }
    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            string matchname = createInput.text;

            Photon.Bolt.Matchmaking.BoltMatchmaking.CreateSession(
                sessionID: matchname,
                sceneToLoad: "Game"
           );
            
        }
    }
    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        Photon.Bolt.Matchmaking.BoltMatchmaking.JoinSession(joinInput.text);
        Debug.Log("Update");
    }
}
