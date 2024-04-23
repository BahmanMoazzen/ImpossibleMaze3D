using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    //[SerializeField] GameObject _Ball;
    [SerializeField] FixedJoystick _leftHandJoystick, _rightHandJoystick;
    [SerializeField] GameObject _leftHandFourwing, _rightHandFourwing, _fullscreenFourwing;
    [SerializeField] Text _Debug;
    FixedJoystick _mainJoystick;
    // Start is called before the first frame update
    public PuzzleController _controller;
    public bool _IsActive { get; set; }

    bool _rotateByUI = false;
    Vector3 _uiRotation = Vector3.zero;
    private void Start()
    {
        _leftHandJoystick.gameObject.SetActive(false);
        _rightHandJoystick.gameObject.SetActive(false);
        _leftHandFourwing.SetActive(false);
        _rightHandFourwing.SetActive(false);
        _fullscreenFourwing.SetActive(false);

        switch (Abs.GameSetting.Joystic)
        {
            case JoystickOption.LeftHandJoystick:
                _leftHandJoystick.gameObject.SetActive(true);
                _mainJoystick = _leftHandJoystick;
                break;
            case JoystickOption.RightHandJoystick:
                _rightHandJoystick.gameObject.SetActive(true);
                _mainJoystick = _rightHandJoystick;
                break;
            case JoystickOption.LeftHandFourwing:
                _leftHandFourwing.SetActive(true);
                break;
            case JoystickOption.RightHandFourwing:
                _rightHandFourwing.SetActive(true);
                break;
            case JoystickOption.FullscreenFourwing:
                _fullscreenFourwing.SetActive(true);
                break;
        }
    }

    public void _RotateUp()
    {
        _rotateByUI = true;
        _uiRotation = new Vector3(0, 0, 1);
    }
    public void _StopRotateUp()
    {
        _rotateByUI = false;
    }
    public void _RotateDown()
    {
        _rotateByUI = true;
        _uiRotation = new Vector3(0, 0, -1);

    }
    public void _StopRotateDown()
    {
        _rotateByUI = false;
    }

    public void _RotateLeft()
    {
        _rotateByUI = true;
        _uiRotation = new Vector3(-1, 0, 0);
    }
    public void _StopRotateLeft()
    {
        _rotateByUI = false;
    }

    public void _RotateRight()
    {
        _rotateByUI = true;
        _uiRotation = new Vector3(1, 0, 0);
    }

    public void _StopRotateRight()
    {
        _rotateByUI = false;
    }
    private void FixedUpdate()
    {
        if (_IsActive)
        {
            #region Accelerometer 

            Vector3 accelerometerDirection = Vector3.zero;

            // we assume that device is held parallel to the ground
            // and Home button is in the right hand

            // remap device acceleration axis to game coordinates:
            //  1) XY plane of the device is mapped onto XZ plane
            //  2) rotated 90 degrees around Y axis
            accelerometerDirection.x = -Input.acceleration.y;
            accelerometerDirection.z = Input.acceleration.x;
            _Debug.text = $"({accelerometerDirection.x},{accelerometerDirection.y},{accelerometerDirection.z})-";
            // clamp acceleration vector to unit sphere
            if (accelerometerDirection.sqrMagnitude > 1)
                accelerometerDirection.Normalize();
            _Debug.text += $"N:({accelerometerDirection.x},{accelerometerDirection.y},{accelerometerDirection.z})";
            //_controller._RotatePuzzle(new Vector3(accelerometerDirection.x, 0, accelerometerDirection.z));

            #endregion
            if (!_rotateByUI)
            {
                if (_mainJoystick)
                {
                    float XAxisValue;
                    float ZAxisValue;
                    XAxisValue = _mainJoystick.Horizontal;
                    ZAxisValue = _mainJoystick.Vertical;
                    //Keyboard
                    //float XAxisValue = Input.GetAxisRaw("Horizontal");
                    //float ZAxisValue = Input.GetAxisRaw("Vertical");
                    _controller._RotatePuzzle(new Vector3(XAxisValue, 0, ZAxisValue));
                }
            }
            else
            {
                _controller._RotatePuzzle(_uiRotation);
            }
        }

    }


}
