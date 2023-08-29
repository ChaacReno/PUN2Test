using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomData : MonoBehaviourPun
{
    public int SceneId { get; set; } = 13; // TODO: Change for scene data

    private RoomInfo RoomInfo
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

    public void UpdateRoomInfo(int sceneId, RoomInfo roomInfo)
    {
        SceneId = sceneId;
        _roomInfo = roomInfo;
    }

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