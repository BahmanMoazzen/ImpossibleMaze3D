using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager _Instance;
    public int _LevelTime = 0;
    
    
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
    }
    public void _ResetTimer(int iTimeAmount)
    {

        StartCoroutine(_Timer(iTimeAmount));
    }
    public void _AddTime(int iTimeAmount)
    {

        _LevelTime += iTimeAmount;
       
        UIManager._INSTANCE._UpdateTimer(_LevelTime);
    }
    public IEnumerator _Timer(int iTime)
    {

        _LevelTime = iTime;
        UIManager._INSTANCE._UpdateTimer(_LevelTime);
        while (true)
        {
            
            yield return new WaitForSeconds(Abs.DefaultValues.GameSpeed);
            // set the game stat here.
            if (GameManager._INSTANCE._gameStat == GameStats.Running)
                _LevelTime--;
            UIManager._INSTANCE._UpdateTimer(_LevelTime);
            if (_LevelTime <= 0)
            {
                GameManager._INSTANCE._TimeUp();
                break;
            }

        }


    }
}
