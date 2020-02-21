using EasySurvivalScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Handler : MonoBehaviour
{

    private bool isGamePaused = false;
    private bool isMinigameRunning = false;
    public string ultKey = "q";

    public int percentageChanceToSpawnNode = 50;

    public GameObject RandomTempChimePrefab;
    public GameObject NodePrefab;

    private GameObject Whitewash;
    private GameObject MinigameWindow;
    private GameObject NodeContainer;
    private GameObject NodeSpawnPoint;

    private GameObject CameraController;

    private RectTransform NodeSpawnCoordinates;


    private GameObject initNode; // Initial node
    private GameObject tempNode; // Temporarily holds node game object to set it's parameters.
    private List<GameObject> nodeList = new List<GameObject>();

    public GameObject activeNodeLine;

    public GameObject activatingGameEvent;


    private int nodesSpawned;  //Will be used to detect when all the spawned nodes have been acivated.
    public int nodesActivated;

    // Start is called before the first frame update
    void Start()
    {

        MinigameWindow = GameObject.Find("MinigameWindow");
        NodeContainer = GameObject.Find("NodeContainer");
        NodeSpawnPoint = GameObject.Find("NodeSpawnPoint");
        CameraController = GameObject.Find("Camera Controller");
        NodeSpawnCoordinates = NodeSpawnPoint.GetComponent<RectTransform>();
        MinigameWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(ultKey) ) // Input key Q was selected as this is the default key for ultimates in Overwatch, a popular FPS game.
        {
            isGamePaused = true;
            if (isMinigameRunning != true)
            {
                StartMinigame();
            }
            isMinigameRunning = true;
        }

        if ( isGamePaused == true )
        {

        }

        if (isMinigameRunning == true  && nodesSpawned == nodesActivated)
        {
            EndMinigame();
        }
        

    }

    public void StartMinigame()
    {
        
        int spiralMagnitude = 0; // A value used to count up the length of the current edge of the spiral.
        
        // The bounds of the generation space
        int maxX = 450;
        int minX = -450;
        int maxY = 250;
        int minY = -250;

        int positionIncrement = 100;
        int positionRange = 50;

        int spawnX = 0;
        int spawnY = 0;

        int Xrand;  // Random variation value on the x-axis
        int Yrand;  // ditto in the Y.

        bool incMagnitude = false;

        int direction = 1; // direction values; 1 = right, 2 = up, 3 = left, 4 = down.


        int compulsorySecondNodePos = Random.Range(1, 29); //
        bool minNodesMet = false; // 

        CameraController.GetComponent<PlayerCamera>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        MinigameWindow.SetActive(true);

        NodeSpawnCoordinates.localPosition = new Vector3 (spawnX, spawnY, 0);


        // Instatiate first node
        initNode = Instantiate(NodePrefab, NodeContainer.transform);

        nodeList.Add(initNode);
        nodesSpawned++;

        while (spawnX < maxX && spawnX > minX && spawnY < maxY && spawnY > minY)
        {

            for (int i = 0; i <= spiralMagnitude; i++)
            {

                //Move proceedural spawn location
                switch (direction)
                {
                    case 1: // right 
                        spawnX = spawnX + positionIncrement;
                        break;
                    case 2: // up
                        spawnY = spawnY + positionIncrement;
                        break;
                    case 3: // left
                        spawnX = spawnX - positionIncrement;
                        break;
                    case 4: // down
                        spawnY = spawnY - positionIncrement;
                        break;
                    default:
                        // Print error because direction value is outside of expeted range.
                        break;
                }
                

                // Decide randomly if to spawn a node in each location
                if (Random.Range(0, 101) <= percentageChanceToSpawnNode && spawnY < maxY)
                {
                    // Determine variation from spawn position randomly.
                    Xrand = Random.Range(0, positionRange) - (positionRange / 2);
                    Yrand = Random.Range(0, positionRange) - (positionRange / 2);

                    //Instantiate next node
                    tempNode = Instantiate(NodePrefab, NodeContainer.transform);
                    tempNode.GetComponent<RectTransform>().localPosition = new Vector3(spawnX + Xrand, spawnY + Yrand, 0);

                    //Add node to list for handling later.
                    nodeList.Add(tempNode);

                    nodesSpawned++;

                } else
                {
                    // Decrement countdown to compulsory second node.
                    compulsorySecondNodePos--;
                    if (compulsorySecondNodePos <= 0 && minNodesMet == false)
                    {
                        // Determine variation from spawn position randomly.
                        Xrand = Random.Range(0, positionRange) - (positionRange / 2);
                        Yrand = Random.Range(0, positionRange) - (positionRange / 2);

                        //Instantiate next node
                        tempNode = Instantiate(NodePrefab, NodeContainer.transform);
                        tempNode.GetComponent<RectTransform>().localPosition = new Vector3(spawnX + Xrand, spawnY + Yrand, 0);
                        //Add node to list for handling later.
                        nodeList.Add(tempNode);

                        nodesSpawned++;

                        minNodesMet = true; //Now that a second compulsory node has ben included, this ensures this If statement isn't triggered again.
                    }
                }
            }

            // Increment direction 
            if (direction >= 4)
            {
                direction = 1;
            } else
            {
                direction++;
            }

            //Increase spiral magnitude every two loops
            if (incMagnitude == true)
            {
                spiralMagnitude++;
                incMagnitude = false;
            } else
            {
                incMagnitude = true;
            }

        }

    }

    void EndMinigame()
    {
        foreach (GameObject node in nodeList)
        {
            Object.Destroy(node);
        }


        CameraController.GetComponent<PlayerCamera>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        MinigameWindow.SetActive(false);

        Instantiate(RandomTempChimePrefab);

        isMinigameRunning = false;


        Debug.LogWarning("END MINIGAME");
    }

    public void DeactivateNodeLines()
    {
        
    }
}
