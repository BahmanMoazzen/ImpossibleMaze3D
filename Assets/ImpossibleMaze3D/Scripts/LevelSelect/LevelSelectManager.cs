using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] GameSettingInfo _gameSetting;
    [SerializeField] Transform _summonPlace;
    [SerializeField] Text _titleText, _bestTimeText, _totalTimeText;
    [SerializeField] Button _selectButton, _nextButton;
    [SerializeField] GameObject _arrowPrefab, _newLevelText, _lockedLevelText;
    int _currentLevel = 0;
    GameObject _summonedLevel;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _currentLevel = _gameSetting._Levels.Length - 1;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        for (int i = 0; i < _gameSetting._Levels.Length; i++)
        {
            if (_gameSetting._Levels[i]._GetIsLevelLocked())
            {
                _currentLevel = i - 1;
                break;

            }
        }
        yield return StartCoroutine(_loadLevel());

    }
    IEnumerator _loadLevel()
    {

        
        
        // check if the level is never played
        _newLevelText.SetActive(!_gameSetting._Levels[_currentLevel]._GetIsLevelPlayed());

        // check the level lock and set the buttons
        _nextButton.interactable = _selectButton.interactable = !_gameSetting._Levels[_currentLevel]._GetIsLevelLocked();

        // activating lock text
        _lockedLevelText.SetActive(_gameSetting._Levels[_currentLevel]._GetIsLevelLocked());

        // instantiation level mesh and adding rotator component
        yield return _summonedLevel = _gameSetting._Levels[_currentLevel]._SummonDisplayRotating(_summonPlace, _arrowPrefab, _titleText, _bestTimeText, _totalTimeText);



    }
    public void _SelectLevel()
    {
        Abs.GameSetting.LevelSelection = _currentLevel;
        BAHMANLoadingManager._INSTANCE._LoadScene((int)AllScenes.BallSelectScene);

    }
    public void _SummonNext(int iIndexer)
    {
        StopAllCoroutines();
        if (_summonedLevel != null)
        {
            Destroy(_summonedLevel);
        }
        _currentLevel = Abs.Tools.BoundIndexStopAtBariers(_currentLevel + iIndexer, 0, _gameSetting._Levels.Length - 1);
        StartCoroutine(_loadLevel());
    }

}
