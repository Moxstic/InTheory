using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActivateNode : MonoBehaviour
{
    public GameObject Activated;

    // Start is called before the first frame update
    void Start()
    {
        Activated.SetActive(false);
    }

    public void Activate()
    {
        Activated.SetActive(true);
    }
    
}
