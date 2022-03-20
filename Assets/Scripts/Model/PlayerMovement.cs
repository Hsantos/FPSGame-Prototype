using System;
using UnityEngine;

[Serializable]
public class PlayerMovement {
    
    [Header("Minimum and Maximum for Player Movement in X direction")]
    [Space(10f)]
    public LimitPosition xPosition;
    
    [Header("Minimum and Maximum for Player Movement in Y direction")]
    [Space(10f)]
    public LimitPosition yPosition;
    
    [Header("Minimum and Maximum for Player Movement in Z direction")]
    [Space(10f)]
    public LimitPosition zPosition;


    [Serializable]
    public struct LimitPosition {
        public float Min;
        public float Max;
    }
}


