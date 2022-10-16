using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;


public class ColorChanger :MonoBehaviour
{
    public Color[] colors = new Color[3];
    public GameObject signh;
    // Start is called before the first frame update
    /*public override void Attached()
    {
        state.SetTransforms(state.Pos, transform);
    }*/
    void Start()
    {
        signh.GetComponent<SpriteRenderer>().color = colors[0];
        StartCoroutine(Do());
    }
    IEnumerator Do()
    {
		while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0;i<3;i++)
            {
                    if (colors[i] == signh.GetComponent<SpriteRenderer>().color)
                    {
                        if (i != 2)
                        {
                        signh.GetComponent<SpriteRenderer>().color = colors[i += 1];
                            break;
                        }
                    signh.GetComponent<SpriteRenderer>().color = colors[0];
                    }
            }
			yield return null;
		}
	}

}
