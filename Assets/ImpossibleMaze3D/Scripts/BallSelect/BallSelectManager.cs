using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallSelectManager : MonoBehaviour
{
    [SerializeField] GameSettingInfo _gameSetting;
    [SerializeField] SaveableItem _coin;
    [SerializeField] Transform _summonPlace;
    [SerializeField] Text _ballNameText, _ballDiameterText, _ballWeightText;
    int _currentBall = 0;
    GameObject _summonedBall;
    const float _ballRotationSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _currentBall = Abs.GameSetting.BallSelection;
        StartCoroutine(_loadBall());
    }
    IEnumerator _loadBall()
    {

        _summonedBall = _gameSetting._Balls[_currentBall]._SummonDisplayRotating(_summonPlace, _ballNameText, _ballDiameterText, _ballWeightText);

        yield return 0;

    }
    public void _SelectBall()
    {
        Abs.GameSetting.BallSelection = _currentBall;
        BAHMANLoadingManager._INSTANCE._LoadScene(AllScenes.SummeryScene);
        //BAHMANMessageBoxManager._INSTANCE._ShowYesNoBox(Abs.Messages.LevelEntrance.Title, string.Format(Abs.Messages.LevelEntrance.Message, _gameSetting._Levels[Abs.GameSetting.LevelSelection]._EntranceCoin), _YesSelected);
    }
    void _YesSelected()
    {

        Abs.GameSetting.BallSelection = _currentBall;

        if (_coin._ChangeAmount(_gameSetting._Levels[Abs.GameSetting.LevelSelection]._EntranceCoin, true))
        {
            BAHMANLoadingManager._INSTANCE._LoadScene((int)AllScenes.GameScene);
        }
        else
        {
            ShopManager._INSTANCE._ShowShop();
        }
    }
    public void _SummonNext(int iIndexer)
    {
        StopAllCoroutines();
        if (_summonedBall != null)
        {
            Destroy(_summonedBall);
        }
        _currentBall = Abs.Tools.BoundIndex(_currentBall + iIndexer, 0, _gameSetting._Balls.Length - 1);
        StartCoroutine(_loadBall());
    }

}
