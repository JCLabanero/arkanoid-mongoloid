using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 300;
    public bool isPlaying=true;
    public Transform paddle;
    public Transform explosion;
    public AudioSource explosionSound;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver){
            return;
        }
        if(!isPlaying){
            this.transform.position = new Vector2(paddle.position.x,paddle.position.y+0.6f);
        }
        if(Input.GetMouseButtonDown(0) && isPlaying==false){
            isPlaying=true;
            rb.AddForce(Vector2.up*speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("bottom")){
            rb.velocity = Vector2.zero;
            isPlaying=false;
            gameManager.decreaseLifeByOne();
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.transform.CompareTag("brick")){
            explosionSound.Play();
            Destroy(Instantiate(explosion,other.transform.position,other.transform.rotation).gameObject,3f);
            Destroy(other.gameObject);
        }
    }
}
