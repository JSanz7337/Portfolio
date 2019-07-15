using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{ 
    int indexScene = 1;
    // Start is called before the first frame update
    void Start()
    { 
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine("SceneChange");
    }

    IEnumerator SceneChange()
    {
        while (indexScene < SceneManager.sceneCountInBuildSettings)
        {
			//Contamos los segundos hasta el cambio de escena.
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(indexScene);

			//Sumamos para pasar a la siguiente escena y comprobamos si hay que parar la corrutina.
            indexScene++;
            if (indexScene == SceneManager.sceneCountInBuildSettings)
            {
                StopCoroutine("SceneChange");
            }
        }
    }
}