using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[Serializable]
public struct JoystickItem
{
    public JoystickOption JoystickType;
    public string JoystickName;
    public Sprite JoystickSprite;

}
[Serializable]
public struct MusicItem
{
    public MusicOption MusicOptionType;
    public string MusicOptionName;
    public Sprite MusicOptionSprite;

}
public enum JoystickOption { LeftHandJoystick, RightHandJoystick, LeftHandFourwing, RightHandFourwing, FullscreenFourwing }
public enum MusicOption { PlayMusic, MuteMusic }
public class OptionManager : MonoBehaviour
{
    const string JOYSTICKPREFIX = "JoystickSave", MUSICOPTIONPREFIX = "MusicOptionSave", OPTIONSHOWPREFIX = "ShowOptionSave";
    public static OptionManager _Instance;
    [SerializeField] GameObject _optionPanel;
    public static event UnityAction OnOptionChanged;
    [SerializeField] JoystickItem[] _joysticks;
    [SerializeField]
    MusicItem[] _musicOptions;
    [SerializeField] Text _joystickNameText;
    [SerializeField] Image _joystickImage;
    [SerializeField] Text _musicOptionNameText;
    [SerializeField] Image _musicOptionImage;

    int _currentJoystick, _currentMusicOption;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_Instance != null)
        {
            return;
        }
        _Instance = this;
    }
    public void _NextJoystick(int iIndex)
    {
        _currentJoystick = Abs.Tools.BoundIndex(_currentJoystick + iIndex, 0, _joysticks.Length - 1);
        PlayerPrefs.SetInt(JOYSTICKPREFIX, (int)_joysticks[_currentJoystick].JoystickType);
        Abs.GameSetting.Joystic = _joysticks[_currentJoystick].JoystickType;
        _loadJoystick();
    }
    public void _NextMusicOption(int iIndex)
    {
        _currentMusicOption = Abs.Tools.BoundIndex(_currentMusicOption + iIndex, 0, _musicOptions.Length - 1);
        PlayerPrefs.SetInt(MUSICOPTIONPREFIX, (int)_musicOptions[_currentMusicOption].MusicOptionType);
        Abs.GameSetting.MusicOption = _musicOptions[_currentMusicOption].MusicOptionType;
        switch (_musicOptions[_currentMusicOption].MusicOptionType)
        {
            case MusicOption.MuteMusic:
                BAHMANMusicBox._Instance._ChangePlayingStat(false);
                break;
            case MusicOption.PlayMusic:
                BAHMANMusicBox._Instance._ChangePlayingStat(true);
                break;
        }

        _loadMusicOption();
    }
    void _loadJoystick()
    {
        _joystickImage.sprite = _joysticks[_currentJoystick].JoystickSprite;
        _joystickNameText.text = _joysticks[_currentJoystick].JoystickName;


    }
    void _loadMusicOption()
    {
        _musicOptionImage.sprite = _musicOptions[_currentMusicOption].MusicOptionSprite;
        _musicOptionNameText.text = _musicOptions[_currentMusicOption].MusicOptionName;


    }
    void Start()
    {
        JoystickOption cj = (JoystickOption)PlayerPrefs.GetInt(JOYSTICKPREFIX, 0);
        for (int i = 0; i < _joysticks.Length; i++)
        {
            if (_joysticks[i].JoystickType == cj)
            {
                _currentJoystick = i;
                break;
            }
        }
        MusicOption cmo = (MusicOption)PlayerPrefs.GetInt(MUSICOPTIONPREFIX, 0);
        for (int i = 0; i < _musicOptions.Length; i++)
        {
            if (_musicOptions[i].MusicOptionType == cmo)
            {
                _currentMusicOption = i;
                break;
            }
        }
        Abs.GameSetting.Joystic = cj;
        Abs.GameSetting.MusicOption = cmo;


        _optionPanel.SetActive(PlayerPrefs.GetInt(OPTIONSHOWPREFIX, 0) == 0);
        PlayerPrefs.SetInt(OPTIONSHOWPREFIX, 1);
        _loadJoystick();
        _loadMusicOption();
    }

    public void _ShowPanel()
    {
        _optionPanel.SetActive(true);
    }

}
