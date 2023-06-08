using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    private void OnEnable()
    {
        VoiceCounter.OnIndexChanged+=UpdateBeatCounterText;
    }
    private void OnDisable()
    {
        VoiceCounter.OnIndexChanged-=UpdateBeatCounterText;
    }

    private void UpdateBeatCounterText(int indexNumber)
    {
        int beatNumber = indexNumber + 1;
        _countText.text = beatNumber.ToString();
    }
}
