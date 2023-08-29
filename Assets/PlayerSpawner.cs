using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPun
{
    [SerializeField] private GameObject playerPrefab;
    private Vector3 spawnPosition = Vector3.zero;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom && playerPrefab != null)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
        }
    }
}