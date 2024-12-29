using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(0, Vector2.zero);
    }

    void Update() {
        lineRenderer.SetPosition(1, new Vector2(0.5f, 0));
    }
}
