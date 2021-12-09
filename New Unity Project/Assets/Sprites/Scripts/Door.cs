using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Door : Interactable
{
    public AudioClipGroop DoorOpenAudio;
    public AudioClipGroop DoorCloseAuido;
    public Animator animator;
    public TextMeshProUGUI interactionText;
    private bool IsOpen = false;
    public TextMeshProUGUI DialogText;
    public Canvas DialogGUI;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI AnswerText;

    private bool talking;
    public bool cantalk = true;
    public override void OnFocus()
    {
        interactionText.text = "E et katsuda";
    }

    public override void OnInteract(int encouter)
    {
        

        if (IsOpen)
        {
            talking = false;
            IsOpen = false;
            DoorOpenAudio.Play();
            animator.SetBool("isOpen", IsOpen);
            DialogGUI.gameObject.SetActive(false);
        }
        else
        {
            //avamine
            talking = true;
            IsOpen = true;
            if(cantalk == true)
            {
                DialogGUI.gameObject.SetActive(true);
                Talk(encouter);
                
            }
            
            DoorCloseAuido.Play();
            animator.SetBool("isOpen", IsOpen);
        }

    }
    
    private void Talk(int encounter)
    {
        if(encounter == 1)
        {
            Name.text = "Omanik Tamm";
            DialogText.text = "Tere, 30 p�eva lepingu l�petamise teatamisest on m��das. Kuna sa v�lja kolid?\n";
            AnswerText.text = "\n[1]kohe, t�na! \n\n[2]mm, ma homme hakkan pakkima \n \n[3]ja, jah, ahah, juba 30 p�eva, no selge. Eee, jah�";
        }
        if(encounter == 2)
        {
            Name.text = "Omanik Tamm";
            DialogText.text = "Palun hakake mu korterist v�lja kolima!";
            AnswerText.text = "[1]juba hakkasin, rahune maha! \n[2]kolimine? kuhu te kolite? aa, mina? ma ei saa t�na alustada kolimist, pean kuu l�ppu ootama\n[3]kolitud, pesen veel p�randad �le!";
        }
        if(encounter == 3)
        {
            Name.text = "Poeg Urmo";
            DialogText.text = "Olen omanik Tamme poeg, tee uks lahti r��gime.";
            AnswerText.text = "[1]vabandust, ma ei saa hetkel, teen t��d \n[2]ma ei julge, ma ei tea, kes te olete\n[3]mul on k�ht lahti, sa ei taha et ma ukse lahti teeksin";

        }
        if(encounter == 4)
        {
            Name.text = "Omanik Tamm";
            DialogText.text = "Nii ei saa enam! Palun koli v�lja.";
            AnswerText.text = "[1]mul l�heb kolimisega aega, pean emale raha saatma sest ta haige \n[2]ma ei ole endale veel elukohta leidnud\n[3]Noo, natuke saab ikka veel nii. Varsti kohe kolin jaa...";

        }
        if(encounter == 41)
        {
            Name.text = "Omanik Tamm";
            DialogText.text = "ma v�in sulle kolimiseks raha anda, et sa homme v�lja koliksid!";
            AnswerText.text = "suur ait�h!\n\n PALUN VAJUTA NUUD [1]";
        }
        if (encounter == 42)
        {
            Name.text = "Omanik Tamm";
            DialogText.text = "see ei ole minu probleem ju!";
            AnswerText.text = "jah, n��d on see meie probleem.";
        }
        if (encounter == 43)
        {
            Name.text = "Omanik Tamm";
            DialogText.text = "EI SAA ENAM";
            AnswerText.text = "VAJUTA [1] PALUN EI J�UA ENAM PROGEDA!";
        }




    }

    public override void OnLoseFocus()
    {
        interactionText.text = "";
    }
}