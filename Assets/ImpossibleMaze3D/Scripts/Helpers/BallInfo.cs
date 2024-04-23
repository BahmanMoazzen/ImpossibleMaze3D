using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Ball", menuName = "Impossible Maze/New Ball", order = 0)]
public class BallInfo : ScriptableObject
{
    const float _ballRotationSpeed = 20f;
    public string _BallName;
    public string _BallDisplayName;
    public GameObject _BallPrefab;
    public PhysicMaterial _BallPhysics;
    public float _Weight;
    public float _Diameter;

    public bool _IsLocked
    {
        get
        {
            return bool.Parse(PlayerPrefs.GetString($"BALLINFOSAVETAG{_BallName}", "true"));
        }
        set
        {
            PlayerPrefs.SetString($"BALLINFOSAVETAG{_BallName}", value.ToString());
        }
    }
    public GameObject _SummonDisplayRotating(Transform iSummonPlace,Text iBallName,Text iBallDiameter,Text iBallWeight)
    {
        iBallName.text = _BallDisplayName;
        iBallWeight.text = Abs.Tools.WeightToText(_Weight);
        iBallDiameter.text = Abs.Tools.DiameterToText(_Diameter);
        GameObject summonedBall = Instantiate(_BallPrefab, iSummonPlace.position, Quaternion.identity);
        summonedBall.AddComponent<GameObjectRotator>()._RotateVector = Vector3.one * _ballRotationSpeed;
        return summonedBall;
    }
    public GameObject _SummonDisplayRotating(Transform iSummonPlace)
    {
        GameObject summonedBall = Instantiate(_BallPrefab, iSummonPlace.position, Quaternion.identity);
        summonedBall.AddComponent<GameObjectRotator>()._RotateVector = Vector3.one * _ballRotationSpeed;
        return summonedBall;
    }
}
