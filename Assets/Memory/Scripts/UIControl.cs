using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour

{
    [SerializeField] private GameObject panelMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActivePanel()
    {
        panelMenu.SetActive(true);
    }
    
    public void setDeactivePanel()
    {
        panelMenu.SetActive(false);
    }


    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
