using Photon.Pun;
using UnityEngine;

public class Net_RoomPlayerListHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject lobbyListContainer;
    [SerializeField] private GameObject playerListContainer;
    [SerializeField] private GameObject Icon;
    [SerializeField] private Transform IconLocation;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        lobbyListContainer.SetActive(false);
        playerListContainer.SetActive(true);
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
            photonView.RPC("ParentIcon", RpcTarget.AllBuffered, icon.GetPhotonView().ViewID);
        }
    }

    [PunRPC]
    private void ParentIcon(int viewID)
    {
        PhotonView targetIconView = PhotonView.Find(viewID);
        if (targetIconView)
        {
            GameObject icon = targetIconView.gameObject;
            icon.transform.SetParent(IconLocation);
            icon.transform.localPosition = Vector3.zero;
        }
    }
}