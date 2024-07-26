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
    GameObject Anime;
    public int[] cells = {1,4,5};
    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.InteractiveUI = GameObject.Find("InteractiveUI");
        this.BoardControl = GameObject.Find("BoardControl");
        this.Anime = GameObject.Find("Animation");
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
        resetBoard();
        SceneManager.LoadScene("ExampleScene");
    }
    public void SkipButtonOnClick()
    {
        Time.timeScale = 1.0f;
        resetBoard();
        SceneManager.LoadScene("GameScene");
    }
    public void NextButtonOnClicked()
    {
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("但玩家想觀測，需要達成一項條件，那就是“封閉迴圈”" +
            "\n此時第 ②、⑤、⑥ 格子形成封閉迴圈\n" +
                "觀察X₁在⑤格子→另一個X₁在⑥格子\n→⑥格子內有X₂→另一個X₂在②格子\n→②格子內有O₁→另一個O₁在⑤格子，又回到一開始觀察X₁所在的⑤格子\n" +
                "\n不管以哪個字母為起點，去觀察另一個量子糾纏的字母(另一半)在的格子中，只要觀察到最後有其他字母的另一半能重新回到起點的格子\n則有「封閉迴圈」");
        TypeWriter.Active();
        Round.AnimeLoop = true;
        this.Anime.GetComponent<Animetion>().AcallFunc();
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
    void resetBoard()
    {
        var lst = Round.InteractableFalseCells_num.ToList();
        var lst1 = Round.collapseCells.ToList();
        var lst2 = Round.collapseTexts.ToList();
        var lst3 = Round.InteractableFalseCells_num.ToList();
        lst.Clear();
        lst1.Clear();
        lst2.Clear();
        lst3.Clear();
        Round.InteractableFalseCells_num = lst.ToArray();
        Round.collapseCells = lst1.ToArray();
        Round.collapseTexts = lst2.ToArray();
        Round.InteractableFalseCells_num = lst3.ToArray();

        Round.charO_num = 0;
        Round.charX_num = 0;
        Round.typeWriter_quantumEntanglement = 0;
        Round.typeWriter_quantumSuperposition = 0;
        Round.Winner = "";
    }
}
