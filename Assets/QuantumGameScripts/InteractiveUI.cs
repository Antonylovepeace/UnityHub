using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractiveUI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject interactiveUI;
    GameObject Cells;
    GameObject BoardControl;
    public TextMeshProUGUI UI;
    public TextMeshProUGUI Opening;

    void Start()
    {
        
        this.BoardControl = GameObject.Find("BoardControl");
        this.Cells = GameObject.Find("CellGenerator");
        this.interactiveUI = GameObject.Find("InteractiveUI");
        if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("玩家每回合必須選擇兩個空格\r\n接下來請點擊兩格白色格子\r\n");
            TypeWriter.Active();
        }
        else if(SceneManager.GetActiveScene().name == "GameScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("Welcome to Quantum Tic Tac Toe!!!\r\n請選擇兩格不同格子落子。\r\n");
            TypeWriter.Active();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void Loop()
    {
        int[] num = new int[] { };
        var lst = num.ToList();
        var list = Round.LoopCheck.Distinct().ToList();
        list.ToArray();
        for (int i = 0; i < 9; i++)
        {
            foreach (string item in list)
            {
                if (Round.arrayNameList[i] == item)
                {
                    lst.Add(i + 1);
                }
            }
        }
        num = lst.ToArray();
        LoopTosubscript();
        if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            Invoke("CellsIneractable", 0);
            BoardControl.GetComponent<BoardControl>().AcallForthStep();
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("此時第 ②、⑤、⑥ 格子形成封閉迴圈\n" +
                "觀察X₁在⑤格子→另一個X₁在⑥格子\n→⑥格子內有X₂→另一個X₂在②格子\n→②格子內有O₁→另一個O₁在⑤格子，又回到一開始觀察X₁所在的⑤格子\n" +
                "\n不管以哪個字母為起點，去觀察另一個量子糾纏的字母(另一半)在的格子中，只要觀察到最後有其他字母的另一半能重新回到起點的格子\n則有「封閉迴圈」");
            TypeWriter.Active();
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            if (num.Length == 2)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\r\n注意到第 " + num[0] + " 、" + num[1] + " 格子\n格子中的黃色字母\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + "成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 3)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\r\n注意到第 " + num[0] + " 、" + num[1] + " 、" + num[2] + " 格子\n格子中的黃色字母\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " 、" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + "形成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 4)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\r\n注意到第 " + num[0] + " 、" + num[1] + " 、" + num[2] + " 、" + num[3] + " 格子\n格子中的黃色字母\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " 、" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " 、" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + "形成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 5)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\r\n注意到第 " + num[0] + " 、" + num[1] + " 、" + num[2] + " 、" + num[3] + " 、" + num[4] + " 格子\n格子中的黃色字母\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " 、" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " 、" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " 、" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + "形成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 6)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\r\n注意到第 " + num[0] + " 、" + num[1] + " 、" + num[2] + " 、" + num[3] + " 、" + num[4] + " 、" + num[5] + " 格子\n格子中的黃色字母\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " 、" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " 、" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " 、" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " 、" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + "形成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 7)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\r\n注意到第 " + num[0] + " 、" + num[1] + " 、" + num[2] + " 、" + num[3] + " 、" + num[4] + " 、" + num[5] + " 、" + num[6] + " 格子\n格子中的黃色字母\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " 、" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " 、" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " 、" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " 、" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + " 、" + Round.char_[6] + Round.subscript[Round.subscriptNum[6]] + "形成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 8)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\r\n注意到第 " + num[0] + " 、" + num[1] + " 、" + num[2] + " 、" + num[3] + " 、" + num[4] + " 、" + num[5] + " 、" + num[6] + " 、" + num[7] + " 格子\n格子中的黃色字母\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " 、" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " 、" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " 、" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " 、" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + " 、" + Round.char_[6] + Round.subscript[Round.subscriptNum[6]] + " 、" + Round.char_[7] + Round.subscript[Round.subscriptNum[7]] + "形成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 9)
            {
                TypeWriter.Add("<觀測中>產生封閉迴圈\n注意到第 " + num[0] + " 、" + num[1] + " 、" + num[2] + " 、" + num[3] + " 、" + num[4] + " 、" + num[5] + " 、" + num[6] + " 、" + num[7] + " 、" + num[8] + " 格子\n格子中的黃色字母\n" +
                     Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " 、" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " 、" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " 、" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " 、" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " 、" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + " 、" + Round.char_[6] + Round.subscript[Round.subscriptNum[6]] + " 、" + Round.char_[7] + Round.subscript[Round.subscriptNum[7]] + " 、" + Round.char_[8] + Round.subscript[Round.subscriptNum[8]] + "形成了迴圈\n" +
                    "接下來請選擇你想觀測的元素\n並在右方按鈕按下measure\r\n");
                TypeWriter.Active();
            }
        }
        
    }

    public void quantumEntanglement()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            int[] list = FindFirstTwoCell();
            TypeWriter.Add("玩家'X'回合結束\n此時觀察量子系統\n可發現X同時存在於 " + list[0] + " 格子與 " + list[1] + " 格子中\n也就是說目前 ”X” 有50%機率出現在第 " + list[0] + 
                " 格\n有50%機率出現在第 " + list[1] + " 格\n此狀態的 ”X” 代表了量子物理中的 ”糾纏態”");
            TypeWriter.Active();
            
        }
        else if(SceneManager.GetActiveScene().name == "ExampleScene")
        {
            print("SecondStep");
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("接下來我們稱個子內的東西為 '元素'\n與往常不同\n同個格子內可以同時存在多個元素\n接下來請點擊另兩格白色格子");
            TypeWriter.Active();
            Invoke("CellsIneractable", 0);
            BoardControl.GetComponent<BoardControl>().AcallSecondStep();
        }
    }

    public void CellsIneractable()
    {
        Cell[] cells = this.Cells.GetComponent<CellGenerator>().cells;
        for (int i = 0; i < 9; i++)
        {
            cells[i].GetComponent<Button>().interactable = false;
        }
    }
    public int[] FindFirstTwoCell()
    {
        int[] list = new int[] { };
        for (int i = 0; i < 9; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            GameObject Grid_base = cell.transform.GetChild(0).gameObject;
            for (int j = 0; j < 9; j++)
            {
                TextMeshProUGUI text = Grid_base.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
                string content = text.text;
                if (content != "")
                {
                    var lst = list.ToList();
                    lst.Add(i + 1);
                    list = lst.ToArray();
                }
            }
        }
        return list;
    }

    public void Quantum_superposition()
    {
        for (int i = 0; i < 9; i++)
        {
            if (Round.jag[i].Length == 2)
            {
                if (SceneManager.GetActiveScene().name == "GameScene")
                {
                    if (Round.typeWriter_quantumSuperposition < 1)
                    {
                        //print("進來");
                        int[] num = Quantum_superpositionToSubScript(i);
                        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
                        TypeWriter.Add("此時再觀察量子系統\n發現第 " + (i + 1) + " 格個格子內同時有 " + sub[0] + Round.subscript[num[0]] + " 和 " + sub[1] + Round.subscript[num[1]] +
                            " 元素\n表示這格子內可能為 " + sub[0] + Round.subscript[num[0]] + " 亦可能為 " + sub[1] + Round.subscript[num[1]] + " 同時存在不同的狀態\n此現象稱為”疊加態");
                        TypeWriter.Active();
                        Round.typeWriter_quantumSuperposition++;
                    }
                }
                else if (SceneManager.GetActiveScene().name == "ExampleScene")
                {
                    print("1.length = " + Round.jag[1].Length);
                    print("4.length = " + Round.jag[4].Length);
                    if (Round.jag[1].Length == 1 && Round.jag[4].Length == 2)
                    {
                        if (Round.typeWriter_quantumSuperposition < 1)
                        {
                            print("ThirdStep");
                            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
                            TypeWriter.Add("回合越多，場內的元素也越來越多\n然而一但 形成封閉迴圈後\n場內的情勢就會因此改變\n接下來也請點擊另兩格白色格子");
                            TypeWriter.Active();
                            Invoke("CellsIneractable", 0);
                            BoardControl.GetComponent<BoardControl>().AcallThirdStep();
                            Round.typeWriter_quantumSuperposition++;
                        }
                    }
                                                          
                }

            }
        }
    }
    string[] sub = new string[] { };
    private int[] Quantum_superpositionToSubScript(int i)
    {
        string[] charO = new string[] { "O<sub>1</sub>" , "O<sub>2</sub>" , "O<sub>3</sub>" ,"O<sub>4</sub>" ,"O<sub>5</sub>" ,
                                                            "O<sub>6</sub>" ,"O<sub>7</sub>","O<sub>8</sub>","O<sub>9</sub>"};
        string[] charX = new string[] { "X<sub>1</sub>" , "X<sub>2</sub>" , "X<sub>3</sub>" ,"X<sub>4</sub>" ,"X<sub>5</sub>" ,
                                                            "X<sub>6</sub>" ,"X<sub>7</sub>","X<sub>8</sub>","X<sub>9</sub>"};
        int[] num = new int[] { };
        var lst = num.ToList();
        var lst1 = sub.ToList();

        for (int x = 0; x < 9; x++)
        {
            foreach (string c in Round.jag[i])
            {
                if (c == charX[x])
                {
                    lst.Add(x);
                    lst1.Add("X");
                }
                else if (c == charO[x])
                {
                    lst.Add(x);
                    lst1.Add("O");
                }
            }
        }
        num = lst.ToArray();
        sub = lst1.ToArray();
        return num;
    }
    public void LoopTosubscript()
    {
        string[] charO = new string[] { "O<sub>1</sub>" , "O<sub>2</sub>" , "O<sub>3</sub>" ,"O<sub>4</sub>" ,"O<sub>5</sub>" ,
                                                            "O<sub>6</sub>" ,"O<sub>7</sub>","O<sub>8</sub>","O<sub>9</sub>"};
        string[] charX = new string[] { "X<sub>1</sub>" , "X<sub>2</sub>" , "X<sub>3</sub>" ,"X<sub>4</sub>" ,"X<sub>5</sub>" ,
                                                            "X<sub>6</sub>" ,"X<sub>7</sub>","X<sub>8</sub>","X<sub>9</sub>"};

        var lst = Round.char_.ToList();
        var lst1 = Round.subscriptNum.ToList();
        lst.Clear();
        lst1.Clear();
        for (int z = 0; z < 9; z++)
        {
            foreach (string c in Round.collapseTexts)
            {
                if (c == charX[z])
                {
                    lst1.Add(z);
                    lst.Add("X");
                }
                else if (c == charO[z])
                {
                    lst1.Add(z);
                    lst.Add("O");
                }
            }
        }
        Round.char_ = lst.ToArray();
        Round.subscriptNum = lst1.ToArray();
    }
    public int a;
    public string b;
    public void Quantum_collapse(string c)
    {
        string[] charO = new string[] { "O<sub>1</sub>" , "O<sub>2</sub>" , "O<sub>3</sub>" ,"O<sub>4</sub>" ,"O<sub>5</sub>" ,
                                                            "O<sub>6</sub>" ,"O<sub>7</sub>","O<sub>8</sub>","O<sub>9</sub>"};
        string[] charX = new string[] { "X<sub>1</sub>" , "X<sub>2</sub>" , "X<sub>3</sub>" ,"X<sub>4</sub>" ,"X<sub>5</sub>" ,
                                                            "X<sub>6</sub>" ,"X<sub>7</sub>","X<sub>8</sub>","X<sub>9</sub>"};

        for (int z = 0; z < 9; z++)
        {
            if (c == charX[z])
            {
                a = z;
                b = "X";
            }
            else if (c == charO[z])
            {
                a = z;
                b = "O";
            }
        }
        //print(a);
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("<觀測完畢，進行塌縮>\n你選擇得觀測對象為 " + b + Round.subscript[a] +
                " \n因為你的觀測使得" + b + Round.subscript[a] + " 在那格內出現機率為 100% 同個格子內原有的其他可能性因此變為 0%\n" +
                "\n又因為每個相同元素都會同時出現在兩個格子內" +
                "\n某元素原本出現在此格子內的機率為 50%，" +
                "\n現在變為 0%" +
                "\n則此元素在另一個格子的出現機率變為 100%" +
                "\n藉由不斷連鎖反應，棋盤最後會趨於穩定\n這種透過觀測使量子行為趨向古典結果的現象\n我們稱作  ”塌縮 ”\r\n");
            TypeWriter.Active();
        }
    }
    public void NormalWiningText(string winner)
    {
        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("恭喜玩家 " + winner + " 獲勝");
        TypeWriter.Active();
    }
    public void UnNormalWiningText(string Case)
    {
        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
        if (Case == "Case1")
        {
            TypeWriter.Add("玩家 ”X ”獲勝線條中擁有最小下標\n因此玩家 ”X” 獲勝");
        }
        else if (Case == "Case2")
        {
            TypeWriter.Add("玩家 ”O ”獲勝線條中擁有最小下標\n因此玩家 ”O” 獲勝");
        }
        else if (Case == "Case3")
        {
            TypeWriter.Add("玩家 ”X ”與玩家 ”O”擁有相同的最小下標 \n由於玩家 ”X ”為先手\n因此玩家 ”X ”獲勝");
        }
        TypeWriter.Active();
    }
}
