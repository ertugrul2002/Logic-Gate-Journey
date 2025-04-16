using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class ButtonController16bit : MonoBehaviour
{
    public  ConnectorType Name;
    public GameObject bitSelectionPanel;
    public Vector3 panelOffset = new Vector3(100f, 0f, 0f);
    [SerializeField] public List<Cable16bitTruthTable> truthTable = new List<Cable16bitTruthTable>(){};
    [SerializeField] public Button AddButton;
    [SerializeField] private GameObject prefabToSpawnCable;
    private List<ButtonController> spawnedCables = new List<ButtonController>(new ButtonController[10]){};
    [SerializeField] private List<GameObject> bitButtons = new List<GameObject>(){};
    private int index=0;
    
    
    void Start()
    {
        
        bitSelectionPanel.SetActive(false);
        for (int i=1;i<bitButtons.Count;i++)
        {
            if (bitButtons[i] != null)
            {
                bitButtons[i].SetActive(false);
            }
            else
            {
                Debug.Log($"the button in index {i} dose not exist");
            }
        }
        AddButton.onClick.AddListener(AddButtonListener);
    }

    public List<Cable16bitTruthTable> GetTruthTable()
    {
        return truthTable;
    }

    public void SetTruthTable(List<Cable16bitTruthTable> newTruthTable)
    {

        truthTable.Clear();
        foreach (var item in newTruthTable)
        {
            truthTable.Add(new Cable16bitTruthTable(new List<bool>(item.truthTable))); 
        }

    }

    void ShowBitSelectionUI()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        bitSelectionPanel.SetActive(true);
        bitSelectionPanel.transform.position = screenPos + panelOffset;
    }

    public void Creat_A_Cable(int bitIndex)
    {
        if (spawnedCables[bitIndex] != null)
        {
            Debug.Log($"i have a cable on {bitIndex} button");
            ButtonController existingCable = spawnedCables[bitIndex];
            bitSelectionPanel.SetActive(false);
            existingCable.ShowBitSelectionUI();

            // Debug.Log("dragging");
        }
        else
        {
            if (prefabToSpawnCable != null)
            {
                
                GameObject newCable = Instantiate(prefabToSpawnCable, transform.position, transform.rotation, transform);
                newCable.transform.localScale = transform.localScale;
                
                if (newCable != null)
                {
                    ButtonController cableScript = newCable.GetComponent<ButtonController>();
                    if (cableScript != null)
                    {
                        spawnedCables[bitIndex] = cableScript;
                        cableScript.SetTruthTable(truthTable);
                        Debug.Log($"sameh16 {spawnedCables[bitIndex] == null}");
                        bitSelectionPanel.SetActive(false);
                        cableScript.ShowBitSelectionUI();
                    }
                    else
                    {
                        Debug.LogError("i did not find a cable1");
                    }
                }
                else
                {
                    Debug.LogError("i cant find a script of cable");
                }
            }
        }
        bitSelectionPanel.SetActive(false);
    }

    public void AddButtonListener()
    {
        Debug.Log("Selected add button");
        if(index <10)
        {
            index++;
            bitButtons[index].SetActive(true);
        } 
        if(index == 10)
        {
            AddButton.interactable = false;
        }
        else
        {
           Debug.Log("you can not add button any more"); 
        } 
        
    }

    public void OnBitSelected(int bitIndex)
    {
        Debug.Log($"Selected  button {bitIndex}");
        Creat_A_Cable(bitIndex);
    }

    void OnMouseDown()
    {
        ShowBitSelectionUI();
    }

    void Update()
    {
        
        if (bitSelectionPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F) && bitButtons[0] != null && bitButtons[0].GetComponent<Button>().interactable && bitButtons[0].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && bitButtons[1] != null && bitButtons[1].GetComponent<Button>().interactable && bitButtons[1].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && bitButtons[2] != null && bitButtons[2].GetComponent<Button>().interactable && bitButtons[2].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && bitButtons[3] != null && bitButtons[3].GetComponent<Button>().interactable && bitButtons[3].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && bitButtons[4] != null && bitButtons[4].GetComponent<Button>().interactable && bitButtons[4].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && bitButtons[5] != null && bitButtons[5].GetComponent<Button>().interactable && bitButtons[5].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6) && bitButtons[6] != null && bitButtons[6].GetComponent<Button>().interactable && bitButtons[6].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(6);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7) && bitButtons[7] != null && bitButtons[7].GetComponent<Button>().interactable && bitButtons[7].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(7);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8) && bitButtons[8] != null && bitButtons[8].GetComponent<Button>().interactable && bitButtons[8].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(8);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha9) && bitButtons[9] != null && bitButtons[9].GetComponent<Button>().interactable && bitButtons[9].activeSelf)
            {
                bitSelectionPanel.SetActive(false);
                OnBitSelected(9);
            }
            
            else if (Input.GetKeyDown(KeyCode.F) && AddButton != null && AddButton.interactable)
            {
                AddButton.onClick.Invoke();
            }
        }



    }

}
