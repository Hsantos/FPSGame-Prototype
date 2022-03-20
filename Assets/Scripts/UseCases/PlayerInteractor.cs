using UnityEngine;

public class PlayerInteractor :  Interactor<IPlayerOutput> {

    public void SetInitialPosition(PlayerMovement playerMovement) {
        var posX = Random.Range(playerMovement.xPosition.Min, playerMovement.xPosition.Max);
        var posY = Random.Range(playerMovement.yPosition.Min, playerMovement.yPosition.Max);
        var posZ = Random.Range(playerMovement.zPosition.Min, playerMovement.zPosition.Max);
        var position = new Vector3(posX, posY,posZ);
        
        output.SetPosition(position);
    }

    public void LookForNearestNeighbour() {
        //findNearestNeighbour
        //output
    }
}
