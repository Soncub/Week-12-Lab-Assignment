using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptTwo : MonoBehaviour
{

    public string[] firstNames = new string[] {
        "Jesse",
        "Andrew",
        "Brandon",
        "Ryan",
        "Jeff",
        "Chloe",
        "Tom",
        "Michael",
        "Jeremy",
        "Donny",
        "Xavier",
        "Wendy",
        "Lori",
        "Nick",
        "Daria",
        "Alex",
        "Steve",
        "Hannah",
        "Beth",
        "Felix",
        "Mason",
        "Maya",
        "Terrance",
        "Lucas"
    };

    string[] names = new string[15];

    void Start()
    {
        for (int i = 0; i < names.Length; i++) names[i] = firstNames[Random.Range(0, firstNames.Length)];

        HashSet<string> uniqueItems = new HashSet<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (string item in names)
            if (!uniqueItems.Add(item)) 
                duplicates.Add(item);
        
        Debug.Log("Created the name array: " + ScriptOne.FullList(names));
        if (duplicates.Count > 0) Debug.Log("The array has duplicate names: " + ScriptOne.FullList(duplicates.ToArray()));
    }
}
