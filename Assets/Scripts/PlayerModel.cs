using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public bool hitPlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" && !hitPlayer)
        {
            Debug.Log("DKsjfLdJ");
            hitPlayer = true;
            collision.transform.GetComponent<PlayerModel>().hitPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hitPlayer = false;
        //collision.transform.GetComponent<PlayerModel>().hitPlayer = false;
    }
}
