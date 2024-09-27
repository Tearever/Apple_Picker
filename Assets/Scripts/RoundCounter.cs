using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI classes like Text.

public class RoundCounter : MonoBehaviour {
    [Header("Dynamic")]
    public int      round = 1;

    private Text    uiText;
        
    void Start() {
        uiText = GetComponent<Text>();
    }

    void Update() {
        uiText.text = round.ToString( "Round: " + round );
    }
}
