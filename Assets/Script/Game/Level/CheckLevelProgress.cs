using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckLevelProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNameLevel;
    [SerializeField] private Transform gameobjLock;
    [SerializeField] private Button btnLevel;
    void Awake()
    {
        if (this.textNameLevel == null)
        {
            this.textNameLevel = transform.Find("textNameLevel").GetComponent<TextMeshProUGUI>();
            this.textNameLevel.text = gameObject.name;
        } 
        if (this.gameobjLock == null)
            this.gameobjLock = transform.Find("gameobjLock");
        this.btnLevel = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        LevelData levelData = LevelDataManager.instance.GetLevelData(int.Parse(gameObject.name) - 1);
        if (levelData != null)
        {
            if(levelData.IsComplete)
            {
                this.btnLevel.interactable = true;
                this.gameobjLock.gameObject.SetActive(false);
            }
        }
    }
}
