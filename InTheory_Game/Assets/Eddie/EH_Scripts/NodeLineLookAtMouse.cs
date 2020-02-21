using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLineLookAtMouse : MonoBehaviour
{
    public bool ActiveLine = false;
    public float lineWidth = 1;
    public Vector3 nextNodePos; // By default this is set to this object's position in Start() so that before a node is activated, the line does not show.

    public GameObject pauseHandler;

    private void Start()
    {
        transform.localScale = new Vector2(lineWidth, transform.localScale.y);
        nextNodePos = this.transform.position;
    }

    void Update()
    {
        if (ActiveLine)
        {
            Vector3 dir = Input.mousePosition - this.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle -= 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            float dist = Vector2.Distance(Input.mousePosition, this.transform.position);
            transform.localScale = new Vector2(transform.localScale.x, dist / 10);
        }
        else
        {
            Vector3 dir = nextNodePos - this.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle -= 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            float dist = Vector2.Distance(nextNodePos, this.transform.position);
            transform.localScale = new Vector2(transform.localScale.x, dist / 10);
        }
    }

    
}
