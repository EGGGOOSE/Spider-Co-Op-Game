using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicSpawner : MonoBehaviour
{
    public InputField createInput;
    public InputField joinInput;
    async void StartGame(GameMode mode,string sessionName)
    {
        NetworkRunner _runner = gameObject.AddComponent<NetworkRunner>();
        _runner.ProvideInput = true;

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = sessionName,
            Scene = 1,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
    }
    public void CreateGame()
    {
        StartGame(GameMode.Host, createInput.text);
    }
    public void JoinGame()
    {
        StartGame(GameMode.Client, createInput.text);
    }
}

