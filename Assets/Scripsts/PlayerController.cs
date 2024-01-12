using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space][SerializeField]
    private GameObject startRoom;

    [Space][SerializeField]
    private LayerMask roomLayer;
    private Collider2D roomCollider;

    [NonSerialized]
    public Vector3 mouseClickPosition;

    [Space][SerializeField]
    private float speedMovePlayer = 5f;

    private bool isMoving = true;

    private void Start()
    {
        transform.position = startRoom.transform.position;
    }

    private void Update()
    {
        RaycastHit2D roomHit = Physics2D.Raycast(mouseClickPosition, Vector2.zero, 1, roomLayer);
        roomCollider = roomHit.collider;

        if (Input.GetMouseButtonDown(0))
        {
              SetMouseClickPosition();
        }

        if (isMoving)
        {
            Move();
        }

        if (transform.position == mouseClickPosition)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    private void Move()
    {
        if (roomCollider == null)
        {
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, roomCollider.transform.position, Time.deltaTime * speedMovePlayer);
        }
    }

    public void SetMouseClickPosition()
    {
       mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       mouseClickPosition.z = transform.position.z;
    }
}




