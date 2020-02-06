using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup_Test : MonoBehaviour
{
    public bool ReturnToStartingPositionOnDrop;

    private GameObject DruidCarryContainer; // The Cary Container empty object attached to the player controller in the scene.
    private Transform CarryPos; // Position of the carry container.
    private Transform DefaultParent; // Default/original parent of the object.
    private Rigidbody ThisBody; // This object's rigidbody.

    // Start is called before the first frame update
    void Start()
    {
        DefaultParent = transform.parent;

        ThisBody = GetComponent<Rigidbody>();
        if (ThisBody == null)
        {
            gameObject.AddComponent<Rigidbody>();
            ThisBody = GetComponent<Rigidbody>();// This will add arigidbody to the object in the event that one isn't already atached to the object.
        }

        DruidCarryContainer = GameObject.Find("Carried_Object_Container");
        CarryPos = DruidCarryContainer.transform;  // Sets up the appropriate objects and transforms for later in the script.
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        float dist = Vector3.Distance(CarryPos.position, transform.position);
        if (dist <= 2)  // tests distance between this object and the cary container
        {
            ThisBody.useGravity = false;
            transform.position = CarryPos.position;
            transform.parent = CarryPos; // Childs this object to the empty attached to the player that represents their hand.

            ThisBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY; // Constrains position of the object while picked up.
        }
        
    }

    private void OnMouseUp()
    {
        if (transform.parent != DefaultParent)
        {
            transform.parent = DefaultParent; // Sets the object's parent to whatever it was when the level loaded.  Usually this'll be none.
            ThisBody.useGravity = true;

            ThisBody.constraints = RigidbodyConstraints.None; //Gets rid of all the constraints so that the object will behave normally when dropped.
        }
    }
}
