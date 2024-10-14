using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private bool following = true;
    void Start()
    {
        GameEvents.playerexplode += StopFollowing;
    }

    private void OnDestroy() {
        GameEvents.playerexplode -= StopFollowing;
    }

    void Update() {
        if (following) {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }

    void StopFollowing() {
        following = false;
    }
}
