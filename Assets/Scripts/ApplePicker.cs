using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    public RoundCounter roundCounter;

    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int          numBaskets = 3;
    public float        basketBottomY = -14f;
    public float        basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start() {
        basketList = new List<GameObject>();
        // Find a GameObject named RoundCounter in the Scene Hierarchy
        GameObject roundGO = GameObject.Find( "RoundCounter" );
        // Get the RoundCounter (Script) component of roundGO
        roundCounter = roundGO.GetComponent<RoundCounter>();
        for (int i=0; i <numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO );
        }
    }

    public void AppleMissed() {
        // Destory all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach ( GameObject tempGO in appleArray ) {
            Destroy( tempGO );
        }

        // Destory all of the falling Branches
         GameObject[] branchArray=GameObject.FindGameObjectsWithTag("Branch");
        foreach ( GameObject tempGO in branchArray ) {
            Destroy( tempGO );
        }

        // Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count -1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt( basketIndex );
        Destroy( basketGO );
        // Increase the Round
        roundCounter.round += 1;

        // If there are no Baskets left, restart the game
        if ( basketList.Count == 0) {
            SceneManager.LoadScene( "_Ending_Screen" );
        }
    }
}
