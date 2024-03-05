using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    GameObject creditsWindow = null;
    GameObject startWindow = null;
    GameObject tutorial1 = null;
    GameObject tutorial2 = null;
    GameObject tutorial3 = null;
    GameObject tutorial4 = null;
    GameObject tutorial5 = null;
    GameObject pickMap = null;

    void Start()
    {
        creditsWindow = GameObject.FindGameObjectWithTag("creditsWindow");
        creditsWindow.SetActive(false);

        tutorial1 = GameObject.FindGameObjectWithTag("tutorial1");
        tutorial1.SetActive(false);

        tutorial2 = GameObject.FindGameObjectWithTag("tutorial2");
        tutorial2.SetActive(false);

        tutorial3 = GameObject.FindGameObjectWithTag("tutorial3");
        tutorial3.SetActive(false);

        tutorial4 = GameObject.FindGameObjectWithTag("tutorial4");
        tutorial4.SetActive(false);

        tutorial5 = GameObject.FindGameObjectWithTag("tutorial5");
        tutorial5.SetActive(false);

        pickMap = GameObject.FindGameObjectWithTag("pickMap");
        pickMap.SetActive(false);

        startWindow = GameObject.FindGameObjectWithTag("startWindow");
        startWindow.SetActive(false);
    }

    public void OpenCreditsWindow()
    {
        creditsWindow.SetActive(true);
    }

    public void CloseCreditsWindow()
    {
        creditsWindow.SetActive(false);
    }

    public void OpenStartWindow()
    {
        startWindow.SetActive(true);
        tutorial1.SetActive(true);
    }

    public void CloseStartWindow()
    {
        startWindow.SetActive(false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
        pickMap.SetActive(false);
    }

    public void GoNext(string path)
    {
        if (path == "tutorial2")
        {
            tutorial1.SetActive(false);
            tutorial2.SetActive(true);
        }

        if (path == "tutorial3")
        {
            tutorial2.SetActive(false);
            tutorial3.SetActive(true);
        }

        if (path == "tutorial4")
        {
            tutorial3.SetActive(false);
            tutorial4.SetActive(true);
        }

        if (path == "tutorial5")
        {
            tutorial4.SetActive(false);
            tutorial5.SetActive(true);
        }

        if (path == "pickMap")
        {
            tutorial5.SetActive(false);
            pickMap.SetActive(true);
        }
    }
}
