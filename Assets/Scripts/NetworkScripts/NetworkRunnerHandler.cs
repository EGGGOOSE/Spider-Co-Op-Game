using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
using System.Linq;

public class NetworkRunnerHandler : MonoBehaviour
{
    NetworkRunner networkRunner;
    private void Awake()
    {
        networkRunner = GetComponent<NetworkRunner>();
    }
    void Start()
    {
        var clienTask = InitializeNetworkRunner(networkRunner, GameMode.Shared, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
        _ = InitializeNetworkRunner(networkRunner, GameMode.Shared, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
    }
    protected virtual Task InitializeNetworkRunner(NetworkRunner runner,GameMode gameMode,NetAddress adress,SceneRef scene, Action<NetworkRunner> initialized)
    {
        /*var sceneObjectProvider = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneObjectProvider>().FirstOrDefault();
        if(sceneObjectProvider == null)
        {
            sceneObjectProvider = (INetworkSceneObjectProvider)runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }*/
        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = adress,
            Scene = scene,
            Initialized = initialized,
            SceneManager = GetComponent<NetworkSceneManagerDefault>()
        });
    }
}
