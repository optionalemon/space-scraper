using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private List<GameObject> breakablePieces = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // Automatically find all child objects and store them as breakable pieces
        foreach (Transform child in transform)
        {
            breakablePieces.Add(child.gameObject);
            child.gameObject.SetActive(false); // Hide pieces at start
        }
        // foreach(var piece in breakablePieces) {
        //     piece.SetActive(false);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break() {
        foreach(var piece in breakablePieces) {
            piece.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
