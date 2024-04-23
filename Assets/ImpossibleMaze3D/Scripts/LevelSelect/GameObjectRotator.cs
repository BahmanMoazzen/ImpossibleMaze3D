using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRotator : MonoBehaviour
{
    public Vector3 _RotateVector = new Vector3(0f,20f,0f);
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.Rotate( _RotateVector * Time.deltaTime );
    }
}
