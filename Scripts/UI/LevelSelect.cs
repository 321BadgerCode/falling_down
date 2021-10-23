using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject ChaptersMenu;
    public GameObject CampaighnMenu;
    public GameObject CampaighnButton;
    public GameObject SurvivalMenu;
    public GameObject SurvivalButton;

    public void Chapters()
    {
        ChaptersMenu.SetActive(true);

        CampaighnButton.SetActive(false);
        SurvivalButton.SetActive(false);
    }

    public void Campaighn()
    {
        CampaighnMenu.SetActive(true);

        CampaighnButton.SetActive(false);
        SurvivalButton.SetActive(false);
    }

    public void Survival()
    {
        SurvivalMenu.SetActive(true);

        CampaighnButton.SetActive(false);
        SurvivalButton.SetActive(false);
    }
}
