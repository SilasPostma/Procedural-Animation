using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb
{
    public List<EndEffector> segments;
    public int numEffectors;
    public Vector2 target;
    public Vector2 root;

    public Limb(Vector2 r, Vector2 Target, int numeffectors)
    {
        numEffectors = numeffectors;
        root = r;
        float ls = 5;
        float sum = 0;
        segments = new List<EndEffector>();
        target = Target;

        for (int i = 0; i < numEffectors; i++)
        {
            segments.Add(new EndEffector(r.x, r.y + sum, ls));
            sum += ls;
            ls *= 0.8f;
        }
    }


    public void ForwardKinematics()
    {
        EndEffector next = segments[segments.Count - 1];
        next.position = target;

        for (int i = segments.Count - 2; i >= 0; i--)
        {
            EndEffector current = segments[i];
            Vector2 direction = next.position - current.position;
            direction = direction.normalized * current.length;
            current.position = next.position - direction;
            next = current;
        }
    }

    public void BackwardKinematics()
    {
        EndEffector prev = segments[0];
        prev.position = root;

        for (int i = 1; i < segments.Count; i++)
        {
            EndEffector current = segments[i];
            Vector2 direction = current.position - prev.position;
            direction = direction.normalized * current.length;
            current.position = prev.position + direction;
            prev = current;
        }
    }

    public void update()
    {
        ForwardKinematics();
        //BackwardKinematics();
    }
}
