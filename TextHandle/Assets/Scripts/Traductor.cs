using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Traductor : MonoBehaviour {

	public TextAsset fichero;

    public GameObject panelIdiomas;
    public GameObject panelMenu;

	public Text UI_title;
    public Text UI_userText;
    public Text UI_userInput;
    public Text UI_passwordText;
    public Text UI_passwordInput;
    public Text UI_loginButton;
    public Text UI_optionsButton;
    public Text UI_exitButton;

    public TextAsset langFile;

    public string idiomaSel;
	public string[] textoLeido = new string[8];
    public string titleString;

	int indice = 0;

    public float pause = 0.2f;

    

	void Start () {

        SystemLanguage lang = Application.systemLanguage;

        panelIdiomas.SetActive(true);
        panelMenu.SetActive(false);
    }
	
    public void LanguageSelect(string _language){
        idiomaSel = _language;

        LoadText();
        TranslateText();        

        panelIdiomas.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void BackToSelect()
    {
        StopCoroutine("AutoType");
        panelIdiomas.SetActive(true);
        panelMenu.SetActive(false);
    }

    /* LECTURA DE FICHEROS INDIVIDUALES */
    public void LoadText()
    {
        
        string line;

        StreamReader reader = new StreamReader(Application.dataPath+"/Textos/"+idiomaSel+".txt");
        
        do
        {
            line = reader.ReadLine();
            if (line != null)
            {
                if (line.Length > 0)
                {
                    textoLeido[indice] = line;
                    indice++;
                }
            }
        } while (line != null);

        indice = 0;
        reader.Close();
    }

    public void TranslateText(){
        titleString = textoLeido[0];
        StartCoroutine("AutoType"); 
        UI_userText.text = textoLeido[1];
        UI_userInput.text = textoLeido[2];
        UI_passwordText.text = textoLeido[3];
        UI_passwordInput.text = textoLeido[4];
        UI_loginButton.text = textoLeido[5];
        UI_optionsButton.text = textoLeido[6];
        UI_exitButton.text = textoLeido[7];
    }


    IEnumerator AutoType()
    {
        UI_title.text = "";
        foreach (char letter in titleString.ToCharArray())
        {
            UI_title.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(pause);
        }
        titleString = "";
    }
}
