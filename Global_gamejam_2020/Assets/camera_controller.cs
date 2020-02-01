using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{

    public GameObject player;
    public BoxCollider2D boundsBox;

    private Camera theCamera;

    private Vector3 minBounds;
    private Vector3 maxBounds;

    private float halfheight;
    private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfheight = theCamera.orthographicSize;
        halfWidth = halfheight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
