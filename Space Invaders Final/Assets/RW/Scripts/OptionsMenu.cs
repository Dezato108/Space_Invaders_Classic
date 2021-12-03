using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown ressolutionDopdown;

    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        ressolutionDopdown.ClearOptions();

        List<string> optionsRes = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate+"hz";
            optionsRes.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        ressolutionDopdown.AddOptions(optionsRes);
        ressolutionDopdown.value = currentResolutionIndex;
        ressolutionDopdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetVolume (float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex,true);
        Debug.Log(qualityIndex);
	}

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}
