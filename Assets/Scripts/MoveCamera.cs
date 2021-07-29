using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make the camera follow the player
public class MoveCamera : MonoBehaviour
{

    public Transform PlayerPrefab;

    // Update is called once per frame
    void Update()
    {
        

        transform.position = new Vector3(PlayerPrefab.position.x, 0, -10);
    }
}
