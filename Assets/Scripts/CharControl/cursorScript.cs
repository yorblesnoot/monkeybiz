using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    [SerializeField] int cursorSpeed = 2;
    public int handNumber = 0;

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

        ClampToWindow();
    }

    void Player1()
    { 
        transform.Translate(Input.GetAxis("Horizontal") * cursorSpeed, Input.GetAxis("Vertical") * cursorSpeed, 0);
    }

    void Player2()
    {
        transform.Translate(Input.GetAxis("Horizontal2") * cursorSpeed, Input.GetAxis("Vertical2") * cursorSpeed, 0);
    }

    void ClampToWindow()
    {
        if (transform.position.x < 0)
        {
            transform.Translate(2, 0, 0);
        }
        if (transform.position.x > Screen.width)
        {
            transform.Translate(-2, 0, 0);
        }
        if (transform.position.y < 0)
        {
            transform.Translate(0, 2, 0);
        }
        if (transform.position.y > Screen.height)
        {
            transform.Translate(0, -2, 0);
        }
    }
}
