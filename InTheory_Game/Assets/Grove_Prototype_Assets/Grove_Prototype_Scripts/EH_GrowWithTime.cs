using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EH_GrowWithTime : MonoBehaviour
{
    //===================================================================================================
    // This script automatically sets the attached object to grow over time once activated.
    // It is assumed that the attached object is set to inactive in the IDE and is then set to active during gameplay.
    //===================================================================================================


    public bool v_growing = true;
    public GameObject c_thisobject;
    public float v_Xvalue = 0.01f;
    public float v_Yvalue = 0.01f;
    public float v_Zvalue = 0.01f;
    public float c_growSpeed = 0.4f;

    //public bool 

    // Start is called before the first frame update
    void Start()
    {
        c_thisobject = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (v_growing == true)
        {
            if (v_Xvalue >= 1 || v_Yvalue >= 1 || v_Zvalue >= 1)
            {
                v_Xvalue = 1;
                v_Yvalue = 1;
                v_Zvalue = 1;
                v_growing = false;
                //c_thisobject.SetActive(false);
            } else
            {

                v_Xvalue = v_Xvalue + (c_growSpeed * Time.deltaTime);
                v_Yvalue = v_Yvalue + (c_growSpeed * Time.deltaTime);
                v_Zvalue = v_Zvalue + (c_growSpeed * Time.deltaTime);
            }
            c_thisobject.transform.localScale = new Vector3(v_Xvalue, v_Yvalue, v_Zvalue);
        }
        else
        {
            v_Xvalue = 1;
            v_Yvalue = 1;
            v_Zvalue = 1;
            c_thisobject.transform.localScale = new Vector3(v_Xvalue, v_Yvalue, v_Zvalue);
        }
    }
}