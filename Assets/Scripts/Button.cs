using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource _soundButton;

    [SerializeField] private Transform _redButton;
    [SerializeField] private MetalWall _metalWallDown;
    [SerializeField] private MetalWall _metalWallUp;
    private AudioSource _metalWallOpenDown;
    private AudioSource _metalWallOpenUp;
    private float _positionYDown;
    private float _positionYUp;

    private float _time;

    private bool _flagDown;
    private bool _flagUp;

    private void Start()
    {
        _metalWallOpenDown = _metalWallDown.GetComponent<AudioSource>();
        _flagDown = false;
        _positionYDown = _metalWallDown.transform.position.y;

        _metalWallOpenUp = _metalWallUp.GetComponent<AudioSource>();
        _flagUp = false;
        _positionYUp = _metalWallUp.transform.position.y;
    }


    private void Update()
    {
        if(_flagDown && _positionYDown < _metalWallDown.transform.position.y + 2.9f)
        {
            _metalWallDown.transform.position = new Vector3(_metalWallDown.transform.position.x,
                _positionYDown + (_time - Time.time),
                _metalWallDown.transform.position.z);
        }
        if (_flagUp && _positionYUp > _metalWallUp.transform.position.y - 2.9f)
        {
            _metalWallUp.transform.position = new Vector3(_metalWallUp.transform.position.x,
                _positionYUp - (_time - Time.time),
                _metalWallUp.transform.position.z);
        }
    }

    public void OnButtonDown()
    {
        GetComponent<Collider>().enabled = false;
        _time = Time.time;
        _redButton.localPosition = new Vector3(0.32f, 0, -0.03f);
        _flagDown = true;
        _flagUp = true;
        _metalWallOpenDown.Play();
        _metalWallOpenUp.Play();
        _soundButton.Play();
    }
}
