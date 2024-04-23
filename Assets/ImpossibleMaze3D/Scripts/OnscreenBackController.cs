using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnscreenBackController : MonoBehaviour
{
    [SerializeField] AllScenes _BackScene;
    public void _Back()
    {
        BAHMANLoadingManager._INSTANCE._LoadScene(_BackScene);
    }

}
