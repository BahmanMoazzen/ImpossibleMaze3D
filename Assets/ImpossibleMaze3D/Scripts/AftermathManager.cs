using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AftermathManager : MonoBehaviour
{
    [SerializeField] GameObject _winText, _looseText,_endGameText,_endGameParticle;
    [SerializeField] GameSettingInfo _gameSetting;
    [SerializeField] Text _timeDisplay;
    IEnumerator Start()
    {
        _timeDisplay.text = Abs.Tools.SecondsToTime(Abs.GameSetting.ThisRunTime);
        yield return null;
        if (Abs.GameSetting.GameWon && Abs.GameSetting.LevelSelection == _gameSetting._Levels.Length - 1)
        {
            _winText.SetActive(false);
            _looseText.SetActive(false);
            _endGameText.SetActive(true);
            _endGameParticle.SetActive(true);
        }
        else
        {
            _endGameParticle.SetActive(false);
            _endGameText.SetActive(false);
            _winText.SetActive(Abs.GameSetting.GameWon);
            _looseText.SetActive(!Abs.GameSetting.GameWon);
            
        }
    }

    public void _LevelSelect()
    {
        BAHMANLoadingManager._INSTANCE._LoadScene((int)AllScenes.LevelSelectScene);

    }
}
