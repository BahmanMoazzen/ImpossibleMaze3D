using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Game Setting",menuName ="Impossible Maze/New Game Setting",order =1)]
public class GameSettingInfo : ScriptableObject
{
    public LevelInfo[] _Levels;
    public BallInfo[] _Balls;
}
