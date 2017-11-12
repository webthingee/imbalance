using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMovement : MonoBehaviour
{
    public bool isRight;
    public float yBuffer = 0.5f;
    public float xBuffer = 0.5f;
    public GameObject handleImage; // for rotation needs

    private GameManager gm;
    private float gearStart;
    private float moveSpeed;
    private float mobileMoveSpeed;
    private float rotationSpeed;
    private float spinSensitivity;
    //private float isMovingX = 0;
    private float isMovingY = 0;

    void Awake ()
    {
        gm = FindObjectOfType<GameManager>();
        gearStart = gm.gearStartPosition;
        moveSpeed = gm.GearMoveSpeed;
        mobileMoveSpeed = gm.MobileMoveSpeed;
        rotationSpeed = gm.GearRotationSpeed;
        spinSensitivity = gm.GearSpinSensitivity;

        // if (isRight)
        // {
            transform.position = new Vector3 (transform.position.x, gearStart, transform.position.z);
        // }
    }

    void FixedUpdate ()
    {
        // Moving the container, which is selected as right or not
        if (isRight)
        {
            MoveRightHandle();
        }
        else
        {
            MoveLeftHandle();
        }
        // Touch Input
        TouchControl();
        // Execute vertical movement
        StartCoroutine(IsMoving());
        // Execute rotation
        RotateWithMovement();
    }

    void KeepInBounds ()
    {
        float stopAtTop = GameManager.GetTopLeft.y - yBuffer;
        float stopAtBottom = GameManager.GetBottomLeft.y + yBuffer;
        float stopAtSide = GameManager.GetTopLeft.x + xBuffer;

        if (isRight)
        {
            stopAtSide = -stopAtSide;
        }

        if (transform.position.x != stopAtSide)
        {
            transform.position = new Vector2(stopAtSide, transform.position.y);
        }

        if (transform.position.y > stopAtTop)
        {
            transform.position = new Vector2(stopAtSide, stopAtTop);
        }

        if (transform.position.y < stopAtBottom)
        {
            transform.position = new Vector2(stopAtSide, stopAtBottom);
        }
    }

    void MoveLeftHandle ()
    {
        float _hori = Input.GetAxisRaw("HorizontalLeft");
        float _vert = Input.GetAxisRaw("VerticalLeft");

        _hori *= Time.deltaTime;
        _vert *= Time.deltaTime;

        transform.Translate(_hori * moveSpeed, _vert * moveSpeed, 0);

        KeepInBounds();
    }

    void MoveRightHandle ()
    {
        float _hori = Input.GetAxis("HorizontalRight");
        float _vert = Input.GetAxis("VerticalRight");

        _hori *= Time.deltaTime;
        _vert *= Time.deltaTime;

        transform.Translate(_hori * moveSpeed, _vert * moveSpeed, 0);

        KeepInBounds();
    }

    void RotateWithMovement ()
    {
        // Rotate the image, not the parent container
        if (isMovingY > spinSensitivity)
        {
            handleImage.transform.Rotate(Vector3.back * Time.deltaTime * (moveSpeed * rotationSpeed));
        }
        if (isMovingY < -spinSensitivity)
        {
            handleImage.transform.Rotate(Vector3.forward * Time.deltaTime * (moveSpeed * rotationSpeed));
        }
    }

    IEnumerator IsMoving ()
    {
        Vector3 _startPos = transform.position;
        yield return new WaitForSeconds(.1f);
        Vector3 _finalPos = transform.position;

        //isMovingX = _finalPos.x - _startPos.x;
        isMovingY = _finalPos.y - _startPos.y;
    }

    void TouchControl ()
    {
        //Touch Touch = Input.GetTouch(0);
        Touch[] Touches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touchCount > 0 && !isRight)
            {
                // Touch touch = Input.GetTouch(i);
                Vector3 realWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                if (realWorldPos.y > transform.position.y && realWorldPos.x < -7)
                {
                    transform.Translate(0, 0.75f * Time.deltaTime * mobileMoveSpeed, 0);
                }

                if (realWorldPos.y < transform.position.y && realWorldPos.x < -7)
                {
                    transform.Translate(0, -0.75f * Time.deltaTime * mobileMoveSpeed, 0);
                }
            }

            if (Input.touchCount > 0 && isRight)
            {
                // Touch touch = Input.GetTouch(i);
                Vector3 realWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                if (realWorldPos.y > transform.position.y && realWorldPos.x > 7)
                {
                    transform.Translate(0, 0.75f * Time.deltaTime * mobileMoveSpeed, 0);
                }

                if (realWorldPos.y < transform.position.y && realWorldPos.x > 7)
                {
                    transform.Translate(0, -0.75f * Time.deltaTime * mobileMoveSpeed, 0);
                }
            }
        }
    }
}
