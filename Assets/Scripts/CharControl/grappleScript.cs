using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] Rigidbody playerBody;
    [SerializeField] LineRenderer line;
    [SerializeField] GameObject Reticle;
    [SerializeField] int power = 1;
    [SerializeField] Transform lineSource;
    [SerializeField] GameObject Cursor;

    HandAnimator handAnimator;
    string handButton;

    private Vector3 pullDirection;
    private void Awake()
    {
        handAnimator = GetComponent<HandAnimator>();
        
        line.useWorldSpace = true;

        if (Cursor.GetComponent<cursorScript>().handNumber == 0)
        {
            handButton = "Fire";
        }
        else
        {
            handButton = "Fire2";
        }
    }
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Cursor.transform.position);
        if (Input.GetAxis(handButton) == 0 && Physics.Raycast(ray, out RaycastHit cursorHit, 100))
        {
            Reticle.transform.position = cursorHit.point;
            Reticle.transform.SetParent(cursorHit.collider.transform, true);
        }

        if (Input.GetAxis(handButton) > 0)
        {
            playerBody.isKinematic = false;

            Vector3 pullPoint = Reticle.transform.position;
            pullDirection = (pullPoint - playerBody.transform.position).normalized;
            line.positionCount = 2;
            line.SetPositions(new Vector3[] { lineSource.position, pullPoint });

            playerBody.AddForce(pullDirection * power, ForceMode.Impulse);
            handAnimator.AnimateHandTowardsPosition(pullPoint, true);
        }
        else
        {
            handAnimator.ResetHandTarget();
            line.positionCount = 0;
        }
    }
}
