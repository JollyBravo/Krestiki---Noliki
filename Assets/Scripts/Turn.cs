using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Turn : MonoBehaviour
{
    [SerializeField] int playerTurn = 0; //Player 1 turn = 0, Player 2 = 1
    [SerializeField] Sprite[] sprites;
    [SerializeField] Button[] buttons;
    [SerializeField] int turnNumber = 1;


    [SerializeField] int[] buttonsOfGrid = new int[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    TextWork textWork;

    private void Awake()
    {
        textWork = FindObjectOfType<TextWork>();
    }


    void Start()
    {
        textWork.player1WinsText.text = textWork.player1Wins.ToString();
        textWork.player2WinsText.text = textWork.player2Wins.ToString();

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
            WinConditionForPlayer1();
            playerTurn = 1;
        }
        else
        {
            WinConditionForPlayer2();
            playerTurn = 0;
        }

        turnNumber++;



        if (turnNumber == 10)
        {
            StartCoroutine(ResetGridDelay());
        }
    }

    public void WinConditionForPlayer1()
    {
        if (buttonsOfGrid[0] == 0 && buttonsOfGrid[1] == 0 && buttonsOfGrid[2] == 0)
        {
            Player1Wins(0,1,2);
        }
        else if (buttonsOfGrid[3] == 0 && buttonsOfGrid[4] == 0 && buttonsOfGrid[5] == 0)
        {
            Player1Wins(3,4,5);
        }
        else if (buttonsOfGrid[6] == 0 && buttonsOfGrid[7] == 0 && buttonsOfGrid[8] == 0)
        {
            Player1Wins(6,7,8);
        }
        else if (buttonsOfGrid[0] == 0 && buttonsOfGrid[3] == 0 && buttonsOfGrid[6] == 0)
        {
            Player1Wins(0,3,6);
        }
        else if (buttonsOfGrid[1] == 0 && buttonsOfGrid[4] == 0 && buttonsOfGrid[7] == 0)
        {

            Player1Wins(1,4,7);
        }
        else if (buttonsOfGrid[2] == 0 && buttonsOfGrid[5] == 0 && buttonsOfGrid[8] == 0)
        {
            Player1Wins(2,5,8);
        }
        else if (buttonsOfGrid[0] == 0 && buttonsOfGrid[4] == 0 && buttonsOfGrid[8] == 0)
        {
            Player1Wins(0,4,8);
        }
        else if (buttonsOfGrid[2] == 0 && buttonsOfGrid[4] == 0 && buttonsOfGrid[6] == 0)
        {
            Player1Wins(2,4,6);
        }
    }
    public void WinConditionForPlayer2()
    {
        if (buttonsOfGrid[0] == 1 && buttonsOfGrid[1] == 1 && buttonsOfGrid[2] == 1)
        {
            Player2Wins(0, 1, 2);
        }
        else if (buttonsOfGrid[3] == 1 && buttonsOfGrid[4] == 1 && buttonsOfGrid[5] == 1)
        {
            Player2Wins(3, 4, 5);
        }
        else if (buttonsOfGrid[6] == 1 && buttonsOfGrid[7] == 1 && buttonsOfGrid[8] == 1)
        {
            Player2Wins(6, 7, 8);
        }
        else if (buttonsOfGrid[0] == 1 && buttonsOfGrid[3] == 1 && buttonsOfGrid[6] == 1)
        {
            Player2Wins(0, 3, 6);
        }
        else if (buttonsOfGrid[1] == 1 && buttonsOfGrid[4] == 1 && buttonsOfGrid[7] == 1)
        {
            Player2Wins(1, 4, 7);
        }
        else if (buttonsOfGrid[2] == 1 && buttonsOfGrid[5] == 1 && buttonsOfGrid[8] == 1)
        {
            Player2Wins(2, 5, 8);
        }
        else if (buttonsOfGrid[0] == 1 && buttonsOfGrid[4] == 1 && buttonsOfGrid[8] == 1)
        {
            Player2Wins(0, 4, 8);
        }
        else if (buttonsOfGrid[2] == 1 && buttonsOfGrid[4] == 1 && buttonsOfGrid[6] == 1)
        {
            Player2Wins(2, 4, 6);
        }
    }

    public void Player1Wins(int one, int two, int three)
    {
        buttons[one].image.sprite = sprites[3];
        buttons[two].image.sprite = sprites[3];
        buttons[three].image.sprite = sprites[3];
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        textWork.player1Wins++;
        textWork.player1WinsText.text = textWork.player1Wins.ToString();
        StartCoroutine(ResetGridDelay());
    }
    public void Player2Wins(int one, int two, int three)
    {
        buttons[one].image.sprite = sprites[4];
        buttons[two].image.sprite = sprites[4];
        buttons[three].image.sprite = sprites[4];
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        textWork.player2Wins++;
        textWork.player2WinsText.text = textWork.player2Wins.ToString();
        StartCoroutine(ResetGridDelay());
    }
    public void ResetGrid()
    {
        turnNumber = 1;

        for (int i = 0; i < buttonsOfGrid.Length; i++)
        {
            buttons[i].image.sprite = sprites[2];

        }
        for (int i = 0; i < buttonsOfGrid.Length; i++)
        {
            buttons[i].interactable = true;
            buttonsOfGrid[i] = -1;
        }
    }

    IEnumerator ResetGridDelay()
    {
        yield return new WaitForSeconds(1f);
        ResetGrid();
    }
}