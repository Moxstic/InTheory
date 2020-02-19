using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Handler : MonoBehaviour
{

    public bool isGamePaused = false;
    public bool isMinigameRunning = false;
    public string ultKey = "q";

    public int percentageChanceToSpawnNode = 50;

    public GameObject NodePrefab;


    public GameObject Whitewash;
    public GameObject MinigameWindow;
    public GameObject NodeContainer;
    public GameObject NodeSpawnPoint;

    private RectTransform NodeSpawnCoordinates;

    private GameObject tempNode; // Temporarily holds node game object to set it's parameters.

    // Start is called before the first frame update
    void Start()
    {

        MinigameWindow = GameObject.Find("MinigameWindow");
        NodeContainer = GameObject.Find("NodeContainer");
        NodeSpawnPoint = GameObject.Find("NodeSpawnPoint");
        NodeSpawnCoordinates = NodeSpawnPoint.GetComponent<RectTransform>();
        MinigameWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(ultKey) ) // Input key Q was selected as this is the default key for ultimates in Overwatch, a popular FPS game.
        {
            isGamePaused = true;
            isMinigameRunning = true;
        }

        if ( isGamePaused == true )
        {

        }

        if (isMinigameRunning == true)
        {
            StartMinigame();
            isMinigameRunning = false;
        }
    }

    public void StartMinigame()
    {
        int spiralMagnitude = 0;

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

        int nodesSpawned;

        MinigameWindow.SetActive(true);

        NodeSpawnCoordinates.localPosition = new Vector3 (spawnX, spawnY, 0);


        // Instatiate first node
        Instantiate(NodePrefab, NodeContainer.transform);

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

                    Xrand = Random.Range(0, positionRange) - (positionRange / 2);
                    Yrand = Random.Range(0, positionRange) - (positionRange / 2);
                    // Determine variation from spawn position randomly.


                    //Instantiate next node
                    tempNode = Instantiate(NodePrefab, NodeContainer.transform);
                    tempNode.GetComponent<RectTransform>().localPosition = new Vector3(spawnX + Xrand, spawnY + Yrand, 0);


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
}
