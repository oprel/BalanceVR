using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class positionPickerUI : MonoBehaviour {

	private RectTransform rectTransform;
	// Use this for initialization
	private void Awake()
    {
		rectTransform = GetComponent<RectTransform>();
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerDownDelegate(PointerEventData ped)
    {
         Vector2 localCursor;
         if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, ped.position, ped.pressEventCamera, out localCursor))
            return;
		if (localCursor.magnitude>rectTransform.sizeDelta.x/2) 
			return;
		 Vector2 relPos = localCursor / rectTransform.sizeDelta.x;
		 protoSpawner.self.SpawnBlock(relPos);
    }

}
