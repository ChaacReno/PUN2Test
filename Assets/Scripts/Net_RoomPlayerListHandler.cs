using Photon.Pun;
using UnityEngine;

public class RoomPlayerListHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject Icon;
    [SerializeField] private Transform IconLocation;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PrintIcons();
    }

    private void PrintIcons()
    {
        var playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        var iconCount = IconLocation.childCount;

        var countToInstantiate = playerCount - iconCount;

        for (int i = 0; i < countToInstantiate; i++)
        {
            Instantiate(Icon, IconLocation);
        }
    }
}