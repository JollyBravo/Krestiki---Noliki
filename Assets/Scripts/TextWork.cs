using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextWork : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1Name;
    [SerializeField] TextMeshProUGUI player2Name;
    [SerializeField] public TextMeshProUGUI player1WinsText;
    [SerializeField] public TextMeshProUGUI player2WinsText;
    string playerName1 = "Crosses";
    string playerName2 = "Circles";
    [SerializeField] public int player1Wins = 0;
    [SerializeField] public int player2Wins = 0;

    Turn turn;
    ColorPalette colorPalette;

    // Start is called before the first frame update
    void Start()
    {
        turn = FindObjectOfType<Turn>();
        colorPalette = FindObjectOfType<ColorPalette>();

        player1Name.text = playerName1;
        player2Name.text = playerName2;
        player1WinsText.text = player1Wins.ToString();
        player2WinsText.text = player2Wins.ToString();
    }

    public void ScoreReset()
    {
        turn.ResetGrid();
        player1Wins = 0;
        player2Wins = 0;
        player1WinsText.text = player1Wins.ToString();
        player2WinsText.text = player2Wins.ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ColorChange()
    {
        colorPalette.NextPalette();
    }

}
