using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowPressure : MonoBehaviour
{
    private TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        
    }
    void Update()
    {
        txt.text = Game.Instance.Pressure.ToString();  
    }
}
