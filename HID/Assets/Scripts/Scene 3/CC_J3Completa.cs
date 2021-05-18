using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CC_J3Completa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject j3Game;
    public GameObject j3Play;
    public GameObject completaOracion;
    public GameObject menuWinLos;

    public List<CandR> CnR;
    public GameObject[] opciones3;
    private int currentPRE3;
    public Image PreguntaImagen;
    public Text PreguntaTxtImagen;

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
        if (CnR.Count > 0)
        {
            currentPRE3 = Random.Range(0, CnR.Count);
            PreguntaImagen.sprite = CnR[currentPRE3].Pregunta3;
            PreguntaTxtImagen.text = CnR[currentPRE3].PreguntaTxt3;
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
        CnR.RemoveAt(currentPRE3);
        GenerarPreguntas();
    }

    public void Incorrecta()
    {
        CnR.RemoveAt(currentPRE3);
        GenerarPreguntas();
    }

    void SetPreguntas()
    {
        for (int i = 0; i < opciones3.Length; i++)
        {
            opciones3[i].GetComponent<J3_RespuestasScript>().isCorrect3 = false;
            opciones3[i].transform.GetChild(0).GetComponent<Text>().text = CnR[currentPRE3].respuestas3[i];
            if (CnR[currentPRE3].correctaRespuesta3 == i + 1)
            {
                opciones3[i].GetComponent<J3_RespuestasScript>().isCorrect3 = true;
            }
        }
    }



    public void ScPausa()
    {
        j3Game.SetActive(false);
        completaOracion.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void ScWinLos()
    {
        puntuacionTxt.text = puntuacion.ToString();
        puntuacion = puntuacion + PlayerPrefs.GetInt("estrellas");
        PlayerPrefs.SetInt("estrellas", puntuacion);
        j3Game.SetActive(false);
        completaOracion.SetActive(false);
        menuWinLos.SetActive(true);
    }

    public void ScJ3Completa()
    {
        menuPausa.SetActive(false);
        completaOracion.SetActive(true);
        j3Game.SetActive(true);
    }

    public void ScPlay()
    {
        j3Play.SetActive(false);
        completaOracion.SetActive(true);
        j3Game.SetActive(true);
    }

    public void ScRetry() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ScPrincipal() => SceneManager.LoadScene("Menu Principal", LoadSceneMode.Single);
}
