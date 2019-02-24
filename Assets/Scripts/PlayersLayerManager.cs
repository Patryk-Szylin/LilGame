using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayersLayerManager : MonoBehaviour
{
    public static List<PlayerMovement> m_allPlayers = new List<PlayerMovement>();
    int layerIndex = 9;




    public static void SetPlayerLayers()
    {
        for (int i =0 ; i < GameObject.FindObjectsOfType<PlayerMovement>().Length; i++)
        {
            var player = GameObject.FindObjectsOfType<PlayerMovement>()[i];
            player.GetComponent<Player>().PlayerID = i + 1;
            m_allPlayers.Add(player);
        }

        foreach (var player in m_allPlayers)
        {
            player.gameObject.layer = LayerMask.NameToLayer("PlayerDefault_" + player.GetComponent<Player>().PlayerID);
        }
    }
}
