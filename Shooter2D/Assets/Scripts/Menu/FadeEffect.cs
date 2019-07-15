using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeEffect : MonoBehaviour
{

    public Image blackScreen;
    public GameObject buttonPanel;

    bool ease = false;
    bool vuelta = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        blackScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (ease)
        {
            if (blackScreen.color.a < 1 && !vuelta)
            {
                float valor = blackScreen.color.a;

                valor = LinearTweening(Time.deltaTime, valor, 1f, 1f);

                Color colorAux = blackScreen.color;
                colorAux.a = valor;
                blackScreen.color = colorAux;

                if (blackScreen.color.a >= 1)
                {
                    vuelta = true;
                }
            }
            else
            {
                buttonPanel.SetActive(false);
                
                float valor = blackScreen.color.a;

                valor = LinearTweening(Time.deltaTime, valor, -1f, 0.8f);

                Color colorAux = blackScreen.color;
                colorAux.a = valor;
                blackScreen.color = colorAux;
				
                SceneManager.LoadScene("FirstWorld");
                if (blackScreen.color.a <= 0)
                {
                    ease = false;
                    vuelta = false;
                }
            }
        }
    }

    public void FadeControl()
    {
        vuelta = false;
        ease = true;
        blackScreen.gameObject.SetActive(true);
    }

    float LinearTweening(float t, float b, float c, float d)
    {
        return c * t / d + b;
    }
}

