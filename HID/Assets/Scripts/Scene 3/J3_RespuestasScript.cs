using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J3_RespuestasScript : MonoBehaviour
{
    public bool isCorrect3 = false;
    public CC_J3Completa completa;

    public void Respuesta()
    {
        if (isCorrect3)
        {
            Debug.Log("Correcta");
            completa.Correcta();
        }
        else
        {
            Debug.Log("Incorrecta");
            completa.Incorrecta();
        }
    }
}
