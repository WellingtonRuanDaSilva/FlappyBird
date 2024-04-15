using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                break;
            case GameStatus.Play:
                PlayUpdate();
                break;
            case GameStatus.GameOver:
                break;
            default:
                break;
        }

    }

    private void PlayUpdate()
    {
        transform.position += Vector3.left * Time.deltaTime * GameManager.instance.speed;

        if (transform.position.x < -0.04f)
        {
            transform.position += Vector3.right * 0.24f;
        }
    }
}
