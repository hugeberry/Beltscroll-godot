using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public static AudioSource audio; //사운드 조절용 컴포넌트
    public AudioClip[] sound; //오디오클립 저장 배열
    public static AudioClip[] FX; //스태틱으로 오디오클립 복제

    private void Start()
    {
        FX = new AudioClip[sound.Length]; //오디오클립과 길이 같게
        for (int i = 0; i < FX.Length; i++)
        {
            FX[i] = sound[i];
        }

        audio = GetComponent<AudioSource>();
        audio.volume = OptionData.FXVolume;
    }

    private void Update()
    {
        audio.volume = OptionData.FXVolume;
    }

    static public void ATTACK12()
    {
        audio.clip = FX[0]; //해당 클립을
        audio.PlayOneShot(audio.clip); //원샷으로 출력
    }
    static public void ATTACK3()
    {
        audio.clip = FX[1];
        audio.PlayOneShot(audio.clip);
    }
    static public void PlayerDamaged()
    {
        audio.clip = FX[2];
        audio.PlayOneShot(audio.clip);
    }
    static public void METEOR()
    {
        audio.clip = FX[3];
        audio.PlayOneShot(audio.clip);
    }

    static public void TrashDrop()
    {
        audio.clip = FX[4];
        audio.PlayOneShot(audio.clip);
    }

    static public void Heal()
    {
        audio.clip = FX[5];
        audio.PlayOneShot(audio.clip);
    }

    static public void bulletSoundSimple()
    {
        audio.clip = FX[6];
        audio.PlayOneShot(audio.clip);
    }

    static public void burgyDamage()
    {
        audio.clip = FX[7];
        audio.PlayOneShot(audio.clip);
    }

    static public void burgyDie()
    {
        audio.clip = FX[8];
        audio.PlayOneShot(audio.clip);
    }

    static public void TarreaAttack()
    {
        audio.clip = FX[9];
        audio.PlayOneShot(audio.clip);
    }

    static public void B_Summon()
    {
        audio.clip = FX[10];
        audio.PlayOneShot(audio.clip);
    }

    static public void B_Brearth()
    {
        audio.clip = FX[11];
        audio.PlayOneShot(audio.clip);
    }

    static public void TracanHit()
    {
        audio.clip = FX[12];
        audio.PlayOneShot(audio.clip);
    }

    static public void B_Charge()
    {
        audio.clip = FX[13];
        audio.PlayOneShot(audio.clip);
    }

    static public void Coin()
    {
        audio.clip = FX[14];
        audio.PlayOneShot(audio.clip);
    }

    static public void B_TrashDrop()
    {
        audio.clip = FX[15];
        audio.PlayOneShot(audio.clip);
    }

    static public void B_Attack()
    {
        audio.clip = FX[16];
        audio.PlayOneShot(audio.clip);
    }

    static public void BurgyAttack()
    {
        audio.clip = FX[17];
        audio.PlayOneShot(audio.clip);
    }

    static public void TarrteaDamage()
    {
        audio.clip = FX[18];
        audio.PlayOneShot(audio.clip);
    }

    static public void B_Damage()
    {
        audio.clip = FX[19];
        audio.PlayOneShot(audio.clip);
    }
    static public void TarrteaDie()
    {
        audio.clip = FX[20];
        audio.PlayOneShot(audio.clip);
    }

    static public void TracanRoll()
    {
        audio.clip = FX[21];
        audio.PlayOneShot(audio.clip);
    }

    static public void B_Death()
    {
        audio.clip = FX[22];
        audio.PlayOneShot(audio.clip);
    }

    static public void TracanDie()
    {
        audio.clip = FX[23];
        audio.PlayOneShot(audio.clip);
    }

    static public void Wave()
    {
        audio.clip = FX[24];
        audio.PlayOneShot(audio.clip);
    }

    static public void MeteorStart()
    {
        audio.clip = FX[25];
        audio.PlayOneShot(audio.clip);
    }

    static public void PlayerAttackMiss()
    {
        audio.clip = FX[26];
        audio.PlayOneShot(audio.clip);
    }

    static public void Land()
    {
        audio.clip = FX[27];
        audio.PlayOneShot(audio.clip);
    }

    static public void Jump()
    {
        audio.clip = FX[28];
        audio.PlayOneShot(audio.clip);
    }
    static public void MeteorEx()
    {
        audio.clip = FX[29];
        audio.PlayOneShot(audio.clip);
    }

    static public void Laser()
    {
        audio.clip = FX[30];
        audio.PlayOneShot(audio.clip);
    }

    static public void LightningSound()
    {
        audio.clip = FX[31];
        audio.PlayOneShot(audio.clip);
    }

    static public void ThrowItemSound()
    {
        audio.clip = FX[32];
        audio.PlayOneShot(audio.clip);
    }

    static public void DropItemSound()
    {
        audio.clip = FX[33];
        audio.PlayOneShot(audio.clip);
    }
}
