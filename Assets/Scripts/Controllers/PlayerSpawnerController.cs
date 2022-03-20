using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : ControllerMonoBehaviour<PlayerInteractor, IPlayerOutput>, IObserver<int> {
    [SerializeField] private ObjectPoolingMonoBehaviour polling;
    [SerializeField] private HudController hudController;


    private readonly List<PlayerController> players = new List<PlayerController>();
    void Start() {
        hudController.Initiate(this);
    }


    private void SpawnPlayers(int totalPlayers) {
        for (var i = 0; i < totalPlayers; i++) {
            var player = polling.GetObjectInThePool().GetComponent<PlayerController>();
            player.Initiate();
            players.Add(player);
        }
    }

    public void OnNotify(int item) {
        DeletePlayers();
        SpawnPlayers(item);
    }

    private void DeletePlayers() {
        players.ForEach(p => {
            polling.ReturnObjectInThePool(p.gameObject);
        });
        
        players.Clear();
    }
}
