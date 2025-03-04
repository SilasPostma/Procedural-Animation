using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrik : MonoBehaviour
{
    public Limb limb;
    public LineRenderer lineRenderer;
    public GameObject jointPrefab;
    private List<GameObject> jointMarkers;
    public int numJoints;
    public GameObject targetGO;

    private void Start()
    {
        Vector2 root = Vector2.zero;
        limb = new Limb(new Vector2(0, 0), root, numJoints);

        jointMarkers = new List<GameObject>();

        foreach (var segment in limb.segments)
        {
            GameObject joint = Instantiate(jointPrefab, root, Quaternion.identity);
            jointMarkers.Add(joint);
        }

        lineRenderer.positionCount = jointMarkers.Count;
    }

    private bool whatFunc;

    private void Update()
    {
        limb.target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        limb.update();

        for (int i = 0; i < limb.segments.Count; i++)
        {
            Vector2 position = limb.segments[i].position;
            lineRenderer.SetPosition(i, new Vector2(position.x, position.y));

            if (i < jointMarkers.Count)
            {
                jointMarkers[i].transform.position = new Vector2(position.x, position.y);
            }
        }
    }

}

