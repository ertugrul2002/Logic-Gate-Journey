using UnityEngine;
using UnityEngine.UI;

public class CableGridController : MonoBehaviour
{
    // مصفوفة لتخزين الأزرار من 0 إلى 15
    private Button[] bitButtons = new Button[16];
    // متغير لزر ALL 16 bit
    private Button all16BitButton;

    void Start()
    {
        // إيجاد الـ panel
        Transform panel = transform;

        // إيجاد الأزرار من 0 إلى 15
        for (int i = 0; i < 16; i++)
        {
            Transform buttonTransform = panel.Find("Button (" + i + ")");
            if (buttonTransform != null)
            {
                bitButtons[i] = buttonTransform.GetComponent<Button>();
                int bitIndex = i; // تخزين الرقم عشان نستخدمه في الـ lambda
                bitButtons[i].onClick.AddListener(() => OnBitButtonClick(bitIndex));
            }
            else
            {
                Debug.LogError("Button (" + i + ") not found!");
            }
        }

        // إيجاد زر ALL 16 bit
        Transform allButtonTransform = panel.parent.Find("Button_ALL_16bit");
        if (allButtonTransform != null)
        {
            all16BitButton = allButtonTransform.GetComponent<Button>();
            all16BitButton.onClick.AddListener(OnAll16BitButtonClick);
        }
        else
        {
            Debug.LogError("Button_ALL_16bit not found!");
        }
    }

    void OnBitButtonClick(int bitIndex)
    {
        // طباعة رسالة في الـ Console لما ينضغط زر بت معين
        Debug.Log("Button " + bitIndex + " pressed!");
    }

    void OnAll16BitButtonClick()
    {
        // طباعة رسالة في الـ Console لما ينضغط زر ALL 16 bit
        Debug.Log("ALL 16 bit button pressed!");
    }
}