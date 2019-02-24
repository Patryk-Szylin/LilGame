using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetManager : NetworkManager
{
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        PlayersLayerManager.SetPlayerLayers();
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        Debug.Log("Connected new player: " + conn.address);
    }



    public override void OnStartHost()
    {
        base.OnStartHost();
        
        


    }

    public override void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);


    }


    public override void OnStartServer()
    {
        base.OnStartServer();
        
    }
}
