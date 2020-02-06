using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedAudioHandler : MonoBehaviour
{
    
    private List<GameObject> sources = new List<GameObject>();
    private int sourceCount;
    private GameObject tempObject;

    public int DummyEntries = 0;  // This is how many empty slots there will be in the random range.
    public float AudioCooldown = 10;

    private float TimeSincePrevious = 0;
    private int sourceIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            tempObject = child.gameObject;
            sources.Add(tempObject);  // This Foreach loop finds all objects childed to this game object and adds them to a list
            tempObject.SetActive(false); // This deactivates each object such that they don't make any sound at the begining of the scene.
        }
        sourceCount = sources.Count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeSincePrevious = TimeSincePrevious + Time.deltaTime;
        if (TimeSincePrevious >= AudioCooldown)
        {

            sources[sourceIndex].SetActive(false); // Deactivate the previous sound effect

            sourceIndex = Mathf.FloorToInt(Random.value * (sourceCount + DummyEntries));

            if (sourceIndex < sourceCount)
            {
            sources[sourceIndex].SetActive(true); // Activate the newly designated sound effect.
            }

            TimeSincePrevious = 0;
        }
    }
}
