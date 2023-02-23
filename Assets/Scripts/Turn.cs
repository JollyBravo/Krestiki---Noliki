using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turn : MonoBehaviour
{
    [SerializeField] int playerTurn = 0; //Player 1 turn = 0, Player 2 = 1
    [SerializeField] Sprite[] sprites;
    [SerializeField] Button[] buttons;
    [SerializeField] TextMeshProUGUI player1Name;
    [SerializeField] TextMeshProUGUI player2Name;
    [SerializeField] int[] buttonsOfGrid = new int[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    string playerName1 = "test";
    string playerName2 = "Test2";
    int player1Wins = 0;
    int player2Wins = 0;


    void Start()
    {
        player1Name.text = playerName1.ToString();
        player2Name.text = playerName2.ToString();
    }

    void Update()
    {
        
    }
    public void PutSymbol(int GridNumber)
    {
        buttons[GridNumber].image.sprite = sprites[playerTurn];
        buttons[GridNumber].interactable = false;

        buttonsOfGrid[GridNumber] = playerTurn;

        Debug.Log("Button" + GridNumber + "Pressed");

        if (playerTurn == 0)
        {
            playerTurn = 1;
        }
        else
        {
            playerTurn = 0;
        }
    }
}
