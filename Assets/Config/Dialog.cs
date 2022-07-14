using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Dialog
{
    [SerializeField] string _name;
    [SerializeField] Replica[] _replics;

    public string Name => _name;
    public Replica[] Replics => _replics;
}
