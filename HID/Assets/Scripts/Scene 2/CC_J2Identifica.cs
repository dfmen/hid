using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CC_J2Identifica : MonoBehaviour {
    public GameObject menuPausa;
    public GameObject j2Game;
    public GameObject j2Play;
    public GameObject identificaImagen;
    public GameObject menuWinLos;

    public List<IandR> InR;
    public GameObject[] opciones2;
    private int currentPRE2;
    public Image PreguntaImagen;    

    public Text puntuacionTxt;
    private int puntuacion = 0;
    public Text EstrellasTotal;

    private void Start() 
    {
        EstrellasTotal.text = PlayerPrefs.GetInt("estrellas").ToString();
        GenerarPreguntas();
    }

    void GenerarPreguntas()
    {
        if (InR.Count > 0)
        {
            currentPRE2 = Random.Range(0, InR.Count);
            PreguntaImagen.sprite = InR[currentPRE2].Pregunta2;
            SetPreguntas();
        }
        else
        {
            ScWinLos();
        }

    }

    public void Correcta()
    {
        puntuacion += 1;
        InR.RemoveAt(currentPRE2);
        GenerarPreguntas();
    }

    public void Incorrecta()
    {
        InR.RemoveAt(currentPRE2);
        GenerarPreguntas();
    }

    void SetPreguntas()
    {
        for (int i = 0; i < opciones2.Length; i++)
        {
            opciones2[i].GetComponent<J2_RespuestaScript>().isCorrect2 = false;
            opciones2[i].transform.GetChild(0).GetComponent<Text>().text = InR[currentPRE2].respuestas2[i];
            if (InR[currentPRE2].correctaRespuesta2 == i + 1)
            {
                opciones2[i].GetComponent<J2_RespuestaScript>().isCorrect2 = true;
            }
        }
    }



    public void ScPausa()
    {
        j2Game.SetActive(false);
        identificaImagen.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void ScWinLos()
    {
        puntuacionTxt.text = puntuacion.ToString();
        puntuacion = puntuacion + PlayerPrefs.GetInt("estrellas");
        PlayerPrefs.SetInt("estrellas", puntuacion);
        j2Game.SetActive(false);
        identificaImagen.SetActive(false);
        menuWinLos.SetActive(true);
    }

    public void ScJ2Identifica()
    {
        menuPausa.SetActive(false);
        identificaImagen.SetActive(true);
        j2Game.SetActive(true);
    }

    public void ScPlay()
    {
        j2Play.SetActive(false);
        identificaImagen.SetActive(true);
        j2Game.SetActive(true);
    }

    public void ScRetry() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ScPrincipal() => SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
}