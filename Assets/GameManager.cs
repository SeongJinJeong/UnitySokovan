using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject winUI;
    public bool isGameOver = false;

    private int currentStage = 1;
    private ItemBox[] itemBoxes;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        if(this != instance)
            Destroy(gameObject);
    }
    void Start()
    {
        this.ResetData();
    }
    private void ResetData()
    {
        this.isGameOver = false;
        GameObject[] itemBoxes = GameObject.FindGameObjectsWithTag("ItemBox");
        this.itemBoxes = new ItemBox[itemBoxes.Length];
        for (int i = 0; i < this.itemBoxes.Length; i++)
        {
            this.itemBoxes[i] = itemBoxes[i].GetComponent<ItemBox>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(this.isGameOver)
            {
                this.onGameClear();
            } else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
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

    public void onGameClear()
    {
        this.currentStage++;
        this.isGameOver = false;
        SceneManager.LoadScene("Scene" + this.currentStage);
    }
}
