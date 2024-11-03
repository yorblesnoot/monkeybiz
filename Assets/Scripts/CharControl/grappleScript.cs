using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] Rigidbody playerBody;
    [SerializeField] LineRenderer line;
    [SerializeField] GameObject Reticle;
    [SerializeField] int power = 30;
    [SerializeField] Transform lineSource;
    [SerializeField] GameObject Cursor;

    HandAnimator handAnimator;
    string handButton;
    bool isAxisDown = false;

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
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Cursor.transform.position);
        if (Input.GetAxisRaw(handButton) == 0 && Physics.Raycast(ray, out RaycastHit cursorHit, 100))
        {
            Reticle.transform.position = cursorHit.point;
            Reticle.transform.SetParent(cursorHit.collider.transform, true);
        }

        if (Input.GetAxisRaw(handButton) != 0)
        {
            playerBody.isKinematic = false;
            playerBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotation ;

            Vector3 pullPoint = Reticle.transform.position;
            pullDirection = (pullPoint - playerBody.transform.position).normalized;
            line.positionCount = 2;
            line.SetPositions(new Vector3[] { lineSource.position, pullPoint });

            playerBody.AddForce(pullDirection * power, ForceMode.Impulse);
            handAnimator.AnimateHandTowardsPosition(pullPoint, true);

            // audio
            if(!isAxisDown)
            {
                gameObject.GetComponent<AudioSource>().Play();
                isAxisDown = true;
            }
        }
        else
        {
            handAnimator.ResetHandTarget();
            line.positionCount = 0;
            playerBody.constraints = RigidbodyConstraints.None;

            isAxisDown = false;
        }
    }
}
