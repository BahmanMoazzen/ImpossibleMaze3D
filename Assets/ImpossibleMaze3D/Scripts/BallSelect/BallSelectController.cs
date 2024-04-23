using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelectController : MonoBehaviour
{
    [SerializeField] GameObject[] _ballGameObjects;
    [SerializeField] CinemachineVirtualCamera _ballCamera;
    int _currentBall = 0;
    public void _GotoNext(int iIndex)
    {
        _currentBall = Abs.Tools.BoundIndex(_currentBall + iIndex,0,_ballGameObjects.Length-1);
        _ballCamera.LookAt =_ballGameObjects[_currentBall].transform;
    }
    


}
