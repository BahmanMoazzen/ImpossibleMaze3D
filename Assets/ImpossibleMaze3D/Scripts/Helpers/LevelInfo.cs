using System;
using UnityEngine;
using UnityEngine.UI;
using static Abs;

[CreateAssetMenu(fileName = "New Level", menuName = "Impossible Maze/New Level", order = 1)]

public class LevelInfo : ScriptableObject
{

    [Header("Level Config")]
    public string _LevelName;
    public string _LevelDisplayName;
    public GameObject _LevelMap;
    public int _TimeRequired;
    public bool _isTutorial = false;
    [Header("PuzzleController Parameters")]
    public Vector2 _XRotationBounds;
    public Vector2 _ZRotationBounds;
    public float _RotationSpeed;
    [Header("Coin Information")]
    public int _EntranceCoin;
    public int _PriceCoin;

    [Header("Saveable Config")]
    [SerializeField] LevelLockStatus _isLocked;
    [SerializeField] LevelPlayedStat _isPlayed;
    [SerializeField] LevelClearanceStat _isCleared;
    [SerializeField] int _completionTime;
    [SerializeField] int _bestPersonalTime;
    [SerializeField] int _numberOfTries;

    float _startTime;

    public LevelLockStatus _IsLocked
    {
        get
        {
            return (LevelLockStatus)PlayerPrefs.GetInt($"LVLLOCK{_LevelName}", (int)_isLocked);

        }
        set
        {

            PlayerPrefs.SetInt($"LVLLOCK{_LevelName}", (int)value);

        }
    }

    public LevelPlayedStat _IsPlayed
    {
        get
        {
            return (LevelPlayedStat)PlayerPrefs.GetInt($"LVLPLAYED{_LevelName}", (int)_isPlayed);

        }
        set
        {
            PlayerPrefs.SetInt($"LVLPLAYED{_LevelName}", (int)value);

        }
    }
    public LevelClearanceStat _IsCleared
    {
        get
        {
            return (LevelClearanceStat)PlayerPrefs.GetInt($"ISCLEAR{_LevelName}", (int)_isCleared);

        }
        set
        {
            PlayerPrefs.SetInt($"ISCLEAR{_LevelName}", (int)value);

        }
    }
    public int _CompletionTime
    {
        get
        {
            return PlayerPrefs.GetInt($"COMPLETIONTIME{_LevelName}", _completionTime);

        }
        set
        {
            PlayerPrefs.SetInt($"COMPLETIONTIME{_LevelName}", value);


        }
    }
    public int _BestPersonalTime
    {
        get
        {
            return PlayerPrefs.GetInt($"BESTPERSONAL{_LevelName}", _bestPersonalTime);
        }
        set
        {
            PlayerPrefs.SetInt($"BESTPERSONAL{_LevelName}", value);
        }
    }
    public int _NumberOfTries
    {
        get
        {
            return PlayerPrefs.GetInt($"NUMBEROFTRIES{_LevelName}", _numberOfTries);

        }
        set
        {
            PlayerPrefs.SetInt($"NUMBEROFTRIES{_LevelName}", value);

        }
    }

    public void _AddNumberOfTries(int iNumberOfTriesAmount)
    {
        _NumberOfTries += iNumberOfTriesAmount;
    }
    public void _AddCompletionTime(int iCompletionAmount)
    {
        _CompletionTime += iCompletionAmount;
    }

    public void _SetLevelPlayed()
    {
        _IsPlayed = LevelPlayedStat.Played;
    }
    public void _SetLevelCleared()
    {
        _IsCleared = LevelClearanceStat.Cleared;
    }
    public void _SetLevelUnlock()
    {
        _IsLocked = LevelLockStatus.Unlocked;
    }

    public void _SetLevelStarted()
    {
        _startTime = Time.time;
    }
    void _setBestPractice(int iPlayDuration)
    {
        if (iPlayDuration < _BestPersonalTime || _BestPersonalTime.Equals(0))
        {
            _BestPersonalTime = iPlayDuration;
        }
    }

    public int _SetLevelEnded(bool iWin)
    {
        int duration = Mathf.RoundToInt(Time.time - _startTime);

        _SetLevelPlayed();

        _AddCompletionTime(duration);

        if (iWin)
        {
            _setBestPractice(duration);
            _SetLevelCleared();

        }


        return duration;

    }

    public bool _GetIsLevelCleared()
    {
        return _IsCleared == LevelClearanceStat.Cleared;
    }
    public bool _GetIsLevelPlayed()
    {
        return _IsPlayed == LevelPlayedStat.Played;
    }
    public bool _GetIsLevelLocked()
    {
        return _IsLocked == LevelLockStatus.Locked;
    }

    public GameObject _SummonDisplayRotating(Transform iSummonPlace, GameObject iStartPointer, Text iLevelTitle, Text iLevelBestPractice, Text iLevelTotalTime)

    {
        // setting level title
        iLevelTitle.text = _LevelDisplayName;

        // setting times of level
        iLevelBestPractice.text = Abs.Tools.SecondsToTime(_BestPersonalTime);
        iLevelTotalTime.text = Abs.Tools.SecondsToTime(_CompletionTime);

        GameObject summonedLevel = Instantiate(_LevelMap, iSummonPlace.position, Quaternion.identity);
        Instantiate(iStartPointer, GameObject.Find(Abs.Tags.StartPointName).transform);
        summonedLevel.AddComponent<GameObjectRotator>();

        return summonedLevel;
    }
    public GameObject _SummonDisplayRotating(Transform iSummonPlace, GameObject iStartPointer)

    {
        

        GameObject summonedLevel = Instantiate(_LevelMap, iSummonPlace.position, Quaternion.identity);
        Instantiate(iStartPointer, GameObject.Find(Abs.Tags.StartPointName).transform);
        summonedLevel.AddComponent<GameObjectRotator>();

        return summonedLevel;
    }
}
public enum LevelLockStatus { Unlocked, Locked }
public enum LevelPlayedStat { NotPlayed, Played }
public enum LevelClearanceStat { NotCleared, Cleared }