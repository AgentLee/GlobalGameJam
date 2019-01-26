using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    GameObject player;
    Camera camera;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    bool isMoving;
    float speed = 0.25f;
    Vector3 horizontal, vertical;
    bool wasd;

    public PlayerController(string name, int number)
    {
        if(number == 1)
        {
            wasd = true;
            player = GameObject.Instantiate(Resources.Load<GameObject>("PlayerOne"));
        }
        else
        {
            wasd = false;
            player = GameObject.Instantiate(Resources.Load<GameObject>("PlayerTwo"));
        }

        rb = player.GetComponent<Rigidbody2D>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        camera = player.transform.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    public void Update()
    {
        float x = wasd ? Input.GetAxisRaw("HorizontalWASD") : Input.GetAxisRaw("HorizontalArrows");
        float y = wasd ? Input.GetAxisRaw("VerticalWASD") : Input.GetAxisRaw("VerticalArrows");

        isMoving = (x != 0 || y != 0);

        if(isMoving)
        {
            Vector2 move = new Vector2(player.transform.position.x + x * speed * Time.deltaTime, player.transform.position.y + y * speed * Time.deltaTime);
            rb.MovePosition(move);
        }
    }
}
