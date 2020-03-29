using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCam : MonoBehaviour
{
    public Transform Player;

    private void LateUpdate()
    {
        Vector3 NewPosition = Player.position;
        NewPosition.z = transform.position.z;
        transform.position = NewPosition;
    }
}
