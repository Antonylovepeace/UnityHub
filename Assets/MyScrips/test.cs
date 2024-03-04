using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Events.UnityAction<BaseEventData> call = new UnityEngine.Events.UnityAction<BaseEventData>(ButtonSelected);

        EventTrigger trigger = transform.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Select;
        entry.callback.AddListener(ButtonSelected);
        trigger.triggers.Add(entry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonSelected(UnityEngine.EventSystems.BaseEventData baseEvent)
    {
        transform.GetChild(0).GetComponent<Text>().text = " ButtonSelect";
    }
 
}
