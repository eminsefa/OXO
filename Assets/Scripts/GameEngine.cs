using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public int numberOfGrids;
    int numberOfBoxes;

    GameObject[] boxes;
    public GameObject emptySquare;

    public Camera cam;
    
    void Start()
    {
        numberOfGrids = int.Parse(FindObjectOfType<InputField>().text);

        numberOfBoxes = numberOfGrids * numberOfGrids;
        boxes = new GameObject[numberOfBoxes];

        cam.orthographicSize = numberOfGrids/(cam.aspect*2);

        for (int i = 0; i < numberOfBoxes; i++)
        {            
            GameObject go = Instantiate(emptySquare, new Vector2(Mathf.Repeat(i,numberOfGrids), Mathf.Ceil(i / numberOfGrids)),Quaternion.identity);
            boxes[i] = go;
        }

        cam.transform.position = boxes[0].transform.position + new Vector3(cam.orthographicSize * cam.aspect, numberOfGrids - 1-cam.orthographicSize, -10f);

    }
    
   
    
    
}
