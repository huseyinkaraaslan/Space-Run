using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private GameObject[] twisters, spikes;
    public GameObject spearArrow, arrowPosition, sawTrap;

    void Start()
    {
        twisters = GameObject.FindGameObjectsWithTag("Twister");
        spikes = GameObject.FindGameObjectsWithTag("Spike");
    }

    void Update()
    {
        trapRotate();
        shotArrow();
    }

    public void trapRotate()
    {
        foreach(GameObject twister in twisters)
        {
            twister.transform.Rotate(0, 0, 300 * Time.deltaTime);
        }

        foreach(GameObject spike in spikes)
        {
            spike.transform.Rotate(0, -150 * Time.deltaTime, 0);
        }
    }

    public void shotArrow()
    {
        spearArrow.transform.Translate(0, 0,25 * Time.deltaTime);
        if(spearArrow.transform.position.x < 5)
        {
            spearArrow.transform.position = arrowPosition.transform.position;
        }
    }
    
}
