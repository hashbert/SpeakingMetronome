using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPMSliderUI : MonoBehaviour
{
    public static event Action<int> OnBPMChanged;

    [SerializeField] private Slider _BPMSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BPM"))
        {
            _BPMSlider.value = (float)PlayerPrefs.GetInt("BPM");
        }
    }
    public void OnEnable()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        _BPMSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void OnDisable()
    {
        _BPMSlider.onValueChanged.RemoveListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        OnBPMChanged?.Invoke((int)_BPMSlider.value);
    }
}
