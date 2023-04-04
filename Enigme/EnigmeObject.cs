using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enigme", menuName = "Enigme/new enigme")]
public class EnigmeObject : ScriptableObject
{

    public int ID;
    public string nom;
    public GameObject enigmeUI;
    public DialogueMessage[] dialogue; 

}

[System.Serializable]
public class DialogueMessage
{
    public string author;
    [TextArea]
    public string message;
}
