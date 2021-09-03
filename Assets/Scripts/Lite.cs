using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lite : MonoBehaviour
{
    private void Start()
    {
        Chaisse.SitWizard = 1;
    }
    void Update()
    {
        gameObject.transform.Rotate(0, 0.5f, 0);
    }
}
