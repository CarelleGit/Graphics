using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControls : MonoBehaviour
{
    [SerializeField]
    private RectTransform controlPanel;
    [SerializeField]
    private bool placeholder;
    

    public void OpenPanel()
    {
        placeholder = true;
    }

    public void ClosePanel()
    {
        placeholder = false;
    }

    // Use this for initialization
    void Start()
    {
        
        placeholder = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(placeholder == false)
        {
            controlPanel.position = Vector3.Lerp(controlPanel.position, new Vector3(0, controlPanel.position.y), Time.deltaTime * 5);
        }
        else
        {
            controlPanel.position = Vector3.Lerp(controlPanel.position, new Vector3(Screen.width, controlPanel.position.y), Time.deltaTime * 5);
        }

    }
}
