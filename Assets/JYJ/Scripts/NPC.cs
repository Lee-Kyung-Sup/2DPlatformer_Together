using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject NPCUI;
    public GameObject Text1;
    public GameObject Text2;

    private void OnMouseDown()
    {
        NPCUI.SetActive(true);
    }

    public void ExitBtn()
    {
        NPCUI.SetActive(false);
    }
    public void NextBtn()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
    }
}
