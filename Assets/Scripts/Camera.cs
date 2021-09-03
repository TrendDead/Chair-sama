using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 _cameraPosition;
    
    [SerializeField] private float _changingCameraY;
    [SerializeField] private float _changingCameraZ;

    [SerializeField] private float _changingRotation;

    private float _cameraRotation;
    void Update()
    {
        _cameraPosition = gameObject.transform.localPosition;
        _cameraRotation = gameObject.transform.rotation.x;
    }

    public void ChangCamera(int n)
    {
        gameObject.transform.localPosition = new Vector3(_cameraPosition.x,
            _cameraPosition.y + _changingCameraY * n,
            _cameraPosition.z + _changingCameraZ * n);

        gameObject.transform.Rotate(new Vector3(_changingRotation * n, 0, 0));
    }
}
