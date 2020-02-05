using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup_Test : MonoBehaviour
{

    private GameObject DruidCarryContainer; // The Cary Container empty object attached to the player controller in the scene.
    private Transform CarryPos; // Position of the carry container.

    // Start is called before the first frame update
    void Start()
    {
        DruidCarryContainer = GameObject.Find("Carried_Object_Container");
        CarryPos = DruidCarryContainer.transform;  // Sets up the appropriate objects and transforms for later in the script.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(CarryPos.position, transform.position);
        if (dist <= 2)  // tests distance between this object and the cary container
        {

        }
    }
}
