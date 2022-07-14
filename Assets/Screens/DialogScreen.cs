using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScreen : ScreenBase
{
    [SerializeField] Speaker _left;
    [SerializeField] Speaker _right;

    [SerializeField] Color _speakerHighLightColor;

    [SerializeField] Text _currSpeakerName;
    [SerializeField] Text _currReplicaText;

    [SerializeField] float _charPerSecond;

    private Dialog _currDialog;
    private int _currReplicaIndex;

    private Coroutine _currTypeCoroutine;
    private string _currReplica;

    public event Action DialogEnded;

    private void Awake()
    {
        InitBase();
        _currDialog = null;
        _currTypeCoroutine = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _currDialog != null)
        {
            if (_currTypeCoroutine == null)
            {
                if (_currDialog.Replics.Length <= _currReplicaIndex)
                {
                    _currDialog = null;
                    DialogEnded?.Invoke();
                }
                else
                {
                    NextReplica(_currDialog.Replics[_currReplicaIndex]);
                }
            }
            else
            {
                _currReplicaText.text = _currReplica;
                StopCoroutine(_currTypeCoroutine);
                _currTypeCoroutine = null;
            }
        }
    }

    public void InitScreen(Dialog d)
    {
        _currDialog = d;
        _currReplicaIndex = 0;
        NextReplica(_currDialog.Replics[_currReplicaIndex]);
    }

    private void NextReplica(Replica r)
    {
        _currReplicaIndex++;

        _left.Hide();
        _right.Hide();

        var currSpeaker = r.IsLeftSpeaker ? _left : _right;
        _currSpeakerName.text = currSpeaker.Name;
        currSpeaker.Highlight(_speakerHighLightColor);
        _currReplica = r.Text;

        _currTypeCoroutine = StartCoroutine(TypeText(r.Text));
    }

    private IEnumerator TypeText(string text)
    {
        int charCount = 0;
        while (charCount < text.Length)
        {
            charCount++;
            _currReplicaText.text = text.Substring(0, charCount);

            yield return new WaitForSeconds(1f / _charPerSecond);
        }

        _currTypeCoroutine = null;
    }
}
