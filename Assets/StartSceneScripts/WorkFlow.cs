using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkFlow : MonoBehaviour
{
    GameObject InteractiveUI;
    GameObject CellGenerator;
    GameObject BoardControl;
    public int[] cells = {1,4,5};
    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.InteractiveUI = GameObject.Find("InteractiveUI");
        this.BoardControl = GameObject.Find("BoardControl");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startButtonOnSelect()
    {
        TextMeshProUGUI text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.color = Color.black;
    }
    public void startButtonDeSelect()
    {
        TextMeshProUGUI text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.color = Color.white;
    }

    public void StartButtonOnClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("ExampleScene");
    }
    public void SkipButtonOnClick()
    {
        Time.timeScale = 1.0f;
        var lst = Round.InteractableFalseCells_num.ToList();
        lst.Clear();
        Round.InteractableFalseCells_num = lst.ToArray();
        SceneManager.LoadScene("GameScene");
    }
    public void NextButtonOnClicked()
    {
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("�h�[��t�@�Ӷq�l���񪺦r��(�t�@�b)�b����l���A�u�n�[���̫ᦳ��L�r�����t�@�b�୫�s�^��_�I����l\n�h���u�ʳ��j��v");
        TypeWriter.Active();
        Destroy(GameObject.Find("NextButton(Clone)"));
        this.BoardControl.GetComponent<BoardControl>().forthStep = false;
        ButtonsInteractive();
    }
    void ButtonsInteractive()
    {
        foreach (int i in cells)
        {
            CellGenerator.GetComponent<CellGenerator>().cells[i].GetComponent<Button>().interactable = true;
        }
    }
}
