using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExInteractiveUI : MonoBehaviour
{
    GameObject interactiveUI;
    // Start is called before the first frame update
    void Start()
    {
        this.interactiveUI = GameObject.Find("InteractiveUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstExample()
    {
        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("�򥻳W�h�G\n���a�C�^�X�i�U�⦸\n���I���E�c�椤�����@��ӪŮ�");
        TypeWriter.Active();
    }
}
