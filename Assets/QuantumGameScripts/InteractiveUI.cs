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
    void Start()
    {
        this.BoardControl = GameObject.Find("BoardControl");
        this.Cells = GameObject.Find("CellGenerator");
        this.interactiveUI = GameObject.Find("InteractiveUI");
        if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("���a�C�^�X������ܨ�ӪŮ�\r\n���U�ӽ��I�����զ��l\r\n");
            TypeWriter.Active();
        }
        else if(SceneManager.GetActiveScene().name == "GameScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("�w��Ө�q�l���z���@��!!!\r\n�п�ܨ�椣�P��l���l�C\r\n");
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
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            //TypeWriter.Add("");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            if (num.Length == 2)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\r\n�`�N��� " + num[0] + " �B" + num[1] + " ��l\n��l��������r��\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + "���F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 3)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\r\n�`�N��� " + num[0] + " �B" + num[1] + " �B" + num[2] + " ��l\n��l��������r��\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " �B" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + "�Φ��F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 4)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\r\n�`�N��� " + num[0] + " �B" + num[1] + " �B" + num[2] + " �B" + num[3] + " ��l\n��l��������r��\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " �B" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " �B" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + "�Φ��F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 5)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\r\n�`�N��� " + num[0] + " �B" + num[1] + " �B" + num[2] + " �B" + num[3] + " �B" + num[4] + " ��l\n��l��������r��\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " �B" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " �B" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " �B" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + "�Φ��F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 6)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\r\n�`�N��� " + num[0] + " �B" + num[1] + " �B" + num[2] + " �B" + num[3] + " �B" + num[4] + " �B" + num[5] + " ��l\n��l��������r��\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " �B" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " �B" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " �B" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " �B" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + "�Φ��F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 7)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\r\n�`�N��� " + num[0] + " �B" + num[1] + " �B" + num[2] + " �B" + num[3] + " �B" + num[4] + " �B" + num[5] + " �B" + num[6] + " ��l\n��l��������r��\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " �B" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " �B" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " �B" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " �B" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + " �B" + Round.char_[6] + Round.subscript[Round.subscriptNum[6]] + "�Φ��F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 8)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\r\n�`�N��� " + num[0] + " �B" + num[1] + " �B" + num[2] + " �B" + num[3] + " �B" + num[4] + " �B" + num[5] + " �B" + num[6] + " �B" + num[7] + " ��l\n��l��������r��\n" +
                    Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " �B" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " �B" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " �B" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " �B" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + " �B" + Round.char_[6] + Round.subscript[Round.subscriptNum[6]] + " �B" + Round.char_[7] + Round.subscript[Round.subscriptNum[7]] + "�Φ��F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
                TypeWriter.Active();
            }
            else if (num.Length == 9)
            {
                TypeWriter.Add("<�[����>���ͫʳ��j��\n�`�N��� " + num[0] + " �B" + num[1] + " �B" + num[2] + " �B" + num[3] + " �B" + num[4] + " �B" + num[5] + " �B" + num[6] + " �B" + num[7] + " �B" + num[8] + " ��l\n��l��������r��\n" +
                     Round.char_[0] + Round.subscript[Round.subscriptNum[0]] + " �B" + Round.char_[1] + Round.subscript[Round.subscriptNum[1]] + " �B" + Round.char_[2] + Round.subscript[Round.subscriptNum[2]] + " �B" + Round.char_[3] + Round.subscript[Round.subscriptNum[3]] + " �B" + Round.char_[4] + Round.subscript[Round.subscriptNum[4]] + " �B" + Round.char_[5] + Round.subscript[Round.subscriptNum[5]] + " �B" + Round.char_[6] + Round.subscript[Round.subscriptNum[6]] + " �B" + Round.char_[7] + Round.subscript[Round.subscriptNum[7]] + " �B" + Round.char_[8] + Round.subscript[Round.subscriptNum[8]] + "�Φ��F�j��\n" +
                    "���U�ӽп�ܧA�Q�[��������\n�æb�k����s���Umeasure\r\n");
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
            TypeWriter.Add("���a'X'�^�X����\n�����[��q�l�t��\n�i�o�{X�P�ɦs�b�� " + list[0] + " ��l�P " + list[1] + " ��l��\n�]�N�O���ثe ��X�� ��50%���v�X�{�b�� " + list[0] + " ��\n��50%���v�X�{�b�� " + list[1] + " ��\n�����A�� ��X�� �N��F�q�l���z���� ������A��");
            TypeWriter.Active();
            
        }
        else if(SceneManager.GetActiveScene().name == "ExampleScene")
        {
            print("SecondStep");
            interactiveUI.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("���U�ӧڭ̺٭Ӥl�����F�謰 '����'\n�P���`���P\n�P�Ӯ�l���i�H�P�ɦs�b�h�Ӥ���\n���U�ӽ��I���t���զ��l");
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
                        //print("�i��");
                        int[] num = Quantum_superpositionToSubScript(i);
                        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
                        TypeWriter.Add("���ɦA�[��q�l�t��\n�o�{�� " + (i + 1) + " ��Ӯ�l���P�ɦ� " + sub[0] + Round.subscript[num[0]] + " �M " + sub[1] + Round.subscript[num[1]] +
                            " ����\n��ܳo��l���i�ର " + sub[0] + Round.subscript[num[0]] + " ��i�ର " + sub[1] + Round.subscript[num[1]] + " �P�ɦs�b���P�����A\n���{�H�٬����|�[�A");
                        TypeWriter.Active();
                        Round.typeWriter_quantumSuperposition++;
                    }
                }
                else if (SceneManager.GetActiveScene().name == "ExampleScene")
                {
                    if (Round.typeWriter_quantumSuperposition < 1)
                    {
                        print("ThirdStep");
                        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
                        TypeWriter.Add("�^�X�V�h�A�����������]�V�ӶV�h\n�M�Ӥ@�� �Φ��ʳ��j���\n���������մN�|�]������\n���U�Ӥ]���I���t���զ��l");
                        TypeWriter.Active();
                        Invoke("CellsIneractable", 0);
                        BoardControl.GetComponent<BoardControl>().AcallThirdStep();
                        Round.typeWriter_quantumSuperposition++;
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
            TypeWriter.Add("<�[�������A�i����Y>\n�A��ܱo�[����H�� " + b + Round.subscript[a] +
                " \n�]���A���[���ϱo" + b + Round.subscript[a] + " �b���椺�X�{���v�� 100% �P�Ӯ�l���즳����L�i��ʦ]���ܬ�0%\n" +
                "\n�S�]���C�ӬۦP�������|�P�ɥX�{�b��Ӯ�l��" +
                "\n�Y�����쥻�X�{�b����l�������v��50%�A" +
                "\n�{�b�ܬ�0%" +
                "\n�h�������b�t�@�Ӯ�l���X�{���v�ܬ�100%" +
                "\n�ǥѤ��_�s������A�ѽL�̫�|�ͩ�í�w\n�o�سz�L�[���϶q�l�欰�ͦV�j�嵲�G���{�H�A�ڭ̺٧@���Y�C\r\n");
            TypeWriter.Active();
        }
    }
    public void NormalWiningText(string winner)
    {
        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("���ߪ��a " + winner + " ���");
        TypeWriter.Active();
    }
    public void UnNormalWiningText(string Case)
    {
        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
        if (Case == "Case1")
        {
            TypeWriter.Add("���a ��X ����ӽu�����֦��̤p�U��\n�]�����a ��X�� ���");
        }
        else if (Case == "Case2")
        {
            TypeWriter.Add("���a ��O ����ӽu�����֦��̤p�U��\n�]�����a ��O�� ���");
        }
        else if (Case == "Case3")
        {
            TypeWriter.Add("���a ��X ���P���a ��O���֦��ۦP���̤p�U�� \n�ѩ󪱮a ��X ��������\n�]�����a ��X �����");
        }
        TypeWriter.Active();
    }
}
