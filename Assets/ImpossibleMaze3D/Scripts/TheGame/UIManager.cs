using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //[SerializeField] GameObject[] _UIsGameObject;
    public static UIManager _INSTANCE;
    [SerializeField] Text _timeText;
    [SerializeField] Slider _horizontalSlider, _verticalSlider;

    private void Awake()
    {
        if (_INSTANCE == null) _INSTANCE = this;
    }
    public void _UpdateTimer(int iTime)
    {
        _timeText.text = Abs.Tools.SecondsToTime(iTime);
    }
    public void _UpdateSliders(float iHorizontalValue, float iVerticalValue)
    {
        _horizontalSlider.value = iHorizontalValue;
        _verticalSlider.value = iVerticalValue;
    }
    public void _SetSliders(Vector2 iHorizontalBounds, Vector2 iVerticalBounds)
    {
        _horizontalSlider.minValue = iHorizontalBounds.x;
        _horizontalSlider.maxValue = iHorizontalBounds.y;
        _verticalSlider.minValue = iVerticalBounds.x;
        _verticalSlider.maxValue = iVerticalBounds.y;
    }
    //void FixedUpdate()
    //{
    //    if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
    //    {
    //        _UIsGameObject[(byte)UIOrientations.Vertical].SetActive(false);
    //        _UIsGameObject[(byte)UIOrientations.Horizontal].SetActive(true);
    //    }
    //    else
    //    {
    //        _UIsGameObject[(byte)UIOrientations.Vertical].SetActive(true);
    //        _UIsGameObject[(byte)UIOrientations.Horizontal].SetActive(false);
    //    }
    //}
}
//public enum UIOrientations {Vertical,Horizontal }
