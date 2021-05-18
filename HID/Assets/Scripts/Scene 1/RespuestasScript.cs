using UnityEngine;

public class RespuestasScript : MonoBehaviour {
    public bool isCorrect = false;
    public CC_J1Busca busca;

    public void Respuesta() {
        if (isCorrect) {
            Debug.Log("Correcta");
            busca.Correcta();
        } else {
            Debug.Log("Incorrecta");
            busca.Incorrecta();
        }
    }
}
