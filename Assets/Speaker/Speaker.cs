using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speaker : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] Image _border;

    public string Name => _name;

    private void Awake()
    {
        Hide();
    }

    public void Highlight(Color color)
    {
        _border.enabled = true;
        _border.color = color;
    }

    public void Hide()
    {
        _border.enabled = false;
    }
}
