using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EH_ChildActiveWhenKeyDown : MonoBehaviour
{

    public GameObject c_thischild;

    private void Start()
    {
        //Assigns the transform of the first child of the Game Object this script is attached to.
        c_thischild = this.gameObject.transform.GetChild(0).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            c_thischild.SetActive(true);

        }


        if (Input.GetKeyUp(KeyCode.E))
        {
            c_thischild.SetActive(false);

        }
    }
}
