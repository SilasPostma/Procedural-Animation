using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public int length;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPositions;
    public Vector3[] segmentVelocities;

    public float maxDist;
    public float smoothSpeed;

    public Transform targetDir;

    private void Start()
    {
        lineRenderer.positionCount = length;
        segmentPositions = new Vector3[length];
        segmentVelocities = new Vector3[length];
    }

    private void FixedUpdate()
    {
        segmentPositions[0] = targetDir.position;

        for (int i = 1; i < segmentPositions.Length; i++)
        {
            Vector3 targetPos = segmentPositions[i - 1] + (segmentPositions[i] - segmentPositions[i - 1]).normalized * maxDist;
            segmentPositions[i] = Vector3.SmoothDamp(segmentPositions[i], targetPos, ref segmentVelocities[i], smoothSpeed);
        }
        lineRenderer.SetPositions(segmentPositions);
    }
}
