using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTex : MonoBehaviour
{
    // Start is called before the first frame update

    public Texture aTexture;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if(!aTexture)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }
        GUI.DrawTexture(new Rect(Screen.width - 130, 10,120,120),aTexture, ScaleMode.ScaleToFit, true);
    }
}
