using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Replica
{
    [SerializeField] bool _isLeftSpeaker;
    [SerializeField] string _text;

    public bool IsLeftSpeaker => _isLeftSpeaker;
    public string Text => _text;
}
