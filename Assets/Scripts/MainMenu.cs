using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button simulation, enrage, credits, quit;

	// Use this for initialization
	void Start () {
        simulation = simulation.GetComponent<Button> ();
        enrage = enrage.GetComponent<Button>();
        credits = credits.GetComponent<Button>();
        quit = quit.GetComponent<Button> ();
	}
	
    void Update ()
    {
        UnityEngine.Cursor.visible = true;
    }

    public void startSimulation()
    {
        SceneManager.LoadScene("simulation");
    }

    public void startEnrage()
    {
        SceneManager.LoadScene("enrage");
    }

    public void startCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void openURL()
    {
        Application.OpenURL("http://www.squirrel-entertainment.com");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
