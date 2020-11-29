using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheme : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("Theme");
    }
}
