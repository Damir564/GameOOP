using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BuildingUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Image Ram;
    bool B = false;
    float T = 0;
    public UnityEvent Event;
    public UnityEvent OnHover;
    public UnityEvent OnUnHover;
    public void OnPointerExit(PointerEventData e)
    {
        Ram.color = Color.gray;
        OnUnHover.Invoke();
    }
    public void OnPointerEnter(PointerEventData e)
    {
        Ram.color = Color.white;
        OnHover.Invoke();
    }
    public void OnPointerDown(PointerEventData e)
    {
        Ram.color = Color.cyan;
        B = true;
        T = 0.5f;
        Event.Invoke();
    }
    private void Update()
    {
        if (!B) return;
        if (T > 0) T -= Time.deltaTime;
        if (T <= 0)
        {
            T = 0;
            B = false;
            Ram.color = Color.gray;
        }
    }
}
