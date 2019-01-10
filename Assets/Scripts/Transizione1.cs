using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transizione1 : MonoBehaviour
{
    AudioSource Audio;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(!Audio.isPlaying || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(3);
        }
	}
}
