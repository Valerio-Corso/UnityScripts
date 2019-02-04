using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    #region Audio

    const string volumeDialoguesKey = "dialoguesVolume";
    const string volumeEffectsKey = "effectsVolume";
    const string volumeMasterKey = "masterVolume";
    const string volumeMusicKey = "musicVolume";

    void StoreDialoguesVolume(float value)
    {
        PlayerPrefs.SetFloat(volumeDialoguesKey, value);
    }

    float GetDialoguesVolume(float defaultValue = 50)
    {
        return PlayerPrefs.GetFloat(volumeDialoguesKey, defaultValue);
    }

    void StoreEffectsVolume(float value)
    {
        PlayerPrefs.SetFloat(volumeEffectsKey, value);
    }


    float LoadEffectsVolume(float defaultValue = 50)
    {
        return PlayerPrefs.GetFloat(volumeEffectsKey, defaultValue);
    }

    void StoreMasterVolume(float value)
    {
        PlayerPrefs.SetFloat(volumeMasterKey, value);
    }


    float LoadMasterVolume(float defaultValue = 50)
    {
        return PlayerPrefs.GetFloat(volumeMasterKey, defaultValue);
    }

    void StoreMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(volumeMusicKey, value);
    }

    float LoadMusicVolume(float defaultValue = 50)
    {
        return PlayerPrefs.GetFloat(volumeMusicKey, defaultValue);
    }

    #endregion

    #region Language

    const string languageKey = "language";

    public enum Languages
    {
        English,
        Italian,
        German,
        French
    }

    void StoreLanguage(Languages value)
    {
        PlayerPrefs.SetInt(languageKey, (int)value);
    }

    int LoadLanguage(int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(languageKey, defaultValue);
    }

    #endregion

    #region Internal Helpers

    void SetBool(string key, bool value)
    {
        var intValue = value ? 1 : 0;
        PlayerPrefs.SetInt(key, intValue);
    }

    bool GetBool(string key, bool defaultValue = false)
    {
        var value = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);

        return value == 1;
    }

    #endregion
}
