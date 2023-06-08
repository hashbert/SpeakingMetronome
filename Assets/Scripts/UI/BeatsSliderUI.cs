using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatsSliderUI : MonoBehaviour
{
    public static event Action<int> OnBeatsChanged;

    [SerializeField] private Slider _BeatsSlider;

    public void OnEnable()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        _BeatsSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void OnDisable()
    {
        _BeatsSlider.onValueChanged.RemoveListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        OnBeatsChanged?.Invoke((int)_BeatsSlider.value);
    }
}
