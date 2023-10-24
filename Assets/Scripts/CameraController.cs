using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CameraController : MonoBehaviour
{
    // Variable which is public so we can adjust the speed in unity
        public float speed;

    // tells the camera which position to go
    private float currentPosX;
    // the rate of change of a position of the camera
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        // Change the position of the camera
        // Vector3.SmoothDamp this is used to gradually change a vector towards the desired goal 
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);
    }
}