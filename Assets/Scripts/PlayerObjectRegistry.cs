using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class PlayerObjectRegistry
{
    static List<PlayerObject> players = new List<PlayerObject>();

    static PlayerObject CreatePlayer(BoltConnection connection)
    {
        PlayerObject player;

        player = new PlayerObject();
        player.connection = connection;

        if (player.connection != null)
        {
            player.connection.UserData = player;
        }

        players.Add(player);

        return player;
    }

    public static IEnumerable<PlayerObject> AllPlayers
    {
        get { return players; }
    }

    public static PlayerObject ServerPlayer
    {
        get { return players.Find(player => player.IsServer); }
    }

    public static PlayerObject CreateServerPlayer()
    {
        return CreatePlayer(null);
    }

    public static PlayerObject CreateClientPlayer(BoltConnection connection)
    {
        return CreatePlayer(connection);
    }

    public static PlayerObject GetPlayer(BoltConnection connection)
    {
        if (connection == null)
        {
            return ServerPlayer;
        }

        return (PlayerObject)connection.UserData;
    }
}
