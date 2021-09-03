using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberSteps : MonoBehaviour
{
    [SerializeField] private Slider _numberSlider;
    [SerializeField] private Text _numberStepsText;
    [SerializeField] private float _numberGameSteps;

    [SerializeField] public static bool _stopMoving;

    private void Start()
    {
        //_stopMoving = false;
        //_numberSlider.maxValue = _numberGameSteps;
        //_numberSlider.value = _numberGameSteps;
        //_numberStepsText.text = _numberSlider.value.ToString();
    }

    public void NumberStepsInstal(int n = 100)
    {
        _stopMoving = false;
        _numberSlider.maxValue = n;
        _numberSlider.value = n;
        _numberStepsText.text = _numberSlider.value.ToString();
    }
    public void MinesNumberSteps(int n = 1)
    {
        _numberSlider.value -= n;

        _numberStepsText.text =  _numberSlider.value.ToString();

        if(_numberSlider.value <= 0)
        {
            _stopMoving = true;
        }
    }

    public void PlasNumberSteps()
    {
        _numberSlider.value += 5;
        _numberStepsText.text = _numberSlider.value.ToString();
    }
}
