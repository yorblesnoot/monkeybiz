using UnityEngine;

public class grapple : MonoBehaviour
{
    [SerializeField] HandAnimator hands;
    public GameObject Reticle;
    public int power = 1;

    private Rigidbody PlayerBody;
    private Vector3 hookPos;
    private float hookLength;
    public int pullTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cursorHit;
        if (Physics.Raycast(ray, out cursorHit, 100))
        {
            Reticle.transform.position = cursorHit.point;

            hookPos = (cursorHit.point - PlayerBody.transform.position).normalized;

            Debug.Log(cursorHit.transform.name);
            Debug.DrawLine(cursorHit.point, PlayerBody.transform.position, Color.blue);
        }

        if (!Input.GetMouseButton(0) && pullTimer > 0)
        {
            pullTimer -= 1;
        }
        else if (Input.GetMouseButton(0) && pullTimer < 30)
        {
            hookLength = hookPos.magnitude;
            pullTimer += 1;
            PlayerBody.AddForce(hookPos * power, ForceMode.Impulse);
            hands.AnimateHandTowardsPosition(cursorHit.point, true);
        }

    }
}
