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
    private int updateCounter;
    public GameObject targetGO;


    private void Start()
    {
        limb = new Limb(new Vector2(0, 0), Vector2.zero, numJoints);

        jointMarkers = new List<GameObject>();

        foreach (var segment in limb.segments)
        {
            GameObject joint = Instantiate(jointPrefab, Vector3.zero, Quaternion.identity);
            jointMarkers.Add(joint);
        }

        lineRenderer.positionCount = jointMarkers.Count;
    }


    private void FixedUpdate()
    {

        for (int i = 0; i < limb.segments.Count; i++)
        {
            Vector2 position = limb.segments[i].position;
            lineRenderer.SetPosition(i, new Vector2(position.x, position.y));

            if (i < jointMarkers.Count)
            {
                jointMarkers[i].transform.position = new Vector2(position.x, position.y);
            }
        }



        limb.update();

        limb.target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //limb.target = (Vector2)targetGO.transform.position;

        updateCounter = 0;
    }

}

