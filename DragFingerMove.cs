using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    public static float moveSpeed = 10f;

    public Camera MainCamera;
    private Rect ScreenBounds;
    private float objectWidth;
    private float objectHeight;


    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float cameraHeight = MainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * MainCamera.aspect;
        Vector2 cameraSize = new Vector2(cameraWidth, cameraHeight);
        Vector2 cameraCenterPosition = MainCamera.transform.position;
        Vector2 cameraBottomLeftPosition = cameraCenterPosition - (cameraSize / 2);
        ScreenBounds = new Rect(cameraBottomLeftPosition, cameraSize);
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        moveSpeed = 10f;
    }

    // Update is called once per frame
    private void Update()
    {
        

        ScreenBounds.position = (Vector2)MainCamera.transform.position - (ScreenBounds.size / 2);
    }

     void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, ScreenBounds.x + objectWidth, ScreenBounds.x + ScreenBounds.width - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, ScreenBounds.y + objectHeight, ScreenBounds.y + ScreenBounds.height - objectHeight);
        transform.position = viewPos;
    }


    private void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }
}



