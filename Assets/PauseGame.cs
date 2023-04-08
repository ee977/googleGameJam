using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private int escCount = 0;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log($"esc {escCount}");

        Debug.Log($"time {Time.timeScale}"); 

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escCount++;
            switch (escCount)
            {
                case 1:
                    Time.timeScale = 0f;
                    break;
                case 2:
                    Time.timeScale = 1f;
                    escCount = 0;
                    break; 
            }        
        } 
    }
}
