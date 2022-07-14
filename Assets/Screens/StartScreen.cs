using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : ScreenBase
{
    [SerializeField] RectTransform _dialogBtnContainer;
    [SerializeField] Button _dialogBtnPrefab;

    private int _heightPerBtn;
    private List<Button> _buttons;

    public event Action<Dialog> DialogChoosen;

    private void Awake()
    {
        InitBase();
        _buttons = new List<Button>();
        _heightPerBtn = Screen.height / 10;
    }

    public void LoadDialogs(Dialog[] dialogs)
    {
        foreach (var d in dialogs)
        {
            var newBtn = Instantiate(_dialogBtnPrefab, _dialogBtnContainer);
            newBtn.GetComponentInChildren<Text>().text = d.Name;
            newBtn.onClick.AddListener(() => DialogChoosen?.Invoke(d));
            _buttons.Add(newBtn);
        }

        _dialogBtnContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _heightPerBtn * _buttons.Count);
    }
}
