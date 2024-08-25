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

        //模?AI??按? 
        Invoke(nameof(MakeMove), 3.0f); // 在3秒后?用MakeMove方法
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
        //隨機找形成迴圈的大格子
        randnum = UnityEngine.Random.Range(0, Round.collapseCells.Length);

        Cell bigCell = this.Cells.GetComponent<CellGenerator>().cells[Round.collapseCells[randnum]];
        //print(Round.collapseCells[randnum]);
        // 添加一???事件?听器

        // 使用Invoke方法模???
        bigCell.GetComponent<Button>().Select();
        //Debug.Log("AImeasure sucessed!!");

        //隨機找形成迴圈的大格子中的隨機元素     
        // 使用Invoke方法模???
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

                //讓AI下不重複的格子
                bestMove = UnityEngine.Random.Range(1, 9);
                Cell cell = this.Cells.GetComponent<CellGenerator>().cells[bestMove];

                //print(lastMove);
                // 使用Invoke方法模???
                if (this.Cells.GetComponent<CellGenerator>().cells[bestMove].GetComponent<Button>().interactable)
                {
                    //print("AI下第" + bestMove + "格");
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
        int bestScore = int.MinValue;           //值為-2,147,483,647,表示int資料型別能夠表示的最小負整數值
        int bestMove = 1;//-1;

        var validMoves = GetValidMoves();
        foreach (var move in validMoves)
        {
            board[move] = player;
            int score = /*10 - move;*/Minimax(0, false);
            //print("第" + move + "格分數: " + score);

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