using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Logo : MonoBehaviour {
    
    byte opacity = 255;
    public Image image;
    int time = 0;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    void FixedUpdate ()
    {
        image.GetComponent<Image>().color = new Color32(opacity, opacity, opacity, 255);

        StartCoroutine(Timer());

        if (time > 250)
        {
            opacity -= 5;
        }

        if (opacity == 0)
        {
            SceneManager.LoadScene("menu");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.01f);
        time += 1;
    }
	
}
