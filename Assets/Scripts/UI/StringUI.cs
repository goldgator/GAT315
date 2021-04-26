using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StringUI : MonoBehaviour
{
    public StringData data;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnValidate()
    {
        if (data != null)
        {
            name = data.name;
            text.text = name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = data.value;
    }
}
