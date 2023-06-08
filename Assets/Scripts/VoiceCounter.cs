using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceCounter : MonoBehaviour
{
    public int BPM { get; private set; }
    private int _defaultBPM = 80;
    public int Beats { get; private set; }
    private int _defaultBeats = 8;

    private float _timeBetweenBeats;
    private float _timeUntilNextBeat;
    public static event Action<int> OnIndexChanged;
    private int _indexOfNumbers = 0;
    private const int SECONDS_IN_MINUTE = 60;
    
    [SerializeField] private AudioClipRefsSO _audioClipRefsSO;
    // Start is called before the first frame update
    void Start()
    {
        InitializeSaveOrDefault();
        SetBPM();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilNextBeat -= Time.deltaTime;
        if (_timeUntilNextBeat <= 0)
        {
            _timeUntilNextBeat = _timeBetweenBeats;
            SoundManager.Instance.PlaySound(_audioClipRefsSO, _indexOfNumbers);
            OnIndexChanged?.Invoke(_indexOfNumbers);
            _indexOfNumbers++;
            if (_indexOfNumbers >= Beats)
            {
                _indexOfNumbers = 0;
            }
        }
    }

    private void OnEnable()
    {
        BeatsSliderUI.OnBeatsChanged += BeatsSliderUI_OnBeatsChanged;
        BPMSliderUI.OnBPMChanged += BPMSliderUI_OnBPMChanged;
    }
    private void OnDisable()
    {
        BeatsSliderUI.OnBeatsChanged -= BeatsSliderUI_OnBeatsChanged;
        BPMSliderUI.OnBPMChanged -= BPMSliderUI_OnBPMChanged;
    }
    private void BPMSliderUI_OnBPMChanged(int value)
    {
        BPM = value;
        SetBPM();
        PlayerPrefs.SetInt("BPM", value);
    }

    private void BeatsSliderUI_OnBeatsChanged(int value)
    {
        Beats = value;
        PlayerPrefs.SetInt("Beats", value);
    }

    private void SetBPM()
    {
        _timeBetweenBeats = (float)SECONDS_IN_MINUTE / (float)BPM;
        _timeUntilNextBeat = _timeBetweenBeats;
    }

    private void InitializeSaveOrDefault()
    {
        if (PlayerPrefs.HasKey("BPM"))
        {
            BPM = PlayerPrefs.GetInt("BPM");
        }
        else
        {
            BPM = _defaultBPM;
        }

        if (PlayerPrefs.HasKey("Beats"))
        {
            Beats = PlayerPrefs.GetInt("Beats");
        }
        else
        {
            Beats = _defaultBeats;
        }
    }
}
