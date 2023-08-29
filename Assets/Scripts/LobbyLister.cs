using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class LobbyLister : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject lobbyListContainer;
    [SerializeField] private GameObject lobbyItem;
    public List<LobbyInfo> availableLobbies = new List<LobbyInfo>();

    public class LobbyInfo
    {
        public string LobbyName;
        public int CurrentPlayerCount;
        public int MaxPlayerCount;
        public bool isDisplayed;

        public LobbyInfo(RoomInfo roomInfo)
        {
            LobbyName = roomInfo.Name;
            CurrentPlayerCount = roomInfo.PlayerCount;
            MaxPlayerCount = roomInfo.MaxPlayers;
        }

        public override string ToString()
        {
            return $"{LobbyName} ({CurrentPlayerCount}/{MaxPlayerCount})";
        }
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        FetchLobbies();
    }

    public override void OnConnectedToMaster()
    {
        FetchLobbies();
    }

    public void FetchLobbies()
    {
        PhotonNetwork.JoinLobby();
        PrintLobbies();
    }

    public void PrintLobbies()
    {
        foreach (var lobby in availableLobbies)
        {
            if (lobby.isDisplayed) return;
            LobbyItem item = Instantiate(lobbyItem, lobbyListContainer.transform).GetComponent<LobbyItem>();
            item.SetLobbyData(lobby.LobbyName, lobby.CurrentPlayerCount, lobby.MaxPlayerCount);
            lobby.isDisplayed = true;
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        availableLobbies.Clear();

        foreach (RoomInfo room in roomList)
        {
            if (room.RemovedFromList) continue;

            LobbyInfo lobbyInfo = new LobbyInfo(room);
            availableLobbies.Add(lobbyInfo);
            PrintLobbies();
        }
    }
}