using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SummeryManager : MonoBehaviour
{
    [SerializeField] GameSettingInfo _gameSetting;
    [SerializeField] Transform _levelSummonPlace, _ballSummonPlace;
    [SerializeField] Text _ballNameDisplay, _levelNameDisplay;
    [SerializeField] GameObject _arrowPrefab;
    [SerializeField] SaveableItem _coin;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _gameSetting._Balls[Abs.GameSetting.BallSelection]._SummonDisplayRotating(_ballSummonPlace);
        _ballNameDisplay.text = _gameSetting._Balls[Abs.GameSetting.BallSelection]._BallDisplayName;
        _gameSetting._Levels[Abs.GameSetting.LevelSelection]._SummonDisplayRotating(_levelSummonPlace, _arrowPrefab);
        _levelNameDisplay.text = _gameSetting._Levels[Abs.GameSetting.LevelSelection]._LevelDisplayName;
        yield return null;
    }

    public void _ConfirmStart()
    {

        //BAHMANMessageBoxManager._INSTANCE._ShowYesNoBox(Abs.Messages.LevelEntrance.Title, string.Format(Abs.Messages.LevelEntrance.Message, _gameSetting._Levels[Abs.GameSetting.LevelSelection]._EntranceCoin), _YesSelected);
        BAHMANLoadingManager._INSTANCE._LoadScene(AllScenes.GameScene);
    }
    void _YesSelected()
    {

        if (_coin._ChangeAmount(_gameSetting._Levels[Abs.GameSetting.LevelSelection]._EntranceCoin, true))
        {
            BAHMANLoadingManager._INSTANCE._LoadScene(AllScenes.GameScene);
        }
        else
        {
            ShopManager._INSTANCE._ShowShop();
        }
    }
}
