using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BPMTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _BPMText;

    private void OnEnable()
    {
        BPMSliderUI.OnBPMChanged += BPMSliderUI_OnBPMChanged;
    }
    private void OnDisable()
    {
        BPMSliderUI.OnBPMChanged -= BPMSliderUI_OnBPMChanged;
    }
    private void BPMSliderUI_OnBPMChanged(int value)
    {
        _BPMText.text = "BPM: " + value.ToString();
    }
}
