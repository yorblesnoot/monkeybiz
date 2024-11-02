using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    [SerializeField] int cursorSpeed = 2;
    [SerializeField] int handNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "cursorPlayer1")
        {
            Player1();
        }
        else if (gameObject.name == "cursorPlayer2")
        {
            Player2();
        }
    }

    void Player1()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * cursorSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * cursorSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -1 * cursorSpeed, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 1 * cursorSpeed, 0);
        }
    }

    void Player2()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(-1 * cursorSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(1 * cursorSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(0, -1 * cursorSpeed, 0);
        }
        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(0, 1 * cursorSpeed, 0);
        }
    }
}
