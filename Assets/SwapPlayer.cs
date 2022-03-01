using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject P1;
    [SerializeField]
    GameObject P2;

    // Start is called before the first frame update
    void Start()
    {
        P1.SetActive(true);
        P2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            P1.SetActive(!P1.activeSelf);
            P2.SetActive(!P2.activeSelf);
        }
    }
}
