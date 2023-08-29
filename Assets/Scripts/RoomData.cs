using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomData : MonoBehaviourPun
{
    public RoomInfo RoomInfo
    {
        get => _roomInfo;
        set
        {
            _roomInfo = value;
            OnRoomInfoChanged();
        }
    }

    [SerializeField] private TMP_Text RoomName;
    [SerializeField] private TMP_Text PlayerCount;

    private RoomInfo _roomInfo;

    public void Print(string roomName, int count, int maxCount)
    {
        RoomName.text = roomName;
        PlayerCount.text = count + "/" + maxCount;
    }

    private void OnRoomInfoChanged()
    {
        Print(_roomInfo.Name, _roomInfo.PlayerCount, _roomInfo.MaxPlayers);
    }
}