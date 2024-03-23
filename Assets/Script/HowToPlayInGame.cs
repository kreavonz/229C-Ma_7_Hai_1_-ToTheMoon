using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayInGame : MonoBehaviour
{
    public Behaviour HowToPlayCanvas;
          
    public void HowToPlayUI()
    {
        HowToPlayCanvas.enabled = !HowToPlayCanvas.enabled;
    }

}
