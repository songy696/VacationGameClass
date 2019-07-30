using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    public Transform target1;
    public Transform target2;

    public GameObject player1;
    public GameObject player2;

    public Camera cameraX;

    // How many units should we keep from the players
    private float zoomFactor = 2f;
    float followTimeDelta = 0.8f;

    float minZoomIn = 7;
    float maxZoomOut = 12;

    private Rigidbody rb;

    public void Start()
    {
    }

    public void Update()
    {
        CameraRestriction();
    }

    public void CameraRestriction() {
        if (player1.gameObject.activeInHierarchy == true && player2.gameObject.activeInHierarchy == true)
        {
            //Midpoint we're after
            Vector3 midpoint = (target1.position + target2.position) / 2f;
            midpoint.z = -10;
            //Vector3 midpoint = new Vector3((target1.position.x + target2.position.x) / 2f, (target1.position.y + target2.position.y) / 2f, -10);

            // Distance between objects
            float distance = Mathf.Clamp(Vector3.Distance(target1.position, target2.position), minZoomIn, maxZoomOut);

            /*float playerX = mPlayerTransform.position.x;
                //Vector3 currentPos = transform.position; // you have to use vector3 inorder to function the transform.... if you dont not allowed to fuction it only reading the script
                Vector3 currentVel = rb.velocity;
                //currentPos.x = playerX;
                currentVel.x = playerX - currentVel.x;       // this is using velocity instead of transform
                //transform.position = currentPos;
                rb.velocity = currentVel;
             */

            // Move camera a certain distance
            Vector3 cameraDestination = midpoint - cameraX.transform.forward * distance * zoomFactor;


            //if (cameraX.orthographicSize < 15)
            //{
            //    cameraX.orthographicSize += .1f;
            //}
            //else if (cameraX.orthographicSize > 7)
            //{
            //    cameraX.orthographicSize -= .1f;
            //}

            // Adjust ortho size 
            if (cameraX.orthographic)
            {
                // The camera's forward vector is irrelevant, only this size will matter
                cameraX.orthographicSize = distance;
                distance = cameraX.orthographicSize;

                //if (cameraX.orthographicSize < maxZoomOut)
                //{
                //    cameraX.orthographicSize += .01f;
                //    cameraX.orthographicSize = distance;
                //    distance = cameraX.orthographicSize;
                //}
                //else if (cameraX.orthographicSize > minZoomIn)
                //{
                //    cameraX.orthographicSize -= .01f;
                //    cameraX.orthographicSize = distance;
                //    distance = cameraX.orthographicSize;
                //}
            }

            // You specified to use MoveTowards instead of Slerp
            cameraX.transform.position = Vector3.Slerp(cameraX.transform.position, cameraDestination, followTimeDelta);

            // Snap when close enough to prevent annoying slerp behavior
            if ((cameraDestination - cameraX.transform.position).magnitude <= 0.05f)
            {
                cameraX.transform.position = cameraDestination;
            }

        }
        else if (player1.gameObject.activeInHierarchy == false && player2.gameObject.activeInHierarchy == true)
        {
            cameraX.transform.position = new Vector3(target2.position.x, target2.position.y, -10);
            if (cameraX.orthographicSize > 6)
            {
                cameraX.orthographicSize -= .1f;
                cameraX.orthographicSize = Mathf.Clamp(cameraX.orthographicSize, 6, 100);
            }

        }
        else if (player1.gameObject.activeInHierarchy == true && player2.gameObject.activeInHierarchy == false)
        {
            cameraX.transform.position = new Vector3(target1.position.x, target1.position.y, -10);
            if (cameraX.orthographicSize > 6)
            {
                cameraX.orthographicSize -= .1f;
                cameraX.orthographicSize = Mathf.Clamp(cameraX.orthographicSize, 6, 100);
            }
        }
    }
}
