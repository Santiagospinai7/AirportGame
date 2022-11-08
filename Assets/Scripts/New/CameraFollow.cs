using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private bool _lookAt;
    [SerializeField] private float _smoothSpeed = 0.125f;

    private float _tempYPos;

    private void LateUpdate()
    {
        Vector3 desiredPos = _target.transform.position + _offSet;
        desiredPos.y = _offSet.y + _tempYPos;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPos, _smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;

        if (_lookAt)
            transform.LookAt(_target);
    }

    public void AlignIfJumping(float playerHeight)
    {
        RaycastHit hit;
        if (Physics.Raycast(_target.position, -Vector3.up, out hit))
        {
            _tempYPos = hit.point.y + playerHeight;
        }
    }
}
