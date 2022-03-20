using UnityEngine;

public class PlayerPresenter : MonoBehaviour, IPlayerOutput {

    public void SetPosition(Vector3 pos) {
        transform.localPosition = pos;
    }
}
