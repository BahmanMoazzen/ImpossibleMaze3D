using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController _INSTANCE;
    //public Vector3 _CurrentPosition {  get; private set; }
    private void Awake()
    {
        if(_INSTANCE == null ) _INSTANCE = this;

    }
    
}
