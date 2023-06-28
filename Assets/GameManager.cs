using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;
    public ItemBox[] itemBoxes;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        this.isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
            return;
        }

        if (this.isGameOver == true)
            return;

        int overRappedCnt = 0;
        for(int i=0; i<this.itemBoxes.Length; i++)
        {
            if(this.itemBoxes[i].isOverapped == true)
                overRappedCnt++;
        }

        if (overRappedCnt == this.itemBoxes.Length)
        {
            isGameOver = true;
            winUI.SetActive(true);
        }
    }
}
