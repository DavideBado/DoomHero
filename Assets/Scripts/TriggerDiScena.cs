using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDiScena : MonoBehaviour {
    public bool InScena = true;
    GameObject CRosso, CGiallo, CVerde;
    int Dove, Dove2;
    float Speed;
    // Use this for initialization
    void Start () {
        CRosso = GameObject.Find("Bottone Rosso");
        CGiallo = GameObject.Find("Bottone Giallo");
        CVerde = GameObject.Find("Bottone Verde");
       
    }

    private void OnTriggerExit(Collider other)
    {
        InScena = false;

        other.transform.position = new Vector3(0f, -20f, 275f);

        Dove2 = Dove;
        Dove = Random.Range(0, 11);

        if (Dove != Dove2)
        {
            if (Dove == 0)
            {
                GameObject CloneRosso;
                CloneRosso = Instantiate(CRosso, new Vector3(CRosso.transform.position.x, CRosso.transform.position.y, 275), Quaternion.identity);
                CloneRosso.transform.parent = other.transform;
            }

            if (Dove == 1)
            {
                GameObject CloneGiallo;
                CloneGiallo = Instantiate(CGiallo, new Vector3(CGiallo.transform.position.x, CGiallo.transform.position.y, 275), Quaternion.identity);
                CloneGiallo.transform.parent = other.transform;
            }

            if (Dove == 2)
            {
                GameObject CloneVerde;
                CloneVerde = Instantiate(CVerde, new Vector3(CVerde.transform.position.x, CVerde.transform.position.y, 275), Quaternion.identity);
                CloneVerde.transform.parent = other.transform;
            }

        }
          
    }   
}
