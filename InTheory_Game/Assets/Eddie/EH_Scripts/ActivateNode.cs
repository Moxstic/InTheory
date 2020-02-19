using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateNode : MonoBehaviour
    // , IPointerEnterHandler
{
    public GameObject Activated;

    // Start is called before the first frame update
    void Start()
    {
        //Activated.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMouseOverUI())
        {
            Activated.SetActive(true);

        }
    }


    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }


    //void OnPointerEnter()
    //{
    //    Activated.SetActive(true);
    //}

}
