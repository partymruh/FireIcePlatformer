using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    public List<string> listOfScenesInOrder;

    public GameObject baseLevelObj;
    public int numLevelsInARow;
    public float spaceBetweenXAxis;
    public float spaceBetweenYAxis;

    // Start is called before the first frame update
    void Start()
    {
        int lev = 1;

        foreach (string level in listOfScenesInOrder)
        {
            GameObject newObj = Object.Instantiate<GameObject>(baseLevelObj);
            newObj.transform.GetChild(0).GetComponent<TextMesh>().text = lev.ToString();
            newObj.transform.position = new Vector3(((lev-1) % numLevelsInARow) * spaceBetweenXAxis - 6, -((lev-1) / numLevelsInARow) * spaceBetweenYAxis);
            newObj.GetComponent<ChangeLevel>().sceneName = level;
            newObj.SetActive(true);
            lev++;
        }
    }
}