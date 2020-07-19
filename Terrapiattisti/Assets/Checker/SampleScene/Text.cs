using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public void Done(bool done)
    {
        if (done)
            textMesh?.SetText("GENERATORE COMPLETATO");
        else
            textMesh?.SetText("BOOOOOOOOOOOM");
    }
}
