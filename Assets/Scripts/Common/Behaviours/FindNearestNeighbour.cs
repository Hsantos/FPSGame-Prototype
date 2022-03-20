
using UnityEngine;


public class FindNearestNeighbour: MonoBehaviour
{


    public PlayerController GetNext() {
        return GameObject.Find("PlayersContainer").transform.GetChild(0).GetComponent<PlayerController>();
    }
}
