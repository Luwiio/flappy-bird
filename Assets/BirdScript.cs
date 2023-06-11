using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRidigidbody;
    public float flapStrength = 10;
    public LogicScript logic;
    public bool BirdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive)
        {
            myRidigidbody.velocity = Vector2.up * flapStrength;
        }
        if (transform.position.y > 15.5 || transform.position.y < -15.5)
        {
            Debug.Log("Game over because off screen");
            GameOverForBird();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverForBird();
    }
    private void GameOverForBird()
    {
        logic.GamerOver();
        BirdIsAlive = false;
    }

}



