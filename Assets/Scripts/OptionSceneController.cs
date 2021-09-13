using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionSceneController : MonoBehaviour
{
    List<Resolution> filteredRes;

    bool fullScreen;    

    public Dropdown quality;

    public Dropdown resolution;

    public Toggle fullScreenToggle;

    public void FullScreen_Clicked(bool newValue)
    {
        fullScreen = newValue;
    }

    public void Apply_Clicked()
    {
        Resolution res = filteredRes[resolution.value];
        int qual = quality.value;
        GameSettings.Instance.SaveSettings(qual, res.width, res.height, fullScreen);
    }

    IEnumerator Start()
    {
        while (!GameSettings.Instance.IsReady)
        {
            yield return null;
        }

        var user = GameSettings.Instance.UserOptions;

        quality.ClearOptions();
        quality.AddOptions(GameSettings.Instance.QualityNames);
        quality.value = user.quality;


        List<string> resos = new List<string>();
        filteredRes = new List<Resolution>();


        int lw = -1;
        int lh = -1;

        int index = 0;
        int currentResIndex = -1;

        foreach (var res in GameSettings.Instance.Resolutions)
        {
            if (lw != res.width || lh != res.height)
            {


                string fmt = string.Format("{0} x {1}", res.width, res.height);
                resos.Add(fmt);

                lw = res.width;
                lh = res.height;

                if (lw == user.width && lh == user.height)
                {
                    currentResIndex = index;
                }

                filteredRes.Add(res);

                index++;
            }
        }

        resolution.ClearOptions();
        resolution.AddOptions(resos);
        resolution.value = currentResIndex;

        fullScreenToggle.isOn = user.fullScreen;
    }
}   
