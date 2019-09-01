using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtEffectSplash : MonoBehaviour
{
    //reference for the image boold effect
    public Image hurtEffectBorder;
    //public Image fadingImage;


    private void Start()
    {
        InvokeRepeating("fadeInAndOut", 1, 3);
    }

    private void fadeInAndOut()
    {
        hurtEffectBorder.gameObject.SetActive(true);
        //fadingImage.canvasRenderer.SetAlpha(0.0f);
        hurtEffectBorder.canvasRenderer.SetAlpha(0.0f);

        //fadingImage.gameObject.SetActive(true);
        hurtEffectBorder.gameObject.SetActive(true);

        //fadingImage.CrossFadeAlpha(.5f, 2, false);
        hurtEffectBorder.CrossFadeAlpha(0.5f, 2, false);
        
        //fadingImage.canvasRenderer.SetAlpha(0.5f);
        hurtEffectBorder.canvasRenderer.SetAlpha(0.5f);

        //fadingImage.CrossFadeAlpha(0f, 2, false);
        hurtEffectBorder.CrossFadeAlpha(0f, 2, false);
    }

}
