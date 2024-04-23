using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PuzzleController : MonoBehaviour
{
    [SerializeField] Vector2 _XRotationBounds;
    [SerializeField] Vector2 _ZRotationBounds;
    [SerializeField] float _RotationSpeed;
    Vector3 _currentRotations = Vector3.zero;

    public Transform _SetupPuzzle(Vector2 iXRotationBound, Vector2 iZRotationBound,float iRotationSpeed,BallInfo iBallInfo)
    {
        _XRotationBounds = iXRotationBound;
        _ZRotationBounds = iZRotationBound;
        
        // update ui slider bounds
        UIManager._INSTANCE._SetSliders(iXRotationBound, iZRotationBound);

        _RotationSpeed = iRotationSpeed;
        GameObject ball = Instantiate(iBallInfo._BallPrefab, GameObject.Find(Abs.Tags.StartPointName).transform.position,Quaternion.identity);
        ball.AddComponent<Rigidbody>().mass = iBallInfo._Weight;

        ball.AddComponent<SphereCollider>().radius = iBallInfo._Diameter / 2;
        ball.GetComponent<SphereCollider>().material = iBallInfo._BallPhysics;
        ball.AddComponent<BallController>();
        return ball.transform;
    }
    public void _RotatePuzzle(Vector3 iRotation)
    {

        iRotation *= Time.deltaTime * _RotationSpeed * -1;
        _currentRotations += iRotation;
        _boundRotation();
        transform.rotation = Quaternion.Euler(_currentRotations);
        UIManager._INSTANCE._UpdateSliders(-_currentRotations.x, _currentRotations.z);

        
    }
    
    void _boundRotation()
    {
        if (_currentRotations.x > _XRotationBounds.y)
        {
            _currentRotations.x = _XRotationBounds.y;
        }
        else if (_currentRotations.x < _XRotationBounds.x)
        {
            _currentRotations.x = _XRotationBounds.x;
        }

        if (_currentRotations.z > _ZRotationBounds.y)
        {
            _currentRotations.z = _ZRotationBounds.y;
        }
        else if (_currentRotations.z < _ZRotationBounds.x)
        {
            _currentRotations.z = _ZRotationBounds.x;
        }
        _currentRotations.y = 0;


        
    }
}
