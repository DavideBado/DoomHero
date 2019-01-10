using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputGiocatore : MonoBehaviour
{    
    public Text ScoreText, MoltiplicatoreText, HiScoreText;
    Animator Aanim, Sanim, Danim, GuyAnim, otherAnim;
    GameObject A, S, D;
    Collider otherGO;
    bool InArea = false;
    public int Life = 100, Points, Moltiplicatore = 1;
    int HighScore;
    private readonly int ValoreNotaPunti = 50, Danno = 10;   
    private int Sequenza = 0;    

    // Use this for initialization
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HiScore");
        A = GameObject.Find("A");
        S = GameObject.Find("S");
        D = GameObject.Find("D");
        Aanim = A.GetComponentInChildren<Animator>();
        Sanim = S.GetComponentInChildren<Animator>();
        Danim = D.GetComponentInChildren<Animator>();
        GuyAnim = GameObject.Find("DoomGuy").GetComponent<Animator>();

        A.GetComponent<BoxCollider>().enabled = false;
        S.GetComponent<BoxCollider>().enabled = false;
        D.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Morte();
        ScoreText.text = "SCORE:" + Points.ToString();
        MoltiplicatoreText.text = "BONUS:" + Moltiplicatore.ToString() + "X";
        HiScoreText.text = "Hi Score:" + HighScore.ToString();
        Rune();
        Pennata();
        GuyAnim.SetInteger("Health", Life);
    }
    void Rune()
    {
        if (Input.GetKey(KeyCode.A))
        {
            A.GetComponent<BoxCollider>().enabled = true;
            Aanim.SetBool("RuneOn", true);
        }
        else
        {
            A.GetComponent<BoxCollider>().enabled = false;
            Aanim.SetBool("RuneOn", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            S.GetComponent<BoxCollider>().enabled = true;
            Sanim.SetBool("RuneOn", true);
        }
        else
        {
            S.GetComponent<BoxCollider>().enabled = false;
            Sanim.SetBool("RuneOn", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            D.GetComponent<BoxCollider>().enabled = true;
            Danim.SetBool("RuneOn", true);
        }
        else
        {
            D.GetComponent<BoxCollider>().enabled = false;
            Danim.SetBool("RuneOn", false);
        }
    }
    void Pennata()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {            
            if(InArea == true && otherGO.GetComponent<BoxCollider>().enabled == true)
            {
                otherAnim.SetBool("Colpito", true);
                Points += (ValoreNotaPunti * Moltiplicatore);
                if (Life <= 90)
                {
                    Life += Danno;
                }

                otherGO.GetComponent<BoxCollider>().enabled = false;                
  
                Sequenza += 1;
                if (Sequenza < 10)
                {
                    Moltiplicatore = 1;
                }
                else if (Sequenza >= 10)
                {
                    if (Sequenza < 20)
                    {
                        Moltiplicatore = 2;
                    }
                    else if (Sequenza < 30)
                    {
                        Moltiplicatore = 3;
                    }
                    else Moltiplicatore = 4;
                }
                
            }
            if(InArea == false) 
            {                              
                Life -= Danno;
                Moltiplicatore = 1;
                Sequenza = 0;                
            }          
        }                   
        
            if (Input.GetKey(KeyCode.Escape))
            {
            SceneManager.LoadScene(1);
            }
    }

    void Morte()
    {
        if ((Life == 0) && (Points > HighScore))
        {
            Salvatore();
            SceneManager.LoadScene(4);
        }
        if ((Life == 0) && (Points < HighScore))
        {
            SceneManager.LoadScene(5);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Nota")
        {
            otherGO = other;
            otherAnim = other.GetComponent<Animator>();
            InArea = true;
        }         
    }                
    
    private void OnTriggerExit(Collider other)
    {        
        InArea = false;
    }

    void Salvatore()
    {
        PlayerPrefs.SetInt("HiScore", Points);
        PlayerPrefs.Save();
    }    
}
