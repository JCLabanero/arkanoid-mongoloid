using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_userPaddle : MonoBehaviour
{
    public float speed = 1f;
    private float edge = 9f;
    public GameManager gameManager;

    void Update()
    {
        if(gameManager.isGameOver){
            return;
        }
        float x = Input.GetAxis("Mouse X");
        transform.Translate(0,x*speed,0);

        if(transform.position.x < -9f){
            transform.position = new Vector2(-edge, transform.position.y);
        }
        if(transform.position.x > 9f){
            transform.position = new Vector2(edge,transform.position.y);
        }
    }
}
