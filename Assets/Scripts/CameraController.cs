using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object
    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    //Makes the camera a singleton
    private static CameraController myInstance;
    public static CameraController MyInstance
    {
        get
        {
            if (myInstance == null)
            {
                myInstance = FindObjectOfType<CameraController>();
            }
            return myInstance;
        }
    }

    // Start is called before the first frame update
    // Gets the boundary values of the bound box and the width and height of the camera
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

    }

    // Update is called once per frame
    // Makes sure that the camera does not go outside of the boundaries of the boundbox
    // such that the areas outside is not visible.
    void Update()
    {
        transform.position = player.transform.position + offset;
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public Camera GetCamera()
    {
        return theCamera;
    }

}
