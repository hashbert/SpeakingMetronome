using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitializeSaveData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _BPMText;
    [SerializeField] private Slider _BPMSlider;
    [SerializeField] private TextMeshProUGUI _beatsText;
    [SerializeField] private Slider _beatsSlider;

    // Start is called before the first frame update
    void Start()
    {
        InitializeBPM();
        InitializeBeats();
    }

    private void InitializeBeats()
    {
        if (PlayerPrefs.HasKey("Beats"))
        {
            _beatsText.text = "Beats: " + PlayerPrefs.GetInt("Beats").ToString();
            _beatsSlider.value = PlayerPrefs.GetInt("Beats");
        }
    }

    private void InitializeBPM()
    {
        if (PlayerPrefs.HasKey("BPM"))
        {
            _BPMText.text = "BPM: " + PlayerPrefs.GetInt("BPM").ToString();
            _BPMSlider.value = PlayerPrefs.GetInt("BPM");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
