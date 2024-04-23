using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleEndPoint : MonoBehaviour
{
    public static event UnityAction OnLevelEnded;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Abs.Tags.BallTag)
            OnLevelEnded?.Invoke();
    }
}
