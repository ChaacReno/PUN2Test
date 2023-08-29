using TMPro;
using UnityEngine;

public class LobbyItem : MonoBehaviour
{
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text playerCountLabel;

    public void SetLobbyData(string name, int playerCount, int maxPlayers)
    {
        nameLabel.text = name;
        playerCountLabel.text = playerCount + "/" + maxPlayers;
    }
}