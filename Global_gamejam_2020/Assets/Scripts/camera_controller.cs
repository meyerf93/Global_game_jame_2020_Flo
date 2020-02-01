using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{

    public GameObject player;
    public BoxCollider2D boundsBox;

    private float moveSpeed;

    private Camera theCamera;

    private Vector3 minBounds;
    private Vector3 maxBounds;

    private float halfheight;
    private float halfWidth;

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        Player player_controller = player.GetComponent<Player>();
        moveSpeed = player_controller.moveSpeed + 1;
        minBounds = boundsBox.bounds.min;
        maxBounds = boundsBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfheight = theCamera.orthographicSize;
        halfWidth = halfheight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfheight, maxBounds.y - halfheight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

}
