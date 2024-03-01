using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckLoop : MonoBehaviour
{
    GameObject Cells;
    private string[] temp = new string[] { };
    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
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
                GameObject text = Grid_base.transform.GetChild(j).gameObject;
                string content = text.GetComponent<Text>().text;
                if (content != "")
                {
                    var lsts = Round.jag[i].ToList();
                    Round.jag[i] = lsts.Append(content).ToArray();
                }
            }
        }
 
    }



    

    public void GetBase(int BaseNum)
    {
        var temp1 = Round.Base.ToList();
        temp1.Clear();
        Round.Base = temp1.ToArray();
        for (int k = 0; k < Round.array_list_backup[BaseNum].Length; k++)
        {
            var lsts = Round.Base.ToList();
            Round.Base = lsts.Append(Round.array_list_backup[BaseNum][k]).ToArray();
        }

        
    }
    public void GetCompare(int CompareNum)
    {
        var temp1 = Round.Compare.ToList();
        temp1.Clear();
        Round.Compare = temp1.ToArray();
        for (int k = 0; k < Round.array_list_backup[CompareNum].Length; k++)
        {
            var lsts = Round.Compare.ToList();
            Round.Compare = lsts.Append(Round.array_list_backup[CompareNum][k]).ToArray();
        }
    }






    public bool checkLoop()
    {
        putIntoList();
        arrayBackUp();
        for (int i = 0; i < 9; i++)                  // 取Base
        {
            GetBase(i);
            if(Round.Base.Length == 0)
            {
                continue;
            }
            foreach (string x in Round.Base)
            {
                Debug.Log("Base = "+x);
            }
            for (int j = 0; j < 9; j++)               // 取Compare
            {
                if (i != j)
                {
                    GetCompare(j);
                    if (Round.Compare.Length == 0)
                    {
                        continue;
                    }
                    foreach (string x in Round.Compare)
                    {
                        Debug.Log("Compare = " + x);
                    }
                    int t = FindRepeat(CopyAndAddArray(Round.Base, Round.Compare)).Length;
                    if (t == 1)
                    {
                        secondCheck(i);
                        if (Round.LoopCheck[0] == Round.LoopCheck[Round.LoopCheck.Length - 1] && Round.LoopCheck.Length > 4)
                        {
                            print("迴圈形成");
                            return true;
                        }
                    }
                    else if (t == 2)
                    {
                        print("迴圈形成,兩格");
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
        lst1.Clear();
        Round.LoopCheck = lst1.ToArray();
        GetBase(i);
        int[] n = Route(0);
        while (z < 9)
        {
            z++;
            foreach (int j in n)               // 取Compare
            {
                

                if (i != j)
                {
                    GetCompare(j);
                    if (Round.Compare.Length == 0)
                    {
                        continue;
                    }
                    foreach (string x in CopyAndAddArray(Round.Base, Round.Compare))
                    {
                        print("list = " + x);
                    }
                    print("once");
                    if (FindRepeat(CopyAndAddArray(Round.Base, Round.Compare)).Length == 1)
                    {
                        print("once");
                        string r = FindRepeat(CopyAndAddArray(Round.Base, Round.Compare))[0];
                        
                        Console.WriteLine("once");
                        var lst = Round.LoopCheck.ToList();
                        lst.Add(Round.arrayNameList[i]);
                        lst.Add(Round.arrayNameList[j]);
                        Round.LoopCheck = lst.ToArray();
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


    private void removeRepeatNum(int i, int j, string c)
    {
        var bas = Round.array_list_backup[i].ToList();
        bas.Remove(c);
        Round.array_list_backup[i] = bas.ToArray();
        var com = Round.array_list_backup[j].ToList();
        com.Remove(c);
        Round.array_list_backup[j] = com.ToArray();

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

    public void arrayBackUp()
    {
        Array.Clear(Round.array_list_backup, 0, Round.array_list_backup.Length);  
        Array.Copy(Round.jag, Round.array_list_backup, Round.jag.Length);
        var temp1 = Round.num.ToList();
        temp1.Clear();
        Round.num = temp1.ToArray();
        for (int i = 0; i < Round.jag.Length; i++)
        {
            if (Round.jag[i].Length < 2)
            {
                var lst = Round.num.ToList();
                Round.num = lst.Append(i).ToArray();
            }
        }
        foreach (int i in Round.num)
        {
            Array.Clear(Round.array_list_backup, i, 1);
            Round.array_list_backup[i] = new string[0];
        }
    }
}
