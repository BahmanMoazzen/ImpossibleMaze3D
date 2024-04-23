using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    
    public void _StartGame()
    {
        BAHMANLoadingManager._INSTANCE._LoadScene(AllScenes.LevelSelectScene);
    }
    
}
