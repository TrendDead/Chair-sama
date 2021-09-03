using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChaisseMove : MonoBehaviour
{
    private MenuCotrol _menu;
    private NumberSteps _numberSteps;
    [SerializeField] private AudioSource _soundCollision;
    [SerializeField] private AudioSource _soundMove;


    private bool _onWall;
    private void Start()
    {
        _onWall = false;
        _numberSteps = FindObjectOfType<NumberSteps>();
        _menu = FindObjectOfType<MenuCotrol>();
    }
    private void Update()
    {
        if (Input.anyKeyDown && !NumberSteps._stopMoving && !_menu.menu)
        {
            if (Input.GetKey(KeyCode.W)) Mover(new Vector3(0, -1, 0));
            if (Input.GetKey(KeyCode.S)) Mover(new Vector3(0, 1, 0));
            if (Input.GetKey(KeyCode.A)) Mover(new Vector3(-1, 0, 0));
            if (Input.GetKey(KeyCode.D)) Mover(new Vector3(1, 0, 0));
            if (Input.GetKeyDown(KeyCode.Q)) Rotator(new Vector3(0, 0, -90));
            if (Input.GetKeyDown(KeyCode.E)) Rotator(new Vector3(0, 0, 90));
        }
            
    }
    public void Mover(Vector3 v)
    {
        transform.Translate(v);
        int n = 1;
        if (Chaisse._chaisseFire) n = 3;
        _numberSteps.MinesNumberSteps(n);
        _onWall = true;
        _soundMove.pitch = Random.Range(0.9f, 1.1f);
        _soundMove.Play();
    }

    public void Rotator(Vector3 v)
    {
        gameObject.transform.Rotate(v);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out RockWall wall) && _onWall)
        {
            _soundCollision.Play();
            _onWall = false;
        }
    }
}
