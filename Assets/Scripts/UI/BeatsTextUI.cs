using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeatsTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _beatsText;

    private void OnEnable()
    {
        BeatsSliderUI.OnBeatsChanged += BeatsSliderUI_OnBeatsChanged;
    }

    private void OnDisable()
    {
        BeatsSliderUI.OnBeatsChanged -= BeatsSliderUI_OnBeatsChanged;
    }

    private void BeatsSliderUI_OnBeatsChanged(int value)
    {
        _beatsText.text = "Beats: " + value.ToString();
    }

    private void OnBeatsChanged(int value)
    {
        _beatsText.text = "Beats: " + value.ToString();
    }
}
