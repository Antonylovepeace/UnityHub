﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Round
{
    public static int videoCounter = 1;
    public static int afterVideo_Anime = 0;
    public static bool FirstMove = false;
    public static int IntroductionPlayButton = 0;
    public static bool MeasureButton_PlayAnime = true;

    public static int typeWriter_quantumEntanglement = 0;
    public static int typeWriter_quantumSuperposition = 0;
    public static string Winner;
    public static bool AnimeCircleLoop = false;
    public static bool AnimeArrowLoop = false;
    public static bool loopConfirm;
    public static bool AI = true;

    public static float timeDelay = 0f;
    public static int twoRound = 0;
    public static int selectedCell;
    public static string[] subscript = { "₁", "₂", "₃", "₄", "₅", "₆", "₇", "₈", "₉" };
    public static string[] char_ = new string[] { };
    public static int[] subscriptNum = new int[] { };





    public static int charO_num = 0;
    public static int charX_num = 0;
    public static int[] Cells = new int[] { };
    public static string[] Base = new string[] { };
    public static string[] Compare = new string[] { };
    public static string[] repeat_num = new string[] { };
    public static string[] LoopCheck = new string[] { };
    public static string[][] jag = new string[9][];
    public static int[] collapseCells = new int[] { };
    public static string[] collapseTexts = new string[] { };
    public static int[] InteractableFalseCells_num = new int[] { };
    public static string[] arrayNameList = { "Cell_0", "Cell_1", "Cell_2", "Cell_3", "Cell_4", "Cell_5", "Cell_6", "Cell_7", "Cell_8" };

}
