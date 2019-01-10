using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminaTasti : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if ((other.name == "Bottone Rosso(Clone)") || (other.name == "Bottone Giallo(Clone)") || (other.name == "Bottone Verde(Clone)"))
        {
            other.transform.position = new Vector3(200, -400, 0);
            Destroy(other, 0f);
            Debug.Log("BottoneEnter");
            Debug.Log("Mancato");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = new Vector3 (200, -400, 0);
        Destroy(other);
        Debug.Log("BottoneStay");
        Debug.Log("Mancato");
    }
}
