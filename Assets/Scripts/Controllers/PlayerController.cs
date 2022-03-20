
using UnityEngine;

public class PlayerController : ControllerMonoBehaviour<PlayerInteractor, IPlayerOutput> {

    [SerializeField] private PlayerMovementScriptableObject playerMovement;
    [SerializeField] private FindNearestNeighbour findNearestNeighbour;
    [SerializeField] private LineRenderer lineRenderer;
    
    public void Initiate() {
        interactor.SetInitialPosition(playerMovement.PlayerMovement);


        var nearestNeighbour = findNearestNeighbour.GetNext();
        lineRenderer.SetPosition(0, new Vector3(transform.localPosition.x,
            transform.localPosition.y,
            transform.localPosition.z));
        
        lineRenderer.SetPosition(1, new Vector3(nearestNeighbour.transform.localPosition.x,
            nearestNeighbour.transform.localPosition.y,
            nearestNeighbour.transform.localPosition.z));
    }
}
