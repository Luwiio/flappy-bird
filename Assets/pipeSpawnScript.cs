using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public double spawnRate = 1.5;
    public float timer = 0;
    public float speedUp = 0;
    private float speedUpWork = 3;
    public float heightOffset = 10;
    public pipeMoveScript pipeMs;

    // Start is called before the first frame update
    void Start()
    {
        pipeMs = GameObject.FindGameObjectWithTag("PIPEY").GetComponent<pipeMoveScript>();
        spawnPipe();
 
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
            speedUp += 1;
            if (speedUp > speedUpWork)
            {
                pipeMs.addSpeed(1);
                speedUp = 0;
            }
        }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

}
