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
            photonView.RPC("ParentIcon", RpcTarget.AllBuffered, icon.GetPhotonView());
        }
    }

    [PunRPC]
    private void ParentIcon(PhotonView view)
    {
        if (view)
        {
            GameObject icon = view.gameObject;
            icon.transform.SetParent(IconLocation);
            icon.transform.localPosition = Vector3.zero;
        }
    }
}