using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMenager : MonoBehaviour
{
    public Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }
}
