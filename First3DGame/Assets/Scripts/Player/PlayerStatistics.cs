using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatistics
{
    public static int CountFrags;

    public static void Save()
    {
        PlayerPrefs.SetInt("Frags", CountFrags);
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("Frags"))
        {
            return;
        }
        CountFrags = PlayerPrefs.GetInt("Frags");
    }
}
