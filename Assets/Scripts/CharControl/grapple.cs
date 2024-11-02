using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] Rigidbody playerBody;
    [SerializeField] LineRenderer line;
    [SerializeField] int handNumber = 0;
    [SerializeField] GameObject Reticle;
    [SerializeField] int power = 1;
    [SerializeField] Transform lineSource;

    HandAnimator handAnimator;

    private Vector3 pullDirection;
    private void Awake()
    {
        handAnimator = GetComponent<HandAnimator>();
        
        line.useWorldSpace = true;
    }
    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(handNumber) && Physics.Raycast(ray, out RaycastHit cursorHit, 100))
        {
            Reticle.transform.position = cursorHit.point;
        }

        if (Input.GetMouseButton(handNumber))
        {
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
