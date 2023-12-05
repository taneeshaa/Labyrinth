using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public GameObject CustomizationMenu;
    public Transform spawnPoint;
    private GameObject playerGameObject;

    private void Start()
    {
    }
    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(PlayerPrefab, spawnPoint.position, spawnPoint.rotation, player);
        }

        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(playerGameObject);
        CustomizationMenu.SetActive(true);
    }
}
