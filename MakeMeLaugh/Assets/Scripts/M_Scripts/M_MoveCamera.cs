using UnityEngine;

public class M_MoveCamera : MonoBehaviour {

    public Transform player;

    void Update() {
        transform.position = player.transform.position;
    }
}

