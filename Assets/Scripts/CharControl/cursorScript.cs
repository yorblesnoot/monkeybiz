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
            ControlCursor("Horizontal", "Vertical");
        }
        else if (gameObject.name == "cursorPlayer2")
        {
            ControlCursor("Horizontal2", "Vertical2");
        }
    }

    void ControlCursor(string axisHorizontal, string axisVertical)
    {
        Vector3 finalPosition = transform.position;
        finalPosition.x += Input.GetAxis(axisHorizontal) * cursorSpeed;
        finalPosition.y += Input.GetAxis(axisVertical) * cursorSpeed;
        finalPosition.x = Mathf.Clamp(finalPosition.x, cursorDeadZone, Screen.width - cursorDeadZone);
        finalPosition.y = Mathf.Clamp(finalPosition.y, cursorDeadZone, Screen.height - cursorDeadZone);
        transform.position = finalPosition;
    }
}
