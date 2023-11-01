using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textur : MonoBehaviour
{
    [SerializeField] private Texture2D textur;
    public FilterMode filterMode;
    public Gradient gr;
    public TextureWrapMode wrap;
    public int number = 128;
    private void Start()
    {
        textur = new Texture2D(number, number);
        GetComponent<Renderer>().material.mainTexture = textur;
        for (int i = 0; i < number; i++)
        {
            for (int j = 0; j < number; j++)
            {
                textur.SetPixel(i, j, new Color(0f, 0f, 0f, 1f));
            }
        }

        textur.Apply();
    }
    private void Update()
    {
        #region
        if (textur == null)
        {
            textur = new Texture2D(number, number);
            GetComponent<Renderer>().material.mainTexture = textur;
        }
        if (textur.width != number)
        {
            textur.Resize(number, number);
        }
        textur.filterMode = filterMode;
        textur.wrapMode = wrap;
        #endregion
        
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Vector3 contactPoint = collision.contacts[0].point - transform.position + transform.localScale/2;
            float radius = collision.transform.localScale.x;

            StartCoroutine(Kor(contactPoint.x, contactPoint.y, radius));
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Kor(float x, float y, float radius)
    {
        int x0 = Mathf.RoundToInt(x * number / 100);
        int y0 = Mathf.RoundToInt(y * number / 100);
        int radius0 = Mathf.RoundToInt(radius * number / 100*5);
        for (int i = x0 - radius0; i <= x0 + radius0; i++)
        {
            for (int j = y0 - radius0; j <= y0 + radius0; j++)
            {
                if (Mathf.Pow(i - x0 + 0.5f, 2) + Mathf.Pow(j - y0 + 0.5f, 2) < Mathf.Pow(radius0, 2))
                {
                    textur.SetPixel(i, j, new Color(1f, 1f, 1f, 1f));
                }
            }

        }
        int random = Random.Range(1, 18);
        for (int k = 0; k<random;k++) {
            int random1 = Random.Range(-5, 5);
            int random2 = Random.Range(-5, 5);
            int randomRadius = Random.Range(2, 15);
            int radius1 = Mathf.RoundToInt(radius0 / randomRadius);
            for (int i = x0 - radius1 + radius0 * random1; i <= x0 + radius1 + radius0 * random1; i++)
            {
                for (int j = y0 - radius1 + radius0 * random2; j <= y0 + radius1 + radius0 * random2; j++)
                {
                    if (Mathf.Pow(i - x0 - radius0 * random1 + 0.5f, 2) + Mathf.Pow(j - y0 - radius0 * random2 + 0.5f, 2) < Mathf.Pow(radius1, 2))
                    {
                        textur.SetPixel(i, j, new Color(1f, 1f, 1f, 1f));
                    }
                }
            }
        }
        textur.Apply();
        yield break;
    }
}
