using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public SettingsMenu settingsMenu; // Reference to the SettingsMenu script
    public Slider slider;

    private const string VolumePrefKey = "MasterVolume";

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey, 0f);
        slider.value = savedVolume;

        settingsMenu.SetVolume(savedVolume);

        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        settingsMenu.SetVolume(value);
        PlayerPrefs.SetFloat(VolumePrefKey, value);
    }
}
