using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Opening : MonoBehaviour
{
    public GameObject InteractiveUi;
    public GameObject opening;
    public GameObject StartButton;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            //TypeWriterMessage.timerPerChar = 0.05f;
            transform.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("welcome to quantum tic tac toe�I\n" +
                "�o���O���q�����r�C���A�ӬO���X�F²�檺�q�l����\n" +
                "���A�b�C��������q�l���_���C\n" +
                "�C�@�B������W�S���q�l�N�q�A�a�A�ֳt�F�Ѷq�l���򥻷���\n" +
                "�ǳƦn�ﱵ�D�ԡA�����q�l�������a�I\r\n");
            TypeWriter.Active();
        }
        Invoke("startButton", 1.5f);
    }
    void startButton()
    {
        Instantiate(StartButton, transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AcallFuncStartButtonOnClicked()
    {
        InteractiveUi.SetActive(true);
        opening.SetActive(false);
        Destroy(GameObject.Find("StartButton(Clone)"));
    }
}
