using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{   
    public Transform player1Spawnpoint;
    public Transform player2Spawnpoint;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Transform startPoint;
        if(numPlayers == 0)
        {
            startPoint = player1Spawnpoint;
        }
        else 
        {
            startPoint = player2Spawnpoint;
        }
        GameObject new_player =Instantiate(playerPrefab,startPoint.position,startPoint.rotation);
        NetworkServer.AddPlayerForConnection(conn,new_player);
    }



    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Seja bem vindo!");
    }
    public override void OnStopServer()
    {
        base.OnStopServer();
        Debug.Log("Encerrando servidor...");
    }
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("Um jogador foi conectado!");
    }
    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        Debug.Log("Um jogador foi desconectado!");
    }
}
