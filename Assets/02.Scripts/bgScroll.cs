using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    Material bgMaterial;

    // Start is called before the first frame update
    void Awake()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float newOffsetY = bgMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);
        bgMaterial.mainTextureOffset = newOffset;
    }
}
