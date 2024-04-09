using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;
    private Vector3 startPosition;
    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rig.bodyType = RigidbodyType2D.Static;
        controller.SetBool("IsLive", true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                StartUpdate();
                break;
            case GameStatus.Play:
                PlayUpdate();
                break;
            case GameStatus.GameOver:
                GameOverUpdate();
                break;
        }
    }

    public void StartGame()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
        Jump();
    }

    void StartUpdate()
    {

    }

    void PlayUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void GameOverUpdate()
    {

    }

    void Jump()
    {
        rig.velocity = Vector3.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 6:
                GameOver();
                break;
            case 7:
                GameManager.instance.AddScore();
                break;
            default:
                break;
        }
    }

    public void Restart()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rig.bodyType = RigidbodyType2D.Static;
        controller.SetBool("IsLive", true);
    }

    private void GameOver()
    {
        GameManager.instance.GameOver();
        controller.SetBool("IsLive", false);
    }
}
