using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPun
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnRange;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom && playerPrefab != null)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-spawnRange, spawnRange), 0,
                Random.Range(-spawnRange, spawnRange));
            Vector3 finalSpawnPosition = spawnPosition + randomOffset;
            PhotonNetwork.Instantiate(playerPrefab.name, finalSpawnPosition, Quaternion.identity);
        }
    }
}