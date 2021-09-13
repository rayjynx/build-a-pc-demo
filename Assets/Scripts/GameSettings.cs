using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    #region Unity Singleton pattern

    private static GameSettings _instance;

    public static GameSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameSettings>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("_Singleton_GameSettings");
                    _instance = go.AddComponent<GameSettings>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }


    #endregion

    #region Static names

    static readonly string SETTINGS_FILE = "settings.json";

    #endregion

    #region Public Properties 

    public bool IsReady { get; private set; }

    public List<string> QualityNames { get; private set; }

    public List<Resolution> Resolutions { get; private set; }

    public UserGameOptions UserOptions { get; private set; }

    #endregion

    #region Unity messages

    private void Awake()
    {
        QualityNames = new List<string>(QualitySettings.names);
        Resolutions = new List<Resolution>(Screen.resolutions);

        UserOptions = LoadOptions();        
        IsReady = true;
    }

    #endregion

    #region Public methods

    public void SaveSettings(int quality, int width, int height, bool fullscreen)
    {
        var settings = new UserGameOptions()
        {
            quality = quality,
            fullScreen = fullscreen,
            height = height,
            width = width,
        };

        string fullPath = Path.Combine(Application.persistentDataPath, SETTINGS_FILE);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        File.WriteAllText(fullPath, JsonUtility.ToJson(settings));

        ApplySettings(settings);
    }

    #endregion

    #region Private helper methods

    UserGameOptions LoadOptions()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, SETTINGS_FILE);

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            var settings = JsonUtility.FromJson<UserGameOptions>(json);
            ApplySettings(settings);
            return settings;
        }
        else
        {
            return new UserGameOptions() 
            {
                quality = QualitySettings.GetQualityLevel(), 
                fullScreen = Screen.fullScreen, 
                height = Screen.height, 
                width = Screen.width 
            };
           

            
        }
    }

    void ApplySettings(UserGameOptions settings)
    {
        QualitySettings.SetQualityLevel(settings.quality);
        Screen.SetResolution(settings.width, settings.height, settings.fullScreen);
    }
    #endregion
}
