using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    public GameObject door;
    private int levelToLoad;


    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {

            int i = SceneManager.GetActiveScene().buildIndex;

            if (i == 1) {
                FadeToLevel(0);
                Debug.Log("0");

            } else {
                FadeToLevel(1);
                Debug.Log("1");
            }
        }
    }


    public void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }


    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
