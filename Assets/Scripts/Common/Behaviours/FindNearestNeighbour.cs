
using System.Linq;
using UnityEngine;


public class FindNearestNeighbour: MonoBehaviour
{
    public PlayerController GetNext(KdTree<PlayerController> players) {
        return players.FindClosest(transform.position);
    }
}
