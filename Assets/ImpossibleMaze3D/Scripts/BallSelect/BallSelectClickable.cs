using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSelectClickable : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    public static event UnityAction<GameObject> OnClick;
    private void OnMouseDown()
    {
        OnClick?.Invoke(_ball);
        Debug.Log("Ball Clicked");
    }
}
