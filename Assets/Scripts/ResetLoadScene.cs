using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLoadScene : MonoBehaviour
{
    public static int _level;
    public int Level;
    private NumberSteps _numberSteps;
    private void Awake()
    {
        Level = _level;
        _numberSteps = FindObjectOfType<NumberSteps>();
        int n = 100;
        switch (Level)
        {
            case 0:
                n = 60; 
                break;
            case 1:
                n = 160;
                break;
            case 2:
                n = 1000;
                break;
            default:
                
                break;
        }
        _numberSteps.NumberStepsInstal(n);
    }
    public static void NextScene()
    {
        _level += 1;
        ResetScene();
    }
    public static void ResetScene()
    {
        Debug.Log(_level);
        Chaisse.SitWizard = 0;
        SceneManager.LoadScene(_level);
    }
}
