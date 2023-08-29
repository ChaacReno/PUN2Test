using NaughtyAttributes;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public GameObject prefab;
    [Button("Connect")]
    public void ConnectToLobby()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        var roomOptions = new RoomOptions
        {
            IsVisible = false,
            MaxPlayers = 4
        };
        PhotonNetwork.JoinOrCreateRoom("Marc", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom was called by PUN.");
    }

    [Button("SpawnStuff")]
    public void SpawnStuff()
    {
        PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity);
    }
}
