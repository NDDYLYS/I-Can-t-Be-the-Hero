using System.Collections.Generic;
using UnityEngine;

public class LogManager : SingletonGameObject<LogManager>
{
    private Dictionary<LogCategoryEnum, bool> LogCategoryDic = new Dictionary<LogCategoryEnum, bool>();

    void Awake()
    {
#if UNITY_EDITOR
        foreach (LogCategoryEnum category in LogCategoryEnum.GetValues(typeof(LogCategoryEnum)))
        {
            SetLogCategory(category, true);
        }
#endif

        DontDestroyOnLoad(this);
    }

    public void SetLogCategory(LogCategoryEnum _category)
    {
        if (_category == LogCategoryEnum.All)
        {
            bool isAll = GetLogCategory(_category);
            for (int i = 0; i < (int)LogCategoryEnum.Max; i++)
            {
                if (_category != LogCategoryEnum.All)
                {
                    // All이 아니면 All과 같아진다
                    SetLogCategory((LogCategoryEnum)i, isAll);
                }
                else
                {
                    // All은 반대로 바뀐다
                    SetLogCategory((LogCategoryEnum)i, !isAll);
                }
            }
            return;
        }

        if (!LogCategoryDic.ContainsKey(_category))
        {
            LogCategoryDic.Add(_category, true);
        }
        else
        {
            LogCategoryDic[_category] = !LogCategoryDic[_category];
        }
    }

    public void SetLogCategory(LogCategoryEnum _category, bool _isOn)
    {
        if (!LogCategoryDic.ContainsKey(_category))
        {
            LogCategoryDic.Add(_category, true);
        }
        else
        {
            LogCategoryDic[_category] = _isOn;
        }
    }

    public bool GetLogCategory(LogCategoryEnum _category)
    {
        if (LogCategoryDic.ContainsKey(_category))
        {
            return LogCategoryDic[_category];
        }

        return false;
    }

    public void DebugLogCategory(LogCategoryEnum _category, string _log)
    {
        if (LogCategoryDic.ContainsKey(_category))
        {
            if (LogCategoryDic[_category] == true)
            {
                switch (_category)
                {
                    case LogCategoryEnum.UI:
                        DebugMethod("cyan", _category, _log);
                        break;
                    case LogCategoryEnum.Battle:
                        DebugMethod("magenta", _category, _log);
                        break;
                    case LogCategoryEnum.Error:
                        DebugMethod("red", _category, _log);
                        break;
                    case LogCategoryEnum.Etc:
                        DebugMethod("yellow", _category, _log);
                        break;
                    default:
                        DebugMethod("white", _category, _log);
                        break;
                }
            }
        }
    }

    private void DebugMethod(string _color, LogCategoryEnum _category, string _log)
    {
        Debug.Log(string.Format($"<color={_color}>[{_category}]</color> {_log}"));
    }
}