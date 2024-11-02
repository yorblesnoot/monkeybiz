using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] float handDistance;
    [SerializeField] Transform source;
    [SerializeField] Transform leftIK;
    [SerializeField] Transform rightIK;
    Vector3 leftTarget;
    Vector3 rightTarget;

    private void Awake()
    {
        leftTarget = leftIK.transform.position;
        rightTarget = rightIK.transform.position;
    }
    public void AnimateHandTowardsPosition(Vector3 targetPosition, bool right)
    {
        Vector3 offset = targetPosition - source.transform.position;
        offset = offset.normalized;
        offset *= handDistance;
        Vector3 finalPosition = source.position + offset;
        if(right) rightTarget = finalPosition;
        else leftTarget = finalPosition;
    }

    private void LateUpdate()
    {
        leftIK.transform.position = Vector3.Lerp(leftIK.transform.position, leftTarget, Time.deltaTime);
        rightIK.transform.position = Vector3.Lerp(rightIK.transform.position, rightTarget, Time.deltaTime);
    }
}
