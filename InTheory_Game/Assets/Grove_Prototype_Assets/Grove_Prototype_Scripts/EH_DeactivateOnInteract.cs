using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EH_DeactivateOnInteract : MonoBehaviour
{
    public GameObject c_thischild;


    public void Start()
    {
        //Assigns the transform of the first child of the Game Object this script is attached to.
        c_thischild = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerReach" && Input.GetKey(KeyCode.E)) //PlayerReach, is the range within which the player-character can touch surrounding objects
        {
            c_thischild.GetComponent<EH_ShrinkWithTime>().enabled = true;
        }
    }
}
