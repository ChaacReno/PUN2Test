using Photon.Pun;
using UnityEngine;

public class Net_RoomPlayerListHandler : MonoBehaviourPunCallbacks
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
        Debug.LogError($"playerCount: {playerCount} | iconCount: {iconCount}");


        var countToInstantiate = playerCount - iconCount;

        for (int i = 0; i < countToInstantiate; i++)
        {
            var icon = PhotonNetwork.Instantiate(Icon.name, Vector3.zero, Quaternion.identity);
            icon.transform.parent = IconLocation;
            icon.transform.localPosition = Vector3.zero;
        }
    }
}