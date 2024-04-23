using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] AllScenes _level2Load;
    // Start is called before the first frame update
    void Start()
    {
        BAHMANLoadingManager._INSTANCE._LoadScene((int)_level2Load);
    }

    
}
