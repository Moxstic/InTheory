using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    public float lifetime = 10.0f; // The length of time in seconds until the object is deactivated.

    // Update is called once per frame
    void Update()
    {
        if (lifetime <= 0)
        {
            this.gameObject.SetActive(false);
        }

        lifetime = lifetime - Time.deltaTime;
    }
}
