using NaughtyAttributes;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public GameObject prefab;

    private void Start()
    {
        ConnectToAppServer();
    }
    
    public void ConnectToAppServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    [Button("CreateOrJoin")]
    public void CreateOrJoin()
    {
        var roomOptions = new RoomOptions
        {
            MaxPlayers = 4
        };
        PhotonNetwork.JoinOrCreateRoom("Marc", roomOptions, TypedLobby.Default);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.LogError("JOINED LOBBY");
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
