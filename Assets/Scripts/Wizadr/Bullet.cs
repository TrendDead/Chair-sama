using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private string _wizardName;
    [SerializeField] private GameObject _finishBullet;

    //[SerializeField] private AudioSource _sounbWoodBoom;

    private float _bulletVelocity;

    //private bool isActive = true;

    private void Start()
    {
        if (_wizardName == "blue")
        {
            _bulletVelocity = 7;
        }
        else if (_wizardName == "red")
        {
            _bulletVelocity = 20;
        }
        gameObject.GetComponent<Rigidbody>().velocity = -transform.forward * _bulletVelocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out WoodWall _woodWall) && _wizardName == "red")
        {
            _woodWall.DestroyWall();
        }
        Boom();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Wizard _wizard))
        {
            _wizard.Dead();
            Boom();
        }
        else if (other.gameObject.TryGetComponent(out FireSmokeTriger _fireWall))
        {
            if (_fireWall.GetStateBurning() && _wizardName == "blue") Boom();
            _fireWall.ExtinguishingFire(_wizardName);
        }
        else if (other.gameObject.TryGetComponent(out Button _button))
        {
            _button.OnButtonDown();
            Boom();
        }
    }

    private void Boom()
    {
        Instantiate(_finishBullet, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
