using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySquare : MonoBehaviour
{
    public GameObject filledSquarePrefab;
    public static GameObject emptySquare;

    void OnMouseDown()
    {
        GameObject filledSquare = Instantiate(filledSquarePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    

}
