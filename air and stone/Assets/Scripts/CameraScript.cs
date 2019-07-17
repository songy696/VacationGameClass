using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    public Transform target1;
    public Transform target2;

    public Camera cameraX;

    private float xThreshold = 3.0f;
    private float yThreshold = 3.0f;

    private float zoomFactor = 1.5f;

    public void Start()
    {

    }

    public void Update()
    {
        // How many units should we keep from the players
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (target1.position + target2.position) / 2f;
        midpoint.z = -10;
        // Distance between objects
        float distance = Vector3.Distance(target1.position, target2.position);

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cameraX.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cameraX.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cameraX.orthographicSize = distance;
        }

        // You specified to use MoveTowards instead of Slerp
        cameraX.transform.position = Vector3.Slerp(cameraX.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cameraX.transform.position).magnitude <= 0.05f)
        {
            cameraX.transform.position = cameraDestination;
        }

    }
}
