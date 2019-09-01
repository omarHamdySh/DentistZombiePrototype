using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTypingAnimation : MonoBehaviour
{
	public IEnumerator currentcourtine;
    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterPaused = 0.01f;
    //Message that will displays till the end that will come out letter by letter
    public string strmessage;
    //Text for the message to display
    public Text textComp;
    public Text LabelName;

    // Use this for initialization
    void Start()
    {
        //Get text component
        textComp = GetComponent<Text>();
        //Message will display will be at Text
        strmessage = textComp.text;
        //Set the text to be blank first
        textComp.text = "";
        //Call the function and expect yield to return
        //StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        //Split each char into a char array

        foreach (char letter in strmessage.ToCharArray())
        {
            //Add 1 letter each
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
    }
    public void TextStart(string massage, string labelname)
    {
        LabelName.text = "";
        LabelName.text = labelname;
        textComp.text = "";
        strmessage = "";
        strmessage = massage;
        if (currentcourtine != null)
        {
            StopCoroutine(currentcourtine);
        }
        currentcourtine = TypeText();
        StartCoroutine(currentcourtine);


    }

}