using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    public GameObject pipeModel;
    public Transform spawmPoint;
    public float interval;

    private float currentTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {

        currentTime += Time.deltaTime;
        if (currentTime > interval)
        {
            CreatPipe();
            currentTime = 0f;
        }
    }

    void CreatPipe()
    {
        Instantiate(pipeModel, spawmPoint.position, Quaternion.identity);
    }
}
