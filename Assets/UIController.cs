using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] StartScreen _startScreen;
    [SerializeField] DialogScreen _dialogScreen;

    private Dictionary<ScreenType, ScreenBase> _screensMap;

    private void Awake()
    {
        _screensMap = new Dictionary<ScreenType, ScreenBase>();
        _screensMap.Add(ScreenType.StartScreen, _startScreen);
        _screensMap.Add(ScreenType.DialogScreen, _dialogScreen);
    }

    private void Start()
    {
        _startScreen.DialogChoosen += OnDialogChoosen;
        _startScreen.LoadDialogs(DialogConfig.Instance.Dialogs);

        _dialogScreen.DialogEnded += OnDialogEnded;

        SwitchScreen(ScreenType.StartScreen);
    }

    private void OnDialogChoosen(Dialog d)
    {
        _dialogScreen.InitScreen(d);
        SwitchScreen(ScreenType.DialogScreen);
    }

    private void OnDialogEnded()
    {
        SwitchScreen(ScreenType.StartScreen);
    }

    public void SwitchScreen(ScreenType type)
    {
        foreach (var s in _screensMap)
        {
            s.Value.Hide(true);
        }

        _screensMap[type].Hide(false);
    }
}

public enum ScreenType
{
    StartScreen = 0,
    DialogScreen = 1,
}
