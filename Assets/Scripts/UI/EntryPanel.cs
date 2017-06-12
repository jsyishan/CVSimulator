using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntryPanel : MonoBehaviour {

	public void start() { SceneManager.LoadSceneAsync ("battle"); }

	public void help () {
	
	}

	public void setting () {
		 	
	}

	public void exit () { Application.Quit (); }

}
