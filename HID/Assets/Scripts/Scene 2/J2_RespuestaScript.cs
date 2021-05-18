using UnityEngine;

public class J2_RespuestaScript : MonoBehaviour
{
    public bool isCorrect2 = false;
    public CC_J2Identifica identifica;

    public void Respuesta()
    {
        if (isCorrect2)
        {
            Debug.Log("Correcta");
            identifica.Correcta();
        }
        else
        {
            Debug.Log("Incorrecta");
            identifica.Incorrecta();
        }
    }
}
