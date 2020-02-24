using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilledSquare : MonoBehaviour
{
    BoxCollider2D bc;

    public GameObject emptySquarePrefab;

    RaycastHit2D[] hitInfo;
    bool[] rays;

    public List<GameObject> destroyableSquares =new List<GameObject>();    
    
    void Start()
    {
        rays = new bool[4];
        for (int i=0;i<4;i++)
        {
            rays[i] = true;
        }

        bc = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        RaycastHit2D hitInfo1 = Physics2D.Raycast(transform.position + new Vector3(bc.offset.x, 0, 0), Vector2.up / 2);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position + new Vector3(bc.offset.x, bc.offset.y * 2, 0), Vector2.down / 2);
        RaycastHit2D hitInfo3 = Physics2D.Raycast(transform.position + new Vector3(bc.offset.x * 2, bc.offset.y, 0), Vector2.right / 2);
        RaycastHit2D hitInfo4 = Physics2D.Raycast(transform.position + new Vector3(0, bc.offset.y, 0), Vector2.left / 2);

        hitInfo = new RaycastHit2D[4];
        hitInfo[0] = hitInfo1;
        hitInfo[1] = hitInfo2;
        hitInfo[2] = hitInfo3;
        hitInfo[3] = hitInfo4;
            for (int i = 0; i < 4; i++)
            {            
                if (hitInfo[i].collider != null)
                {
                if (hitInfo[i].collider.tag == "FilledSquare" && rays[i])
                    {
                        destroyableSquares.Add(hitInfo[i].collider.gameObject);
                        rays[i] = false;
                    }
                }                
            }
        if (destroyableSquares.Count >= 2)
        {
            StartCoroutine(DestroySquares());            
        }
    }
    IEnumerator DestroySquares()
    {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < 4; i++)
            {
                rays[i] = true;
            }
            
            foreach (GameObject filledSquare in destroyableSquares)
            {                
                    foreach (GameObject go in filledSquare.GetComponent<FilledSquare>().destroyableSquares)
                    {
                        if (go != null)
                        {
                            Destroy(go.gameObject);                            
                        }
                    }
                    Destroy(filledSquare);
            }
            Destroy(gameObject);
    }
    void OnDestroy()
    {
        Instantiate(emptySquarePrefab, transform.position, Quaternion.identity);
    }
}

