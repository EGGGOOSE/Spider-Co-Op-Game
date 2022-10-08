using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ColorChanger : MonoBehaviour
{
    public Color32[] colors = new Color32[3];
    PhotonView view;
    public GameObject signh;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
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
