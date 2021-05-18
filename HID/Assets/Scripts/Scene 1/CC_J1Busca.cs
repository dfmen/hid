using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CC_J1Busca : MonoBehaviour {
    public GameObject menuPausa;
    public GameObject j1Game;
    public GameObject j1Play;
    public GameObject buscaPalabra;
    public GameObject menuWinLos;

    public List<RandR> SnR;
    public GameObject[] opciones;
    private int currentPRE;
    public AudioSource PreguntaAudio;

    public Text puntuacionTxt;
    private int puntuacion=0;
    public Text EstrellasTotal;

    private void Start() {
        EstrellasTotal.text = PlayerPrefs.GetInt("estrellas").ToString();
        GenerarPreguntas();
    }

    void GenerarPreguntas() {
        if (SnR.Count > 0) {
            currentPRE = Random.Range(0, SnR.Count);
            PreguntaAudio.clip = SnR[currentPRE].Pregunta;
            SetPreguntas();
        } else {
            ScWinLos();
        }
        
    }

    public void Correcta() {
        puntuacion += 1;
        SnR.RemoveAt(currentPRE);
        GenerarPreguntas();
    }

    public void Incorrecta() {
        SnR.RemoveAt(currentPRE);
        GenerarPreguntas();
    }

    void SetPreguntas() {
        for(int i=0; i<opciones.Length; i++) {
            opciones[i].GetComponent<RespuestasScript>().isCorrect = false;
            opciones[i].transform.GetChild(0).GetComponent<Text>().text = SnR[currentPRE].respuestas[i];
            if(SnR[currentPRE].correctaRespuesta == i+1) {
                opciones[i].GetComponent<RespuestasScript>().isCorrect = true;
            }
        }
    }



    public void ScPausa() {
        j1Game.SetActive(false);
        buscaPalabra.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void ScWinLos() {
        puntuacionTxt.text = puntuacion.ToString();
        puntuacion = puntuacion + PlayerPrefs.GetInt("estrellas");
        PlayerPrefs.SetInt("estrellas", puntuacion);
        j1Game.SetActive(false);
        buscaPalabra.SetActive(false);
        menuWinLos.SetActive(true);        
    }

    public void ScJ1Busca() {
        menuPausa.SetActive(false);
        buscaPalabra.SetActive(true);
        j1Game.SetActive(true);
    }

    public void ScPlay() {
        j1Play.SetActive(false);
        buscaPalabra.SetActive(true);
        j1Game.SetActive(true);
    }

    public void ScRetry() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ScPrincipal() => SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
}