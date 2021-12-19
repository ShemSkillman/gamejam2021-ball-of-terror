using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private GameController _gm;
    private void Update()
    {
        EscapeToMenu();
    }
    public void EscapeToMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _gm.ReturnToMenu();
        }
    }
}
