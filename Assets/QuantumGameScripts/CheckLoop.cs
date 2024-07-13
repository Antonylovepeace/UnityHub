using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckLoop : MonoBehaviour
{
    GameObject Cells;
    GameObject InteractiveUI;
    private string[] temp = new string[] { };
    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        this.InteractiveUI = GameObject.Find("InteractiveUI");
    }




    public void putIntoList()
    {
        Array.Clear(Round.jag, 0, Round.jag.Length);
        for (int i = 0; i < 9; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            GameObject Grid_base = cell.transform.GetChild(0).gameObject;
            Round.jag[i] = new string[0];
            for (int j = 0; j < 9; j++)
            {
                TextMeshProUGUI text = Grid_base.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
                //GameObject text = Grid_base.transform.GetChild(j).gameObject;
                string content = text.text;
                if (content != "")
                {
                    var lsts = Round.jag[i].ToList();
                    lsts.Add(content);
                    Round.jag[i] = lsts.ToArray();
                }
            }
        }
        this.InteractiveUI.GetComponent<InteractiveUI>().Quantum_superposition();
        while (jagLength() == true)
        {
            for (int i = 0; i < 9; i++)
            {
                if (Round.jag[i].Length == 1)
                {
                    var lst = Round.jag[i].ToList();
                    string c = Round.jag[i][0];
                    lst.Clear();
                    Round.jag[i] = lst.ToArray();
                    for (int j = 0; j < 9; j++)
                    {
                        var lst1 = Round.jag[j].ToList();
                        lst1.Remove(c);
                        Round.jag[j] = lst1.ToArray();
                    }
                    continue;
                }
            }
        }
        for (int i = 0; i < 9; i++)
        {
            foreach(string c in Round.jag[i])
            {
                print("jag = "+c);
            }
        }
    }
    private bool jagLength()
    {
        for (int i = 0;i < 9; i++)
        {
            if (Round.jag[i].Length == 1)
            {
                return true;
            }
        }
        return false;
    }


    

    public void GetBase(int BaseNum)
    {
        var temp1 = Round.Base.ToList();
        temp1.Clear();
        Round.Base = temp1.ToArray();
        for (int k = 0; k < Round.jag[BaseNum].Length; k++)
        {
            var lsts = Round.Base.ToList();
            lsts.Add(Round.jag[BaseNum][k]);
            Round.Base = lsts.ToArray();
        }
        


    }
    public void GetCompare(int CompareNum)
    {
        var temp1 = Round.Compare.ToList();
        temp1.Clear();
        Round.Compare = temp1.ToArray();
        for (int k = 0; k < Round.jag[CompareNum].Length; k++)
        {
            var lsts = Round.Compare.ToList();
            lsts.Add(Round.jag[CompareNum][k]);
            Round.Compare = lsts.ToArray();
        }
    }

    public bool checkInteractable(int i)
    {
        foreach(int x in Round.InteractableFalseCells_num)
        {
            if(x == i)
            {
                return true;
            }
        }
        return false;
    }




    public bool checkLoop()
    {     
        
        //arrayBackUp();
        for (int i = 0; i < 9; i++)                  // 取Base
        {
            putIntoList();
            GetBase(i);
            if (checkInteractable(i) == true || Round.Base.Length == 0 )
            {
                continue;
            }       
            for (int j = 0; j < 9; j++)               // 取Compare
            {
                if (i != j )
                {
                    GetCompare(j);
                    if (checkInteractable(j) == true || Round.Compare.Length == 0 )
                    {
                        continue;
                    }
                    foreach (string x in Round.Base)
                    {
                        print("Base = " + x);
                    }
                    foreach (string x in Round.Compare)
                    {
                        Debug.Log("Compare = " + x);
                    }
                    int t = FindRepeat(CopyAndAddArray(Round.Base, Round.Compare)).Length;
                    
                    if (t == 1)
                    {
                        secondCheck(i);
                        if(Round.LoopCheck.Length > 4 && Round.LoopCheck[0] == Round.LoopCheck[Round.LoopCheck.Length - 1])
                        {                        
                            foreach (int x in Round.collapseCells)
                            {
                                var lst4 = Round.InteractableFalseCells_num.ToList();
                                lst4.Add(x);
                                Round.InteractableFalseCells_num = lst4.ToArray();
                            }
                            this.InteractiveUI.GetComponent<InteractiveUI>().Loop();
                            return true;             
                        }
                        else
                        {
                            GetBase(i);
                        }
                    }

                    else if (t == 2)
                    {
                        string a = FindRepeat(CopyAndAddArray(Round.Base, Round.Compare))[0];
                        string b = FindRepeat(CopyAndAddArray(Round.Base, Round.Compare))[1];
                        print("x = "+a);
                        print("y = " + b);
                        var lst1 = Round.LoopCheck.ToList();
                        var lst2 = Round.collapseCells.ToList();
                        var lst3 = Round.InteractableFalseCells_num.ToList();
                        var lst4 = Round.collapseTexts.ToList();
                        lst1.Clear();
                        lst2.Clear();
                        lst4.Clear();
                        Round.collapseCells = lst2.ToArray();
                        GetCollapseCells(i, j);
                        lst3.Add(i);
                        lst3.Add(j);
                        lst1.Add(Round.arrayNameList[i]);
                        lst1.Add(Round.arrayNameList[j]);
                        lst4.Add(a);
                        lst4.Add(b);
                        Round.LoopCheck = lst1.ToArray();
                        Round.InteractableFalseCells_num = lst3.ToArray();
                        Round.collapseTexts = lst4.ToArray();
                        removeRepeatNum(i, j, a);
                        removeRepeatNum(i, j, b);
                        this.InteractiveUI.GetComponent<InteractiveUI>().Loop();

                        return true;
                    }
                }

            }

        }
        print("迴圈未形成");
        return false;
    }

    int z = 0;
    private string[] secondCheck(int i)
    {
        var lst1 = Round.LoopCheck.ToList();
        var lst2 = Round.collapseCells.ToList();
        var lst3 = Round.collapseTexts.ToList();
        lst1.Clear();
        lst2.Clear();
        lst3.Clear();
        Round.LoopCheck = lst1.ToArray();
        Round.collapseCells = lst2.ToArray();
        Round.collapseTexts = lst3.ToArray();
        GetBase(i);
        int[] n = Route(0);
        while (z < 9)
        {
            z++;
            foreach (int j in n)               // 取Compare
            {
                foreach (string x in Round.Base)
                {
                    //print("Base = " + x);
                }
                if (i != j)
                {                   
                    GetCompare(j);
                    if (checkInteractable(j) == true || Round.Compare.Length == 0 )
                    {
                        continue;
                    }
                    foreach (string x in Round.Compare)
                    {
                        //print("Compare = " + x);
                    }
                    if (FindRepeat(CopyAndAddArray(Round.Base, Round.Compare)).Length == 1)
                    {
                        string r = FindRepeat(CopyAndAddArray(Round.Base, Round.Compare))[0];
                        GetCollapseCells(i, j);
                        var lst = Round.LoopCheck.ToList();
                        var lst5 = Round.collapseTexts.ToList();
                        lst5.Add(r);
                        lst.Add(Round.arrayNameList[i]);
                        lst.Add(Round.arrayNameList[j]);
                        Round.LoopCheck = lst.ToArray();
                        Round.collapseTexts = lst5.ToArray();
                        removeRepeatNum(i, j, r);
                        i = j;
                        n = Route(i);
                        GetBase(i);
                    }
                }
            }
        }
        z = 0;
        return Round.LoopCheck;
    }

    private void GetCollapseCells(int i, int j)
    {
        var lst = Round.collapseCells.ToList();
        lst.Add(i);
        lst.Add(j);
        Round.collapseCells = lst.ToArray();
    }
    private void removeRepeatNum(int i, int j, string c)
    {
        var bas = Round.jag[i].ToList();
        bas.Remove(c);
        Round.jag[i] = bas.ToArray();
        var com = Round.jag[j].ToList();
        com.Remove(c);
        Round.jag[j] = com.ToArray();

    }
    public string[] CopyAndAddArray(string[] Ba, string[] Com)
    {       
        string[] list = new string[] { };
        list = new string[Ba.Length + Com.Length];
        
        Array.Copy(Ba, list, Ba.Length);
        Array.Copy(Com, 0, list, Ba.Length, Com.Length);
        return list;
    }
    public string[] FindRepeat(string[] list)
    {
        var temp1 = Round.repeat_num.ToList();
        temp1.Clear();
        Round.repeat_num = temp1.ToArray();
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = i + 1; j < list.Length; j++)
            {
                if (list[i] == list[j] && list[i] != "")
                {
                    string cha = list[i];
                    var lsts = Round.repeat_num.ToList();
                    Round.repeat_num = lsts.Append(cha).ToArray();
                }
            }
        }

        return Round.repeat_num;
    }








    int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    int[] listClone = new int[9];
    public int[] Route(int n)
    {
        Array.Copy(list, listClone, list.Length);
        int m = Array.IndexOf(listClone, n);
        for (int i = 0; i < m; i++)
        {
            var lst = listClone.ToList();
            lst.Add(listClone[0]);
            lst.RemoveAt(0);
            listClone = lst.ToArray();
        }
        return listClone;
    }
}
