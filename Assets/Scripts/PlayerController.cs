using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    public Transform transform;
    Camera camera;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    bool isMoving;
    float speed = 0.25f;
    Vector3 horizontal, vertical;
    bool wasd;

    PlayerModel playerModel;

    public PlayerController(string name, int number)
    {
        if(number == 1)
        {
            wasd = true;
            transform = GameObject.Instantiate(Resources.Load<GameObject>("Sprites/PlayerOne")).transform;
        }
        else
        {
            wasd = false;
            transform = GameObject.Instantiate(Resources.Load<GameObject>("Sprites/PlayerTwo")).transform;
        }

        rb = transform.GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        camera = transform.transform.GetChild(0).GetComponent<Camera>();

        playerModel = transform.gameObject.AddComponent<PlayerModel>();
    }

    // Update is called once per frame
    public void Update()
    {
        float x = wasd ? Input.GetAxisRaw("HorizontalWASD") : Input.GetAxisRaw("HorizontalArrows");
        float y = wasd ? Input.GetAxisRaw("VerticalWASD") : Input.GetAxisRaw("VerticalArrows");

        isMoving = (x != 0 || y != 0);

        if(isMoving || !transform.GetComponent<PlayerModel>().hitPlayer)
        {
            Vector2 move = new Vector2(transform.position.x + x * speed * Time.deltaTime, transform.position.y + y * speed * Time.deltaTime);
            rb.MovePosition(move);
        }
    }
}
