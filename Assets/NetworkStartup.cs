using Photon.Pun;
using Photon.Realtime;

public class NetworkStartup : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        var roomOptions = new RoomOptions
        {
            MaxPlayers = 4
        };
        PhotonNetwork.JoinOrCreateRoom(PhotonNetwork.CountOfRooms.ToString(), roomOptions, TypedLobby.Default);
    }
}