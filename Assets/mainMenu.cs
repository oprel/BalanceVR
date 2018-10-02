using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    public InputField playername1;
    public InputField playername2;
    public InputField playername3;
    public InputField playername4;

    private void Awake() {
        
    }

    public void startLevel1() {

        Debug.Log("Playername1 is: " + playername1.text);
        Debug.Log("Playername2 is: " + playername2.text);
        Debug.Log("Playername3 is: " + playername3.text);
        Debug.Log("Playername4 is: " + playername4.text);

        giveName.playernamestr1 = playername1.text;
        giveName.playernamestr2 = playername2.text;
        giveName.playernamestr3 = playername3.text;
        giveName.playernamestr4 = playername4.text;

        Application.LoadLevel(1);
    }

    

}

