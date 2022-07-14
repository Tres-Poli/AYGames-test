using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConfig : MonoBehaviour
{
    public static DialogConfig Instance { get; private set; }

    [SerializeField] Dialog[] _dialogs;

    public Dialog[] Dialogs => _dialogs;

    private void Awake()
    {
        Instance = this;
    }
}
