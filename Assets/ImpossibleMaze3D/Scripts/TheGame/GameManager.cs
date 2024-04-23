using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameSettingInfo _gameSetting;
    [SerializeField] CinemachineVirtualCamera _camera;
    [SerializeField] InputController _inputController;
    public static GameManager _INSTANCE;

    private void Awake()
    {
        if (_INSTANCE == null) _INSTANCE = this;
    }
    private void Start()
    {
        StartCoroutine(_loadSceneRoutine());
    }
    public GameStats _gameStat = GameStats.Paused;
    IEnumerator _loadSceneRoutine()
    {
        _inputController = GetComponent<InputController>();
        GameObject levelGO = Instantiate(_gameSetting._Levels[Abs.GameSetting.LevelSelection]._LevelMap, Vector3.zero, Quaternion.identity);
        _camera.Follow =
        levelGO.AddComponent<PuzzleController>()._SetupPuzzle(
            _gameSetting._Levels[Abs.GameSetting.LevelSelection]._XRotationBounds,
            _gameSetting._Levels[Abs.GameSetting.LevelSelection]._ZRotationBounds,
            _gameSetting._Levels[Abs.GameSetting.LevelSelection]._RotationSpeed,
            _gameSetting._Balls[Abs.GameSetting.BallSelection]
            );

        _inputController._controller = levelGO.GetComponent<PuzzleController>();
        _inputController._IsActive = true;

        TimeManager._Instance._ResetTimer(_gameSetting._Levels[Abs.GameSetting.LevelSelection]._TimeRequired);
        _gameStat = GameStats.Running;
        _gameSetting._Levels[Abs.GameSetting.LevelSelection]._SetLevelStarted();
        yield return null;

    }
    private void OnEnable()
    {
        PuzzleEndPoint.OnLevelEnded += PuzzleEndPoint_OnLevelEnded;
    }
    private void PuzzleEndPoint_OnLevelEnded()
    {
        StartCoroutine(_gameWin());

    }
    public void _TimeUp()
    {
        StartCoroutine( _gameLose());
    }
    private void OnDisable()
    {
        PuzzleEndPoint.OnLevelEnded -= PuzzleEndPoint_OnLevelEnded;
    }
    private void FixedUpdate()
    {
        if (BallController._INSTANCE)
            if (BallController._INSTANCE.transform.position.y < Abs.DefaultValues.DeadZoneY)
               StartCoroutine(_gameLose());
    }

    IEnumerator _gameLose()
    {
        BAHMANLoadingManager._INSTANCE._StartLoading();
        if (Abs.GameSetting.GameMode == GameModes.Arcade)
        {
            
            Abs.GameSetting.GameWon = false;
            Abs.GameSetting.ThisRunTime = _gameSetting._Levels[Abs.GameSetting.LevelSelection]._SetLevelEnded(Abs.GameSetting.GameWon);
        }
        yield return null;
        _endGame();
        
    }
    IEnumerator _gameWin()
    {
        BAHMANLoadingManager._INSTANCE._StartLoading();
        

        if(Abs.GameSetting.GameMode == GameModes.Arcade)
        {
            Abs.GameSetting.GameWon = true;
            Abs.GameSetting.ThisRunTime = _gameSetting._Levels[Abs.GameSetting.LevelSelection]._SetLevelEnded(Abs.GameSetting.GameWon);

            int nextLevel = Abs.GameSetting.LevelSelection + 1;
            if (nextLevel < _gameSetting._Levels.Length)
            {
                // Unlock Next Level

                _gameSetting._Levels[nextLevel]._SetLevelUnlock();
            }
            else
            {

                // All Level Done

                //GameManager._INSTANCE._AllLevelDone();
            }
            
        }
        yield return null;
        _endGame();
        
    }
    void _endGame()
    {
        
        BAHMANLoadingManager._INSTANCE._LoadScene((int)AllScenes.AftermathScene);
    }
    
    private void OnDestroy()
    {
        _gameSetting._Levels[Abs.GameSetting.LevelSelection]._NumberOfTries += 1;

    }
    
    
    
}
