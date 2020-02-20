using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLineLookAtMouse : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
 	
        // Get the point along the ray that hits the calculated distance.
        Vector3 targetPoint = ray.GetPoint(hitdist);

        // Determine the target rotation.  This is the rotation if the transform looks at the target point.
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed* Time.deltaTime);
	}

}
