using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Mathematics;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class AI : MonoBehaviour
{
    GameObject Cells;
    GameObject Collapse;
    GameObject Measure;
    GameObject CheckLoop;
    GameObject Director;
    static int[] board = new int[9];
    static int player = 1; // 1 for X, -1 for O
    public Cell[] Board = new Cell[9];
    public int randnum;

    public void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        this.Collapse = GameObject.Find("collapse");
        this.Measure = GameObject.Find("measure");
        this.CheckLoop = GameObject.Find("CheckLoop");
        this.Director = GameObject.Find("Director");

        if (Round.FirstMove == false)           //Player second , AI First
        {
            Main();
        }
    }

    public void Main()
    {
        //print("Main Sucessed!");

        //��?AI??��? 
        Invoke(nameof(MakeMove), 3.0f); // �b3��Z?��MakeMove��k
    }

    
    public void WhoseMeasure()
    {
        if (Round.FirstMove == false)  // Player second, AI First
        {
            bool AIturn = Director.GetComponent<Director>().Xturn;
            if (AIturn == true)
            {
                AImeasure();
            }
        }
        else if (Round.FirstMove == true)   //Player First , AI second
        {
            bool AIturn = Director.GetComponent<Director>().Xturn;
            if (AIturn == false)
            {
                AImeasure();
            }
        }
        
    }

    public void AImeasure()
    {
        //print("Round.loopConfirm = " + Round.loopConfirm);

        //print("enter");
        //�H����Φ��j�骺�j��l
        randnum = UnityEngine.Random.Range(0, Round.collapseCells.Length);

        Cell bigCell = this.Cells.GetComponent<CellGenerator>().cells[Round.collapseCells[randnum]];
        //print(Round.collapseCells[randnum]);
        // �K�[�@???�ƥ�?�v��

        // �ϥ�Invoke��k��???
        bigCell.GetComponent<Button>().Select();
        //Debug.Log("AImeasure sucessed!!");

        //�H����Φ��j�骺�j��l�����H������     
        // �ϥ�Invoke��k��???
        Invoke(nameof(AISelectSmallCell), 2.0f);

        Invoke(nameof(AIInvokeMeasureButton), 4.0f);
    }

    public void AISelectSmallCell()
    {
        randnum = UnityEngine.Random.Range(0, 1);
        GameObject smallCell = this.Collapse.GetComponent<collapse>().Buttons[randnum];
        smallCell.GetComponent<Button>().Select();
        //print("Buttons was selected!");
    }

    public void AIInvokeMeasureButton()
    {
        GameObject measureButton = this.Measure.GetComponent<Measure>().newButton;
        measureButton.GetComponent<Button>().onClick.Invoke();
        //print("measureButton was clicked!");

        Main();
    }


    /// //////////////////////////////////////////////////////////////////////////////////////////////////
    public void MakeMove()
    {
        int count = 0;
        if (player == 1)
        {
            while (count < 2)
            {
                var bestMove = FindBestMove();

                //��AI�U�����ƪ���l
                bestMove = UnityEngine.Random.Range(1, 9);
                Cell cell = this.Cells.GetComponent<CellGenerator>().cells[bestMove];

                //print(lastMove);
                // �ϥ�Invoke��k��???
                if (this.Cells.GetComponent<CellGenerator>().cells[bestMove].GetComponent<Button>().interactable)
                {
                    //print("AI�U��" + bestMove + "��");
                    cell.GetComponent<Button>().onClick.Invoke();
                    count++;
                }
                continue;
            }
            //print("count over");
        }
        else
        {
            // Random move for player O
            var validMoves = GetValidMoves();
        }
    }

    public int FindBestMove()
    {
        int bestScore = int.MinValue;           //�Ȭ�-2,147,483,647,���int��ƫ��O�����ܪ��̤p�t��ƭ�
        int bestMove = 1;//-1;

        var validMoves = GetValidMoves();
        foreach (var move in validMoves)
        {
            board[move] = player;
            int score = /*10 - move;*/Minimax(0, false);
            //print("��" + move + "�����: " + score);

            board[move] = 0;

            if (score > bestScore)
            {
                bestScore = score;
                bestMove = move;
            }
        }
        return bestMove;
    }

    public int Minimax(int depth, bool isMaximizing)
    {

        return -1;
    }

    static List<int> ValidMoves()
    {
        //print("ValidMoves Sucessed!");
        var validMoves = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            if (board[i] == 0)
                validMoves.Add((i));
        }
        return validMoves;
    }

    public List<int> GetValidMoves()
    {
        //print("GetValidMoves Sucessed!");
        var validMoves = ValidMoves();

        for (int i = 0; i < 9; i++)
        {
            if (!this.Cells.GetComponent<CellGenerator>().cells[i].GetComponent<Button>().interactable)
                validMoves.Remove(i);
        }

        //foreach (int moves in validMoves)
            //print("ValidMoves = " + moves);

        return validMoves;
    }




}