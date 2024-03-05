using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Resources;

public class MapScript : MonoBehaviour
{
    public List<Region> regions;

    GameObject mapWindow = null;

    GameObject endingButton = null;

    bool allRegionsCleared = true;

    Scene scene;

    void Start()
    {
        regions = Resources.getRegions();
        scene = SceneManager.GetActiveScene();

        foreach (Region region in regions)
        {
            if (region.active && region.mapName == scene.name)
            {
                allRegionsCleared = false;
            }

            if (!region.active && region.mapName == scene.name)
            {
                DisableButtonWithTag(region.name);
            }
        }

        mapWindow = GameObject.FindGameObjectWithTag("mapWindow");
        mapWindow.SetActive(false);

        endingButton = GameObject.FindGameObjectWithTag("endBtn");
        endingButton.SetActive(false);

        if (allRegionsCleared)
        {
            endingButton.SetActive(true);
            endingButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    private void DisableButtonWithTag(string tag)
    {
        Button button = GameObject.FindGameObjectWithTag(tag).GetComponent<Button>();
        button.interactable = false;
    }

    public void OpenMapWindow(string mapName)
    {
        mapWindow.SetActive(true);
    }

    public void CloseMapWindow(string mapName)
    {
        mapWindow.SetActive(false);
    }
}
