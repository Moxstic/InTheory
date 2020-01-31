using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EH_ShrinkWithTime : MonoBehaviour
{
    public bool v_shrinking;
    public GameObject c_thisobject;
    private float v_Xvalue = 1;
    private float v_Yvalue = 1;
    private float v_Zvalue = 1;

    public float c_shrinkSpeed = 0.2f;

    //public bool 

    // Start is called before the first frame update
    void Start()
    {
        c_thisobject = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (v_shrinking == true)
        {
            v_Xvalue = v_Xvalue - (c_shrinkSpeed * Time.deltaTime);
            v_Yvalue = v_Yvalue - (c_shrinkSpeed * Time.deltaTime);
            v_Zvalue = v_Zvalue - (c_shrinkSpeed * Time.deltaTime);
            if (v_Xvalue <= 0 || v_Yvalue <= 0 || v_Zvalue <= 0)
            {
                v_Xvalue = 1;
                v_Yvalue = 1;
                v_Zvalue = 1;
                v_shrinking = false;
                c_thisobject.SetActive(false);
            }
        }
        else
        {
            v_Xvalue = 1;
            v_Yvalue = 1;
            v_Zvalue = 1;
        }
        c_thisobject.transform.localScale = new Vector3(v_Xvalue, v_Yvalue, v_Zvalue);
    }
}