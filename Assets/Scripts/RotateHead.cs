using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    public float rotationSpeed;
    private Vector2 dir;
    public float moveSpeed;

    private void FixedUpdate()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        dir = cursorPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        transform.position = Vector2.MoveTowards((Vector2)transform.position, cursorPos - Vector2.one * dir.normalized, moveSpeed * Time.deltaTime);
    }

}
