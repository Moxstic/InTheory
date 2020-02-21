using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActivateNode : MonoBehaviour
{
    public GameObject Activated;
    public GameObject thisLine;
    public GameObject lastLine;
    public GameObject pauseHandler;
    private bool done = false;  //When this script has doen it's job, we set this to true so it doesn't activate again later.

    // Start is called before the first frame update
    void Start()
    {
        pauseHandler = GameObject.Find("PauseHandler");
        Activated.SetActive(false);
    }

    public void Activate()
    {
        if (done != true)
        {
            //Get and deactivate previous line.
            lastLine = pauseHandler.GetComponent<Pause_Handler>().activeNodeLine;
            thisLine = this.transform.Find("NodeLine").gameObject;
            if (lastLine != null)
            {
                lastLine.GetComponent<NodeLineLookAtMouse>().ActiveLine = false;
                lastLine.GetComponent<NodeLineLookAtMouse>().nextNodePos = thisLine.transform.position;
            }
            //Activate the image that shows this object has been activated.
            Activated.SetActive(true);

            //Set this object as active and let the pause handler know this is the active object for the next time.
            thisLine.GetComponent<NodeLineLookAtMouse>().ActiveLine = true;
            pauseHandler.GetComponent<Pause_Handler>().activeNodeLine = thisLine;

            //Count up how many nodes have been activated so that the PH can end the game when enough have been activated.
            pauseHandler.GetComponent<Pause_Handler>().nodesActivated++;

            done = true;  // Set to done
        }
    }
    
}
