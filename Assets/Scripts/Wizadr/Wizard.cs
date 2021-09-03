using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Chaisse target;
    [SerializeField] private Transform _target;

    [SerializeField] private Wizard stateSit;
    [SerializeField] private Wizard stateToStand;

    [SerializeField] public bool dead = false;
    [SerializeField] public bool look = true;

    [SerializeField] private Transform _departurePoint;
    [SerializeField] private Bullet _bullet;
    public bool flag;


    private Collider _collider;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        if (!flag) target = FindObjectOfType<Chaisse>();
        _target = target.transform;
        _collider = gameObject.GetComponent<Collider>();
        if (dead) Dead();
        if (!dead && !look)
        {
            gameObject.transform.position = transform.parent.position;
            double angal = Math.Round(transform.parent.rotation.y, 1);
            float coefficient = 0;
            if (angal == 0.0f)
            {
                coefficient = 180;
            }
            else if (angal == 0.5f)
            {
                coefficient = 270;
            }
            else if (angal == -0.5f)
            {
                coefficient = 90;
            }
            else
            {
                coefficient = 0;
            }
            gameObject.transform.Rotate(0, coefficient, 0);
        }
    }
    void Update()
    {
        if (!dead && look) LookOnTarget();
    }

    private void LookOnTarget()
    {
        Vector3 direction = (transform.position - _target.position).normalized;
        Quaternion lockRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lockRotation, Time.deltaTime * 10);
    }    

    public void Dead()
    {
        stateToStand.dead = true;
        //dead = true;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.transform.Rotate(90, 0 , 0);
        _collider.enabled = false;
    
    }

    public void Sit()
    {
        if (Chaisse.SitWizard != 0) Dead();
        else
        {
            Chaisse.SitWizard = 1;
            _camera.ChangCamera(1);
            stateSit.look = false;
            //look = false;
            Instantiate(stateSit, _target, true);
            Destroy(gameObject);
        }
    }
    public void ResetDeadWizard()
    {
        Chaisse.SitWizard = 0;
        _camera.ChangCamera(-1);
        Dead();
        Instantiate(stateToStand, _target.position - new Vector3(0, 0.9f, 0), Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }

    public void Shot()
    {
        Instantiate(_bullet, _departurePoint.position, _departurePoint.rotation);
    }
}
