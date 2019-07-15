using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Management : MonoBehaviour
{

    public Image hp;
    public Image pistol;
    public Image shotgun;

    Color colorAux_hp;
    Color colorAux_Pistol;
    Color colorAux_Shotgun;

    Transform transformAux_HP;
    Transform transformAux_Pistol;
    Transform transformAux_Shotgun;

    int weapon = 0;
    int hitPoints = 3;

    bool invencible = false;
    bool swapEffect = false;
    bool swapEffectBack = false;
    bool pistolSwap = false;
    bool shotgunSwap = false;

    public string reloadText = "Reloading!";

    public Text UI_Reload;

    void Start()
    {
        pistol.gameObject.SetActive(true);
        shotgun.gameObject.SetActive(false);


        colorAux_Pistol = pistol.color;
        colorAux_Pistol.a = 1;
        pistol.color = colorAux_Pistol;

        colorAux_Shotgun = shotgun.color;
        colorAux_Shotgun.a = 0;
        shotgun.color = colorAux_Shotgun;
    }

    // Update is called once per frame
    void Update()
    {
        if (swapEffect)
        {
            switch (weapon)
            {
                case 0:
                    pistolSwap = true;
                    break;
                case 1:
                    shotgunSwap = true;
                    break;
                default:
                    break;
            }
        }

        if (pistolSwap)
        {
            pistol.gameObject.SetActive(true);

            if (pistol.color.a <= 1 && !swapEffectBack)
            {

                float valorAlpha = pistol.color.a;
                float valorRed = pistol.color.r;

                float valorAlpha2 = shotgun.color.a;

                valorAlpha = LinearTweening(Time.deltaTime, valorAlpha, 1f, 0.3f);
                valorRed = LinearTweening(Time.deltaTime, valorRed, -1f, 0.3f);

                valorAlpha2 = LinearTweening(Time.deltaTime, valorAlpha2, -1f, 0.3f);

                Color colorAux = pistol.color;
                colorAux.a = valorAlpha;
                colorAux.r = valorRed;
                pistol.color = colorAux;

                Color colorAux2 = shotgun.color;
                colorAux2.a = valorAlpha2;
                shotgun.color = colorAux2;

                if (pistol.color.r <= 0)
                {
                    swapEffectBack = true;
                }

                shotgun.gameObject.SetActive(false);
            }
            else
            {
                float valorRed = pistol.color.r;

                valorRed = LinearTweening(Time.deltaTime, valorRed, 1f, 0.3f);

                Color colorAux = pistol.color;
                colorAux.r = valorRed;
                pistol.color = colorAux;

                if (pistol.color.r >= 1)
                {
                    swapEffect = false;
                    swapEffectBack = false;
                    shotgunSwap = false;
                }
            }
            pistolSwap = false;
        }



        if (shotgunSwap)
        {
            shotgun.gameObject.SetActive(true);

            if (shotgun.color.a <= 1 && !swapEffectBack)
            {

                float valorAlpha = shotgun.color.a;
                float valorRed = shotgun.color.r;

                float valorAlpha2 = pistol.color.a;

                valorAlpha = LinearTweening(Time.deltaTime, valorAlpha, 1f, 0.3f);
                valorRed = LinearTweening(Time.deltaTime, valorRed, -1f, 0.3f);

                valorAlpha2 = LinearTweening(Time.deltaTime, valorAlpha2, -1f, 0.3f);

                Color colorAux = shotgun.color;
                colorAux.a = valorAlpha;
                colorAux.r = valorRed;
                shotgun.color = colorAux;

                Color colorAux2 = pistol.color;
                colorAux2.a = valorAlpha2;
                pistol.color = colorAux2;

                if (shotgun.color.r <= 0)
                {
                    swapEffectBack = true;
                }

                pistol.gameObject.SetActive(false);
            }
            else
            {
                float valorRed = shotgun.color.r;

                valorRed = LinearTweening(Time.deltaTime, valorRed, 1f, 0.3f);

                Color colorAux = shotgun.color;
                colorAux.r = valorRed;
                shotgun.color = colorAux;

                if (shotgun.color.r >= 1)
                {
                    swapEffect = false;
                    swapEffectBack = false;
                    shotgunSwap = false;
                }
            }

            shotgunSwap = false;
        }


    }


    public void ReloadWepon()
    {
        StartCoroutine("AutoType");
    }

    float LinearTweening(float t, float b, float c, float d)
    {
        return c * t / d + b;
    }
    public void WeaponSwap(int _weapon)
    {
        weapon = _weapon;
        swapEffect = true;
    }

    public void GetHit()
    {
        if (!invencible)
        {
            StartCoroutine("Damaged");
        }
    }

    IEnumerator Damaged()
    {
        invencible = true;
        hitPoints -= 1;
        while (hp.fillAmount > (float)hitPoints / 3)
        {
            float valorAux1 = hp.fillAmount;
            valorAux1 = 0.16f;
            hp.fillAmount = hp.fillAmount - valorAux1;

            yield return new WaitForSeconds(0.05f);
        }
        invencible = false;
    }

    IEnumerator AutoType()
    {
        foreach (char letter in reloadText.ToCharArray())
        {
            Debug.Log(letter);
            UI_Reload.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(0.12f);
        }
        UI_Reload.text = "";
    }
}
