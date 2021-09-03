using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSmokeTriger : MonoBehaviour
{
    public bool _stateBurning = true;

    private FireWall _fireWall;
    private SmokeWall _smokeWall;

    private void Start()
    {
        _fireWall = GetComponentInChildren<FireWall>();
        _smokeWall = GetComponentInChildren<SmokeWall>();
        _fireWall.gameObject.SetActive(true);
        _smokeWall.gameObject.SetActive(false);
    }

    public bool GetStateBurning()
    {
        return _stateBurning;
    }
    public void ExtinguishingFire(string _wizardName)
    {
        if (_stateBurning && _wizardName == "blue")
        {
            _stateBurning = false;
            _fireWall.gameObject.SetActive(false);
            _smokeWall.gameObject.SetActive(true);
        }
        else if (!_stateBurning && _wizardName == "red")
        {
            _stateBurning = true;
            _fireWall.gameObject.SetActive(true);
            _smokeWall.gameObject.SetActive(false);
        }
    }
}
