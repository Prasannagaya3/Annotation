using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IdentifiesCubeInformation : MonoBehaviour
{
    public TextMeshProUGUI DisplayStats, Result;

    private void FixedUpdate()
    {
        DisplayStats.text = " X : " + this.transform.localEulerAngles.x + " Y : " + this.transform.localEulerAngles.y + " Z : " + this.transform.localEulerAngles.z;

        if(this.transform.localEulerAngles.y < 60)
        {
            Result.text = "Right";
        }
        else
        {
            Result.text = "Wrong";
        }
    }
}
