using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuMouseOver : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public GameObject Pausemenu;
    public GameObject PausemenuSelected;



    public void OnPointerEnter(PointerEventData eventData)
    {
        Pausemenu.SetActive(false);
        PausemenuSelected.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Pausemenu.SetActive(true);
        PausemenuSelected.SetActive(false);
    }
}
