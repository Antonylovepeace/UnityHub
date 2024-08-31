using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionScene : MonoBehaviour
{
    public GameObject IntroScene;
    public GameObject MainScene;
    public GameObject VideoScene;
    public GameObject PLAYButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateButton());
        Introduction();
    }
    IEnumerator InstantiateButton()
    {
        yield return new WaitForSecondsRealtime(3f);
        GameObject PLAYButton = Instantiate(PLAYButtonPrefab, transform);
    }

    public void setSceneFalse()
    {
        if(Round.IntroductionPlayButton == 0)
        {
            transform.GetComponent<TypeWriter2>().messages.Clear();
            TypeWriter2.Add("���U�O²�檺�C���о�\r\n" +
                "\n�k�����s�}�l����v��\r\n");
            TypeWriter2.Active();
        }
        else if (Round.IntroductionPlayButton == 1)
        {
            IntroScene.SetActive(false);
            VideoScene.SetActive(true);
        }
        Round.IntroductionPlayButton++;
    }
    public void Introduction()
    {
        transform.GetComponent<TypeWriter2>().messages.Clear();
        TypeWriter2.Add("welcome to quantum tic tac toe�I" +
            "\n\n�o���O���q�����r�C���A�ӬO���X�F²�檺�q�l����" +
            "\n\n���A�b�C��������q�l���_���C" +
            "\n\n�C�@�B������W�S���q�l�N�q�A�a�A�ֳt�F�Ѷq�l���򥻷����C" +
            "\n\n�ǳƦn�ﱵ�D�ԡA�����q�l�������a�I");
        TypeWriter2.Active();
    }
}
