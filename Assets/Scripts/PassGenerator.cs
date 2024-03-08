using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassGenerator : MonoBehaviour
{
    public bool Generated = false;
    public CaveGenerator caveGenerator;
    private void Start()
    {
        caveGenerator = FindObjectOfType<CaveGenerator>();
    }
}
