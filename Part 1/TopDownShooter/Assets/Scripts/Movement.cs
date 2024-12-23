using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    private float moveSpeed = 6;
    private Vector2 velocity;
    void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(0, Vector2.zero);
    }

    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        // direction = directionSlider.GetDirection();
        // lineRenderer.SetPosition(0, transform.position);
        // Debug.Log(transform.right);
        lineRenderer.SetPosition(1, new Vector2(2, 0));
        // Debug.Log("Movement: " + transform.right);
        // Debug.Log(transform.position + transform.right * 5);
        // transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
