using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float moveSpeed;
    public float moveConstraint = 6.5f;
    private Vector3 targetMove;

    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < moveConstraint && mousePos.x > -moveConstraint
                && mousePos.y < moveConstraint && mousePos.y > -moveConstraint)
            {
                targetMove = mousePos;
                targetMove.z = 0;
            }
        }

        if (transform.position != targetMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMove, moveSpeed * Time.deltaTime);
        }
    }
}