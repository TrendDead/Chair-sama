using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaisse : MonoBehaviour
{

    private MenuCotrol _menu;

    [SerializeField] public static int SitWizard = 0;
    [SerializeField] private GameObject _fire;

    [SerializeField] private GameObject _soulsGo;

    [SerializeField] private AudioSource _electricicty;
    [SerializeField] private AudioSource _fireSound;


    private NumberSteps _numberSteps;

    public static bool _chaisseFire;

    private Wizard _wizard;
    private void Start()
    {
        _menu = FindObjectOfType<MenuCotrol>();
        _numberSteps = FindObjectOfType<NumberSteps>();
        _fire.SetActive(false);
        _chaisseFire = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Wizard _wizard))
        {
            if (_wizard)
                _wizard.Sit();
        }
        else if (other.gameObject.TryGetComponent(out FireSmokeTriger _fireWall))
        {
            if (_fireWall._stateBurning)
                ChaisseStartFire();
        }
        else if (other.gameObject.TryGetComponent(out Button _button))
        {
            _button.OnButtonDown();
        }
        //Wizard _wizard = other.gameObject.GetComponent<Wizard>();

    }

    private void Update()
    {
        if (Input.anyKeyDown && !NumberSteps._stopMoving && !_menu.menu)
        {
            if (Input.GetKeyDown(KeyCode.R) && SitWizard == 1)
            {
                _electricicty.Play();
                _numberSteps.PlasNumberSteps();
                ResetWizard();


            }
            if (Input.GetKeyDown(KeyCode.Space) && SitWizard == 1)
            {
                ShotWizard();
                int n = 1;
                if (Chaisse._chaisseFire) n = 3;
                _numberSteps.MinesNumberSteps(n);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ResetLoadScene.ResetScene();
        }
        if (NumberSteps._stopMoving)
        {
            _soulsGo.SetActive(true);
        }
    }
    private void ResetWizard()
    {
        _wizard = GetComponentInChildren<Wizard>();
        _wizard.ResetDeadWizard();
    }

    private void ShotWizard()
    {
        _wizard = GetComponentInChildren<Wizard>();
        _wizard.Shot();
    }

    private void ChaisseStartFire()
    {
        _fireSound.Play();
        _chaisseFire = true;
        _fire.SetActive(true);
    }
}
