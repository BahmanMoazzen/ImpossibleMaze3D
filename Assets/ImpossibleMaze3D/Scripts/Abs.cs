using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameStats { Paused, Running }

public enum GameModes { Arcade,FreeRide}
public static class Abs
{
    
    public static class Tools
    {
        public static int BoundIndex(int iIndex, int iMinIndex, int iMaxIndex)
        {
            int returnValue = iIndex;
            if (returnValue > iMaxIndex)
            {
                returnValue = iMinIndex;
            }
            else if (returnValue < iMinIndex)
            {
                returnValue = iMaxIndex;
            }

            return returnValue;

        }
        public static int BoundIndexStopAtBariers(int iIndex, int iMinIndex, int iMaxIndex)
        {
            int returnValue = iIndex;
            if (returnValue > iMaxIndex)
            {
                returnValue = iMaxIndex;
            }
            else if (returnValue < iMinIndex)
            {
                returnValue = iMinIndex;
            }

            return returnValue;

        }
        public static string SecondsToTime(int iSeconds)
        {
            string min = Mathf.RoundToInt(iSeconds / 60).ToString();
            if (min.Length == 1) min = $"0{min}";
            string sec = (iSeconds - Mathf.RoundToInt(iSeconds / 60) * 60).ToString() ;
            if(sec.Length == 1) sec = $"0{sec}" ;

            return $"{min}:{sec}";

        }
        public static string WeightToText(float iWeight)
        {
            if(iWeight < 1)
            {
                return $"{iWeight*1000} گرم";
            }
            else
            {
                return $"{iWeight} کیلوگرم";
            }
        }
        public static string DiameterToText(float iDiameter)
        {
            if (iDiameter < 1)
            {
                return $"{iDiameter * 100} سانتی متر";
            }
            else
            {
                return $"{iDiameter} متر";
            }
        }
        public static string ReverseString(string iString)
        {
            string ns = string.Empty;
            for(int i = iString.Length-1; i >=0; i--)
            {
                ns += iString[i];

            }

            return ns ;
        }
    }
    public static class GameSetting
    {
        public static int BallSelection;
        public static int LevelSelection;
        public static bool GameWon;
        public static JoystickOption Joystic;
        public static MusicOption MusicOption;
        public static int ThisRunTime;
        public static GameModes GameMode;
    }
    public static class DefaultValues
    {
        public static int IsPlayedValue = 1;
        public static int IsNotPlayedValue = 0;
        public static int DeadZoneY = -10;
        public static float GameSpeed = 1;

    }
    public static class Tags
    {
        public static string BallTag = "Ball";
        public static string StartPointName = "Start";
        //public static string BallInfoSaveTag = "BallInfo_";

    }

    public static class Messages
    {
        public static class LevelEntrance
        {
            public static string Title = "توجه";
            public static string Message = "برای ورود به این مرحله {0} سکه از شما کسر می شود. وارد می شوید؟";
        }
        public static class Shop
        {
            public static string PurchaseSuccess = "خرید با موفقیت انجام شد";
            public static string PurchaseFail = "خرید ناموفق!";
        }
    }
}
