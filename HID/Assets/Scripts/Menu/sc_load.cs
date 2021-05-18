using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sc_load : MonoBehaviour {
    public GameObject menuOpciones;
    public GameObject menuPrincipal;

    public Dropdown resolution;
    public int calidad;
    public Slider volMus;
    public float volMusValue;

    public Text EstrellasTotal;

    private void Start(){
        EstrellasTotal.text = PlayerPrefs.GetInt("estrellas").ToString();
        
        volMus.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = volMus.value;

        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 2);
        resolution.value = calidad;
        CO_Resolucion();
    }

    public void ScOptions() {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);      
    }

    public void ScPrincipal() {
        menuOpciones.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    public void CO_Resolucion() {
        QualitySettings.SetQualityLevel(resolution.value);
        PlayerPrefs.SetInt("numeroDeCalidad", resolution.value);
        calidad = resolution.value;
    }

    public void CO_VolMus(float valor) {
        volMusValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", volMusValue);
        AudioListener.volume = volMus.value;
    }

    public void J1_Busca() => SceneManager.LoadScene("Busca la Palabra", LoadSceneMode.Single);
    public void J2_Identifica() => SceneManager.LoadScene("Identifica la Palabra", LoadSceneMode.Single); 
    public void J3_Completa() => SceneManager.LoadScene("Completa la Palabra", LoadSceneMode.Single);

    public void ExitGame() => Application.Quit();
}
