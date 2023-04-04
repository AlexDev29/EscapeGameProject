using UnityEngine;

public class EnigmeCreation : MonoBehaviour
{

    [SerializeField] EnigmeObject enigme;   //Indique au slot manager qu'il peut activer les fonctionnalité d'utilisation de l'inventaire

    [SerializeField] GameObject inventoryCanva;
    [SerializeField] GameManagement enigmeManagement;
    [SerializeField] SlotManagement slotManager;

    GameObject panel;
    bool isCreate = false;
    bool dialoguePlayed = false;   //faire un evenement qui detecte quand dialogue = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        inventoryCanva.SetActive(true);
        slotManager.isInEnigme = true;

        GameManagement.instance.StartDialogue(enigme.dialogue);

        if (GameManagement.instance.dialogueEnded && !isCreate)
        {
            panel = Instantiate(enigme.enigmeUI, GameObject.Find("Canvas").transform);
            InverserUI(panel.transform, inventoryCanva.transform);
            enigmeManagement.LauchEnigme(enigme.ID);
            isCreate = true;

            panel.SetActive(true);
            slotManager.FindNewSlot();  //Liste les slot de l'énigme
        }

    }


    //Inverse le canva de l'enigme avec celui de l'inventaire dans la hiérarchie (bug de layer)
    private void InverserUI(Transform transform1, Transform transform2)    
    {
        int siblingIndex1 = transform1.GetSiblingIndex();
        int siblingIndex2 = transform2.GetSiblingIndex();

        transform1.SetSiblingIndex(siblingIndex2);
        transform2.SetSiblingIndex(siblingIndex1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
        inventoryCanva.SetActive(false);
        slotManager.isInEnigme = false;
    }
}
