using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static int score = 5;
    public GameObject enemy;
    public GameObject enemyStart;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 enemyPosition = enemyStart.transform.position;
        Instantiate(enemy, enemyPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            SceneManager.LoadScene(0);
        }
    }
}
