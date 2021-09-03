using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodWall : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    public void DestroyWall()
    {
        _sound.Play();
        GetComponent<Collider>().enabled = false;
        gameObject.transform.Rotate(0, 0, 90);
    }

}
