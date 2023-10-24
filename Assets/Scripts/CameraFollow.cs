using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // How fast the camera will move to the target
    public float followSpeed = 2f;
    // A transform variable called target which gives the position of the player
    public Transform target;

    private void Update()
    {
        // This will give the players x and y position
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        // Change camera position to the same as target position
        // Slerp will spherically interpolates between 2 vectors
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
