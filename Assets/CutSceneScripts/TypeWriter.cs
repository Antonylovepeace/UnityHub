using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class TypeWriter : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;

    private static TypeWriter instance;
    public List<TypeWriterMessage> messages = new List<TypeWriterMessage>();

    private TypeWriterMessage currentMsg = null;
    private int msgIndex = 0;

    public static void Add(string msg, Action callback = null)
    {
        TypeWriterMessage typeMsg = new TypeWriterMessage(msg, callback);
        instance.messages.Add(typeMsg);
    }
    private void Update()
    {
        if (messages.Count > 0 && currentMsg != null)
        {
            currentMsg.Update();
            TextComponent.text = currentMsg.GetMsg();
        }
    }
    public static void Active()
    {
        instance.currentMsg = instance.messages[0];
    }
    private void Awake()
    {
        instance = this;
    }
    public void WriteNextMessageInQueue()
    {
        if (currentMsg != null && currentMsg.IsActive())
        {
            TextComponent.text = currentMsg.GetFullMsgAndCallBack();
            currentMsg = null;
            return;
        }

        msgIndex++;

        if (msgIndex >= messages.Count)
        {
            currentMsg = null;
            TextComponent.text = "";
            return;
        }

        currentMsg = messages[msgIndex];
    }
}

public class TypeWriterMessage
{
    private float timer = 0;
    private int charIndex = 0;
    private float timerPerChar = 0.03f;

    [SerializeField]
    public string currentMsg = null;
    private string displayMsg = null;

    private Action onActionCallBack = null;

    public void Update()
    {
        if (string.IsNullOrEmpty(currentMsg))
            return;

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer += timerPerChar;
            charIndex++;

            displayMsg = currentMsg.Substring(0, charIndex);
            displayMsg += "<color=#00000000>" + currentMsg.Substring(charIndex) + "</color>";
            
            if(charIndex >= currentMsg.Length)
            {
                CallBack();
                currentMsg = null ;
            }
        }
    }
    public bool IsActive()
    {
        if(string.IsNullOrEmpty(currentMsg))
            return false;
        return charIndex < currentMsg.Length;
    }
    public TypeWriterMessage(string msg, Action callback = null)
    {
        onActionCallBack = callback;
        currentMsg = msg;
    }

    public void CallBack()
    {
        if (onActionCallBack != null)   onActionCallBack();
    }
    public string GetFullMsgAndCallBack()
    {
        if (onActionCallBack != null) onActionCallBack();

        return currentMsg;
    }
    public string GetFullMsg()
    {
        return currentMsg;
    }
    public string GetMsg()
    {
        return displayMsg;
    }
   
}
