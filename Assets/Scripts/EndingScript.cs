using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Resources;

public class EndingScript : MonoBehaviour
{
    GameObject frame1 = null;
    GameObject frame2 = null;
    GameObject frame3 = null;
    GameObject frame4 = null;
    GameObject frame5 = null;
    GameObject frame6 = null;
    GameObject frame7 = null;
    GameObject frame8 = null;
    GameObject frame9 = null;
    GameObject frame10 = null;
    GameObject playAgainBtn = null;

    void Start()
    {
        playAgainBtn = GameObject.FindGameObjectWithTag("playAgainBtn");
        playAgainBtn.SetActive(false);

        frame1 = GameObject.FindGameObjectWithTag("frame1");
        frame1.SetActive(true);

        frame2 = GameObject.FindGameObjectWithTag("frame2");
        frame2.SetActive(false);

        frame3 = GameObject.FindGameObjectWithTag("frame3");
        frame3.SetActive(false);

        frame4 = GameObject.FindGameObjectWithTag("frame4");
        frame4.SetActive(false);

        frame5 = GameObject.FindGameObjectWithTag("frame5");
        frame5.SetActive(false);

        frame6 = GameObject.FindGameObjectWithTag("frame6");
        frame6.SetActive(false);

        frame7 = GameObject.FindGameObjectWithTag("frame7");
        frame7.SetActive(false);

        frame8 = GameObject.FindGameObjectWithTag("frame8");
        frame8.SetActive(false);

        frame9 = GameObject.FindGameObjectWithTag("frame9");
        frame9.SetActive(false);

        frame10 = GameObject.FindGameObjectWithTag("frame10");
        frame10.SetActive(false);
    }

    public void NextFrame(string frame)
    {
        if (frame == "frame2")
        {
            frame1.SetActive(false);
            frame2.SetActive(true);
        }

        if (frame == "frame3")
        {
            frame2.SetActive(false);
            frame3.SetActive(true);
        }

        if (frame == "frame4")
        {
            frame3.SetActive(false);
            frame4.SetActive(true);
        }

        if (frame == "frame5")
        {
            frame4.SetActive(false);
            frame5.SetActive(true);
        }

        if (frame == "frame6")
        {
            frame5.SetActive(false);
            frame6.SetActive(true);
        }

        if (frame == "frame7")
        {
            frame6.SetActive(false);
            frame7.SetActive(true);
        }

        if (frame == "frame8")
        {
            frame7.SetActive(false);
            frame8.SetActive(true);
        }

        if (frame == "frame9")
        {
            frame8.SetActive(false);
            frame9.SetActive(true);
        }

        if (frame == "frame10")
        {
            frame9.SetActive(false);
            frame10.SetActive(true);
        }

        if (frame == "bg")
        {
            frame10.SetActive(false);
            playAgainBtn.SetActive(true);
        }
    }

    public void resetProgress()
    {
        regions = Resources.getRegions();

        foreach (Region region in regions)
        {
            region.active = true;
            System.Random rnd = new System.Random();
            int mapa1 = rnd.Next(10, 45);
            int mapa2 = rnd.Next(50, 100);
            int mapa3 = rnd.Next(-250, 500);
            mapa3 -= 100;
            if (mapa3 == 0) mapa3 = -50;
            if (region.mapName == "Mapa_1")
            {
                region.num = mapa1;
            }
            if (region.mapName == "Mapa_2")
            {
                region.num = mapa2;
            }
            if (region.mapName == "Mapa_3")
            {
                region.num = mapa3;
            }
        }
    }
}
