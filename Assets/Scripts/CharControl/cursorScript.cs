using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    public int handNumber = 0;
    [SerializeField] int cursorSpeed = 6;
    [SerializeField] int cursorDeadZone = 10;

    void FixedUpdate()
    {

        if (gameObject.name == "cursorPlayer1")
        {
            ControlCursor();
        }
        else if (gameObject.name == "cursorPlayer2")
        {
            Player2();
        }

        ClampToWindow();
    }

    void ControlCursor()
    { 
        transform.Translate(Input.GetAxis("Horizontal") * cursorSpeed, Input.GetAxis("Vertical") * cursorSpeed, 0);
    }

    void Player2()
    {
        transform.Translate(Input.GetAxis("Horizontal2") * cursorSpeed, Input.GetAxis("Vertical2") * cursorSpeed, 0);
    }

    void ClampToWindow()
    {
        if (transform.position.x < cursorDeadZone)
        {
            transform.Translate(cursorDeadZone, 0, 0);
        }
        if (transform.position.x > Screen.width - cursorDeadZone)
        {
            transform.Translate(-cursorDeadZone, 0, 0);
        }
        if (transform.position.y < cursorDeadZone)
        {
            transform.Translate(0, cursorDeadZone, 0);
        }
        if (transform.position.y > Screen.height - cursorDeadZone)
        {
            transform.Translate(0, -cursorDeadZone, 0);
        }
    }
}
