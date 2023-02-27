using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ColorPalette : MonoBehaviour
{
    Image background;
    Image panel;
    int currentPaletteNumber = 0;

    Color[] colorsOfBackground = new Color[3] { new Color (0.3764706f, 0.3764706f, 0.3764706f),
                                                new Color(0.5372549f, 0.6705883f, 0.8901961f),
                                                new Color(0.9764706f, 0.3411765f, 0) };
    Color[] colorsOfGrid = new Color[3] { new Color(0.8392157f, 0.9294118f, 09019608f),
                                          new Color(0.9882353f, 0.9647059f, 0.9607843f),
                                          new Color(1, 1, 1) };


    void Start()
    {
        background = GameObject.Find("Background").GetComponent<Image>();
        panel = GameObject.Find("Panel").GetComponent<Image>();

        SetColor();
    }
    public void NextPalette()
    {
        if (currentPaletteNumber < colorsOfBackground.Length - 1)
        {
            currentPaletteNumber++;
            SetColor();
        }
        else
        {
            currentPaletteNumber = 0;
            SetColor();
        }
    }
    void SetColor()
    {
        background.color = colorsOfBackground[currentPaletteNumber];
        panel.color = colorsOfGrid[currentPaletteNumber];
    }
}