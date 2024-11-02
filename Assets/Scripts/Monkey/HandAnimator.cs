using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] float handDistance;
    [SerializeField] float moveRate = .1f;
    [SerializeField] Transform ikTarget;
    Vector3 targetPosition;

    Vector3 basePosition;
 
    private void Awake()
    {
        basePosition = targetPosition = ikTarget.transform.localPosition;
    }
    public void AnimateHandTowardsPosition(Vector3 position, bool right)
    {
        Vector3 offset = position - transform.position;
        offset = offset.normalized;
        offset *= handDistance;
        targetPosition = offset;
    }

    public void ResetHandTarget()
    {
        targetPosition = basePosition;
    }

    private void LateUpdate()
    {
        ikTarget.localPosition = Vector3.MoveTowards(ikTarget.localPosition, targetPosition, moveRate);
    }
}
