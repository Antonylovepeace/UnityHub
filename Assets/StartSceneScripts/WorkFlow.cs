using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkFlow : MonoBehaviour
{
    GameObject CellGenerator;
    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
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

}
