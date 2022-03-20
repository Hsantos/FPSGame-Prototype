
using System;
using UnityEngine;

public class PlayerController : ControllerMonoBehaviour<PlayerInteractor, IPlayerOutput> {

    [SerializeField] private PlayerMovementScriptableObject playerMovement;
    [SerializeField] private FindNearestNeighbour findNearestNeighbour;
    [SerializeField] private LineRenderer lineRenderer;

    private bool startMovement;
    private KdTree<PlayerController> players;
    public void Initiate(KdTree<PlayerController> players) {
        this.players = players;
        interactor.SetInitialPosition(playerMovement.PlayerMovement);
        
        startMovement = true;
    }

    private void FixedUpdate() {
        if (!startMovement) {
            return;
        }
        
        interactor.UpdateMovement(playerMovement.PlayerMovement.speedMovement,
                                    transform.localPosition,
                                    playerMovement.PlayerMovement.distance);

        //Calculate distance only if we have more than one player
        if (players.Count > 1) {
            var nearestNeighbour = findNearestNeighbour.GetNext(players);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, nearestNeighbour.transform.position);
        }
    }
}
