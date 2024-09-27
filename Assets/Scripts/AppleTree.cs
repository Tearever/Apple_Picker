using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject   applePrefab;

    public GameObject   branchPrefab;

    // Speed at which the AppleTree moves
    public float        speed = 1f;

    // Distance where AppleTree turns around
    public float        leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float        changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float        appleDropDelay = 1f;

    public float        branchDropDelay = 1f;

    public bool         canDrop = true;

    void Start () {
        // Start dropping apples
        //Invoke("DropApple", 2f);
        if(canDrop){
            Invoke("DropApple", 2f);
        }
        Invoke("DropBranch", branchDropDelay);
    }

    void DropApple() {
        canDrop = false;
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
        canDrop = true;
    }

    void DropBranch() {
        canDrop = false;
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        Invoke("DropBranch", 2f);
        canDrop = true;
    }

    void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);   // Move Right
        }else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);  // Move Left
        // }else if (Random.value < changeDirChance) {
        //    speed *= -1;    // Change Direction
        }
    }

    void FixedUpdate () {
        // Random direction changes are not time-based due to FixedUpdate()
        if ( Random.value < changeDirChance) {
            speed *= -1;    // Change Direction
        }  
    }
}