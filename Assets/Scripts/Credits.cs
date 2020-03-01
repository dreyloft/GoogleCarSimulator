using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public Button back;

	// Use this for initialization
	void Start () {
        back = back.GetComponent<Button>();
    }

    public void startBack()
    {
        SceneManager.LoadScene("menu");
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("menu");
        }

    }
}
