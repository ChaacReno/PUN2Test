using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] private string sceneToLoad;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void CreateRoom()
    {
        var roomOptions = new RoomOptions
        {
            MaxPlayers = 4
        };
        PhotonNetwork.JoinOrCreateRoom(PhotonNetwork.CountOfRooms.ToString(), roomOptions, TypedLobby.Default);
    }

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel(sceneToLoad);
    }
}