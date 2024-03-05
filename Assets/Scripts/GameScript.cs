using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Resources;

public class GameScript : MonoBehaviour
{

    [SerializeField]
    Text displayNumField;

    [SerializeField]
    Text oprText;

    List<Button> numbers = new List<Button>();

    Button opr = null;

    List<Button> inactiveButtons = new List<Button>();

    List<Button> inactiveDivButtons = new List<Button>();

    List<Region> regions = getRegions();

    Scene scene;
    
    int regionNum = 0;

    List<GameObject> uiElements = new List<GameObject>();

    bool displayUI = true;

    void Start()
    {
        LoadInitialConfig();
    }

    private void LoadInitialConfig()
    {
        scene = SceneManager.GetActiveScene();
        uiElements.Add(GameObject.FindGameObjectWithTag("backBtn"));
        uiElements.Add(GameObject.FindGameObjectWithTag("resetBtn"));
        uiElements.Add(GameObject.FindGameObjectWithTag("displayField"));
        uiElements.Add(GameObject.FindGameObjectWithTag("oprText"));
        GameObject[] numBtns = GameObject.FindGameObjectsWithTag("numBtn").ToArray();
        GameObject[] oprBtns = GameObject.FindGameObjectsWithTag("oprBtn").ToArray();
        foreach (GameObject numBtn in numBtns)
        {
            uiElements.Add(numBtn);
        }
        foreach (GameObject oprBtn in oprBtns)
        {
            uiElements.Add(oprBtn);
        }
        Region region = regions.Find(region => region.name == scene.name);
        regionNum = region.num;
        SetNum(regionNum);
        DisableButtonsWithTag("oprBtn");
    }

    public void ButtonPressed()
    {
        Button btn = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>();

        if (btn.tag == "numBtn")
        {
            if (!OprSelected())
            {
                btn.Select();
                oprText.text = btn.GetComponentInChildren<Text>().text;
                EnableButtonsWithTag("oprBtn");

                if (!numbers.Any())
                {
                    numbers.Add(btn);
                }
                else
                {
                    numbers[0] = btn;
                }
            } else
            {
                numbers.Add(btn);
                oprText.text += btn.GetComponentInChildren<Text>().text;
                var result = 0;
                int.TryParse(numbers[0].GetComponentInChildren<Text>().text, out int num1);
                int.TryParse(numbers[1].GetComponentInChildren<Text>().text, out int num2);

                if (opr.name == "-") result = num1 - num2;
                if (opr.name == "+") result = num1 + num2;
                if (opr.name == "*") result = num1 * num2;
                if (opr.name == "div") {
                    result = num1 / num2;
                    SetActiveDivButtons();
                }

                numbers[1].GetComponentInChildren<Text>().text = result.ToString();
                SemiClearAll();
                DisableButtonsWithTag("oprBtn");
                UnselectBtn();
                oprText.text += "=" + result.ToString();

                if (result.ToString() == displayNumField.text)
                {
                    GameObject.FindGameObjectWithTag("displayField").GetComponent<Button>().GetComponentInChildren<Text>().color = new Color32(8, 189, 94, 255);
                    DisableButtonsWithTag("numBtn");
                    GameObject.FindGameObjectWithTag("resetBtn").GetComponent<Button>().gameObject.SetActive(false);
                    GameObject[] oprBtns = GameObject.FindGameObjectsWithTag("oprBtn").Select(obj => obj.GetComponent<Button>().gameObject).ToArray();
                    foreach (GameObject oprBtn in oprBtns)
                    {
                        oprBtn.SetActive(false);
                    }
                    GameObject[] numBtns = GameObject.FindGameObjectsWithTag("numBtn").Select(obj => obj.GetComponent<Button>().gameObject).ToArray();
                    foreach (GameObject numBtn in numBtns)
                    {
                        numBtn.SetActive(false);
                    }
                    btn.gameObject.SetActive(true);
                    Region region = regions.Find(region => region.name == scene.name);
                    region.active = false;
                }
            }
        }

        if (btn.tag == "oprBtn")
        {
            numbers[0].gameObject.SetActive(false);
            inactiveButtons.Add(numbers[0]);
            opr = btn;
            if (opr.name != "div")
            {
                oprText.text += opr.name;
            } else
            {
                oprText.text += "/";
                GameObject[] numBtns = GameObject.FindGameObjectsWithTag("numBtn").Select(obj => obj.GetComponent<Button>().gameObject).ToArray();
                foreach (GameObject numBtn in numBtns)
                {
                    int.TryParse(numbers[0].GetComponentInChildren<Text>().text, out int numA);
                    int.TryParse(numBtn.GetComponentInChildren<Text>().text, out int numB);
                    if (!IsDivisibleBy(numA, numB))
                    {
                        inactiveDivButtons.Add(numBtn.GetComponent<Button>());
                        numBtn.SetActive(false);
                    }
                }
            }
            DisableButtonsWithTag("oprBtn");
        }
    }

    private bool IsDivisibleBy(int numA, int numB)
    {
        if (numB == 0) return false;
        return numA % numB == 0;
    }

    public void UnselectBtn()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    private void EnableButtonsWithTag(string tag)
    {
        Button[] buttonArray = GameObject.FindGameObjectsWithTag(tag).Select(obj => obj.GetComponent<Button>()).ToArray();
        foreach (Button displayBtn in buttonArray)
        {
            displayBtn.interactable = true;
        }
    }

    private void DisableButtonsWithTag(string tag)
    {
        Button[] buttonArray = GameObject.FindGameObjectsWithTag(tag).Select(obj => obj.GetComponent<Button>()).ToArray();
        foreach (Button displayBtn in buttonArray)
        {
            displayBtn.interactable = false;
        }
    }

    private void SetActiveButtons()
    {
        foreach (Button inactiveButton in inactiveButtons)
        {
            inactiveButton.gameObject.SetActive(true);
        }
        inactiveButtons.Clear();
    }

    private void SetActiveDivButtons()
    {
        foreach (Button inactiveButton in inactiveDivButtons)
        {
            inactiveButton.gameObject.SetActive(true);
        }
        inactiveDivButtons.Clear();
    }

    private void DefaultButtonValues()
    {
        Button[] buttonArray = GameObject.FindGameObjectsWithTag("numBtn").Select(obj => obj.GetComponent<Button>()).ToArray();
        foreach (Button displayBtn in buttonArray)
        {
            displayBtn.GetComponentInChildren<Text>().text = displayBtn.name;
        }
    }

    private bool OprSelected()
    {
        return opr != null;
    }

    public void handleUI()
    {
        if (displayUI)
        {
            hideUI();
        } else
        {
            showUI();
        }

        UnselectBtn();
    }

    private void hideUI()
    {
        displayUI = false;
        foreach (GameObject uiElement in uiElements)
        {
            if (uiElement.GetComponent<Image>() != null)
            {
                uiElement.GetComponent<Image>().enabled = false;
            }
            if (uiElement.GetComponentInChildren<Text>() != null)
            {
                uiElement.GetComponentInChildren<Text>().enabled = false;
            }
            if (uiElement.GetComponent<Text>() != null)
            {
                uiElement.GetComponent<Text>().enabled = false;
            }
        }
        GameObject.FindGameObjectWithTag("bgImage").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    private void showUI()
    {
        displayUI = true;
        foreach (GameObject uiElement in uiElements)
        {
            if (uiElement.GetComponent<Image>() != null)
            {
                uiElement.GetComponent<Image>().enabled = true;
            }
            if (uiElement.GetComponentInChildren<Text>() != null)
            {
                uiElement.GetComponentInChildren<Text>().enabled = true;
            }
            if (uiElement.GetComponent<Text>() != null)
            {
                uiElement.GetComponent<Text>().enabled = true;
            }
        }
        GameObject.FindGameObjectWithTag("bgImage").GetComponent<Image>().color = new Color32(255, 255, 255, 160);
    }

    private void SemiClearAll()
    {
        numbers = new List<Button>();
        opr = null;
        EnableButtonsWithTag("numBtn");
        EnableButtonsWithTag("oprBtn");
    }

    private void SetNum(int num)
    {
        displayNumField.text = num.ToString();
    }

    public void ClearAll()
    {
        numbers = new List<Button>();
        opr = null;
        oprText.text = "";
        SetNum(regionNum);
        SetActiveButtons();
        SetActiveDivButtons();
        DefaultButtonValues();
        EnableButtonsWithTag("numBtn");
        DisableButtonsWithTag("oprBtn");
    }
}
