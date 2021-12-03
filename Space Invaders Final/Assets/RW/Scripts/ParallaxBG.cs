using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField]
    private Image background;

    [SerializeField]
    private Image background2;

    // Start is called before the first frame update
    void Start()
    {
        background.transform.position = new Vector2(0f,0f);
        background.rectTransform.sizeDelta = new Vector2(Screen.currentResolution.width+100, Screen.currentResolution.height+100);

        background2.transform.position = new Vector2(0f, Screen.currentResolution.height-200);
        background2.rectTransform.sizeDelta = new Vector2(Screen.currentResolution.width + 100, Screen.currentResolution.height + 100);

    }

    // Update is called once per frame
    void Update()
    {
        ////Background 1 
        //Vector2 newBGPos = new Vector2(background.transform.position.x, background.transform.position.y - 200 * Time.deltaTime);
        //background.transform.position = newBGPos;
        //if (background.transform.position.y <= -550)
        //{
        //    Vector2 resetBGPos = new Vector2(background.transform.position.x, 700);
        //    background.transform.position = resetBGPos;
        //}

        ////Background 2
        //Vector2 newBGPos2 = new Vector2(background2.transform.position.x, background2.transform.position.y - 200 * Time.deltaTime);
        //background2.transform.position = newBGPos2;
        //if (background2.transform.position.y <= -550)
        //{
        //    Vector2 resetBGPos = new Vector2(background2.transform.position.x, 700);
        //    background2.transform.position = resetBGPos;
        //}

        //Background 1 
        Vector2 newBGPos = new Vector2(0f, background.transform.position.y - 200 * Time.deltaTime);
        background.transform.position = newBGPos;
        if (background.transform.position.y < -Screen.currentResolution.height+100)
        {
            Vector2 resetBGPos = new Vector2(0f, Screen.currentResolution.height-220);
            background.transform.position = resetBGPos;
        }

        //Background 2
        Vector2 newBGPos2 = new Vector2(0f, background2.transform.position.y - 200 * Time.deltaTime);
        background2.transform.position = newBGPos2;
        if (background2.transform.position.y < -Screen.currentResolution.height+100)
        {
            Vector2 resetBGPos = new Vector2(0f, Screen.currentResolution.height-220);
            background2.transform.position = resetBGPos;
        }
    }
}
