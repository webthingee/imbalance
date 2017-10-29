using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]

public class LineController : MonoBehaviour {

    public GameObject left;
    public GameObject right;

	LineRenderer lineRenderer;
	public float width;

	EdgeCollider2D edgeCol;

    void Awake () {
		lineRenderer = GetComponent<LineRenderer>();
		edgeCol = GetComponent<EdgeCollider2D>();
	}
	
	void Start ()
	{
        DrawLine();
        EdgeColliderForLine();
	}
	void FixedUpdate ()
	{
		UpdateLinePositions();
		EdgeColliderForLine();
	}

	void DrawLine ()
	{
        lineRenderer.startColor = Color.white;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.positionCount = 2;
		lineRenderer.SetPosition(0, left.transform.position);
		lineRenderer.SetPosition(1, right.transform.position);
        lineRenderer.useWorldSpace = false;
        //lineRenderer.material = lineRenderer.materials[0];
        //lineRenderer.material.color = Color.white;
    }

	void UpdateLinePositions ()
	{
        lineRenderer.SetPosition(0, left.transform.position);
        lineRenderer.SetPosition(1, right.transform.position);
	}

	void EdgeColliderForLine ()
	{
        Vector2[] colliderpoints;
        colliderpoints = edgeCol.points;
        colliderpoints[0] = left.transform.position;
        colliderpoints[1] = right.transform.position;
        edgeCol.points = colliderpoints;
	}
}
