using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    ///--------------PostProcess
    PostProcessVolume m_Volume;
    ///////////////////////////////

    ///--------------Sound
    AudioSource sound_eff;
    ///////////////////////////////

    ///--------------away
    bool away_time_run = false;
    float away_time = 0;
    int waiting_time = 2;
    ///////////////////////////////

    ///--------------one_talk
    bool one_time_run = false;
    float one_time = 0;
    int one_waiting_time = 6;
    bool check = true;
    ///////////////////////////////

    ///--------------die
    bool die_time_run = false;
    float die_time = 0;
    int die_waiting_time = 3;
    bool check2 = true;
    ///////////////////////////////

    bool post_event = false;
    bool post_on_off = false;
    bool post_on_off2 = false;

    ///--------------wow
    bool w_time_run = false;
    float w_time = 0;
    int w_waiting_time = 2;
    bool check3 = true;
    ///////////////////////////////

    bool message_on_off = true;

    ///--------------four
    bool f_time_run = false;
    float f_time = 0;
    int f_waiting_time = 4;
    bool check4 = true;
    ///////////////////////////////

    ///--------------last
    bool l_time_run = false;
    float l_time = 0;
    int l_waiting_time = 5;
    bool check5 = true;
    ///////////////////////////////

    bool controll_on = false;

    void Start()
    {
        ///--------------PostProcess
        m_Volume = GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").GetComponent<PostProcessVolume>();
        ///////////////////////////////

        ///--------------Sound
        sound_eff = GameObject.Find("FPSController").transform.Find("sound").GetComponent<AudioSource>();
        ///////////////////////////////



    }

    void Update()
    {
        ///--------------away 삭제
        if (away_time_run == true)
        {
            away_time += Time.deltaTime;
        }
        if (away_time > waiting_time)
        {
            //Action
            GameObject.Find("Canvas").transform.Find("away").gameObject.SetActive(false);
            away_time = 0;
        }
        ///////////////////////////////

        ///--------------one_talk 삭제
        if (one_time_run == true)
        {
            one_time += Time.deltaTime;
        }
        if (one_time > one_waiting_time)
        {
            //Action
            GameObject.Find("Canvas").transform.Find("message0").gameObject.SetActive(false);
            check = false;
            one_time = 0;
        }
        ///////////////////////////////

        ///--------------die 삭제
        if (die_time_run == true)
        {
            die_time += Time.deltaTime;
        }
        if (die_time > die_waiting_time)
        {
            //Action
            GameObject.Find("Canvas").transform.Find("message1").gameObject.SetActive(false);
            post_event = true; // 포스트 프로세싱 시작.
            check2 = false;
            die_time = 0;
        }
        ///////////////////////////////



        //////--------------포스트 프로세싱 시작
        if (post_event == true)
        {
            //--ChromaticAberration
            if (m_Volume.profile.HasSettings<ChromaticAberration>() == false)
            {
                m_Volume.profile.AddSettings<ChromaticAberration>();
            }
            // 있을때만

            if (m_Volume.profile.HasSettings<ChromaticAberration>() == true)
            {
                m_Volume.profile.GetSetting<ChromaticAberration>().intensity.value = 0.312f;

            }
            //////////////////////////

            //--LensDistortion
            if (m_Volume.profile.HasSettings<LensDistortion>() == false)
            {
                m_Volume.profile.AddSettings<LensDistortion>();
            }
            // 있을때만

            if (m_Volume.profile.HasSettings<LensDistortion>() == true)
            {
                m_Volume.profile.GetSetting<LensDistortion>().intensity.value = 40;

            }
            //////////////////////////

            //--ColorGrading
            if (m_Volume.profile.HasSettings<ColorGrading>() == false)
            {
                m_Volume.profile.AddSettings<ColorGrading>();
            }
            // 있을때만

            if (m_Volume.profile.HasSettings<ColorGrading>() == true)
            {
                m_Volume.profile.GetSetting<ColorGrading>().mixerRedOutRedIn.value = 200;
                m_Volume.profile.GetSetting<ColorGrading>().mixerRedOutGreenIn.value = 88;
                m_Volume.profile.GetSetting<ColorGrading>().mixerRedOutBlueIn.value = -144;

            }
            //////////////////////////


            m_Volume.profile.GetSetting<ChromaticAberration>().intensity.overrideState = true;
            m_Volume.profile.GetSetting<LensDistortion>().intensity.overrideState = true;
            m_Volume.profile.GetSetting<ColorGrading>().SetAllOverridesTo(true);


            //--메세지
            GameObject.Find("Canvas").transform.Find("message2").gameObject.SetActive(true);
            //--사운드
            sound_eff.enabled = true;
            //--사운드 꺼지고 메세지 꺼지기
            if ((sound_eff.enabled = true) && (sound_eff.isPlaying == false) && (check3 = true))
            {

                GameObject.Find("Canvas").transform.Find("message2").gameObject.SetActive(false);
                if (message_on_off == true)
                {
                    GameObject.Find("Canvas").transform.Find("message3").gameObject.SetActive(true);

                }
                //잠깐 포스트 프로세싱 끄기
                if (post_on_off == false)
                {
                    m_Volume.profile.GetSetting<ChromaticAberration>().intensity.overrideState = false;
                    m_Volume.profile.GetSetting<LensDistortion>().intensity.overrideState = false;
                    m_Volume.profile.GetSetting<ColorGrading>().SetAllOverridesTo(false);
                    //타이머 시작
                    w_time_run = true;
                }
            }
        }
        ///////////////////////////////

        ///--------------wow 삭제 + 생성 + 포스트 프로세싱
        if (w_time_run == true)
        {
            w_time += Time.deltaTime;
        }
        if (w_time > w_waiting_time)
        {

            //Action
            message_on_off = false;
            GameObject.Find("Canvas").transform.Find("message3").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("message4").gameObject.SetActive(true);
            post_on_off = true;

            //Debug.Log("test");
            check3 = false;
            f_time_run = true; // 타이머 시작.
            w_time = 0;
            w_time_run = false;
        }
        ///////////////////////////////

        ///--------------four 삭제
        if (f_time_run == true)
        {
            w_time = 0;
            f_time += Time.deltaTime;
        }
        if (f_time > f_waiting_time)
        {

            GameObject.Find("Canvas").transform.Find("message4").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("message5").gameObject.SetActive(true);
            post_on_off = false;
            check4 = false;
            f_time = 0;
            l_time_run = true;
        }
        ///////////////////////////////

        ///--------------last 삭제
        if (l_time_run == true)
        {
            f_time = 0;
            l_time += Time.deltaTime;
        }
        if (l_time > l_waiting_time)
        {
            GameObject.Find("Canvas").transform.Find("message5").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("final").gameObject.SetActive(true);
            GameObject.Find("last_event").transform.Find("event_collider3").gameObject.SetActive(true);
            controll_on = true;
            check5 = false;
            l_time = 0;
        }


        ///////-------controll_on
        if (controll_on == true)
        {
            if (post_on_off == false)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    post_on_off = true;
                    GameObject.Find("last_event").transform.Find("step").gameObject.SetActive(true);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    post_on_off = false;
                    GameObject.Find("last_event").transform.Find("step").gameObject.SetActive(false);
                }
            }
        }
        ///////////////////////////////
    }



    //충돌
    void OnTriggerEnter(Collider other)
    {
        ///--------------wall 생성 
        if (other.gameObject.CompareTag("wall")) //차단막 메세지
        {
            GameObject.Find("Canvas").transform.Find("away").gameObject.SetActive(true);
            away_time = 0;
            away_time_run = true;

        }

        ///--------------away 생성 
        if (other.gameObject.CompareTag("away")) //화재 차단막 메세지
        {
            GameObject.Find("Canvas").transform.Find("away").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("message0").gameObject.SetActive(false);
            away_time = 0;
            away_time_run = true;

        }
        ///////////////////////////////

        ///--------------one_talk 생성
        if (check == true) {
            if (other.gameObject.CompareTag("one_talk")) //화재 차단막 메세지
            {
                GameObject.Find("Canvas").transform.Find("away").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("message0").gameObject.SetActive(true);

                one_time_run = true;

            }
        }
        ///////////////////////////////

        //////--------------die 생성
        if (check2 == true)
        {
            if (other.gameObject.CompareTag("die")) //화재 차단막 메세지
            {
                GameObject.Find("Canvas").transform.Find("message1").gameObject.SetActive(true);
                die_time_run = true;
            }
        }
        ///////////////////////////////

        /////---------------휴대폰소리 생성
        if (other.gameObject.CompareTag("sound"))
        {
            GameObject.Find("last_event").transform.Find("phone").gameObject.SetActive(true);
            GameObject.Find("last_event").transform.Find("event_collider4").gameObject.SetActive(true);
        }
        ///////////////////////////////

        /////---------------기차사망씬
        if (other.gameObject.CompareTag("train_die"))
        {
            //카메라 워킹
            GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").gameObject.SetActive(false);
            GameObject.Find("last_event").transform.Find("Camera").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("focus").gameObject.SetActive(false);
            GameObject.Find("last_event").transform.Find("train").gameObject.SetActive(true);

            Debug.Log("end");
        }
        ///////////////////////////////
        ///
        /////---------------기차사망씬
        if (other.gameObject.CompareTag("train"))
        {
            //다음씬으로
            SceneManager.LoadScene("ending");
        }

            // 끄기 테스트
            /*
            if (other.gameObject.CompareTag("post") && m_Volume.profile.HasSettings<ChromaticAberration>())
            {
                m_Volume.profile.RemoveSettings<ChromaticAberration>();
                Debug.Log("pp");
            }*/

            /*
            // 켜기 테스트
            if (other.gameObject.CompareTag("post") && (m_Volume.profile.HasSettings<ChromaticAberration>() == false))
            {
                m_Volume.profile.AddSettings<ChromaticAberration>();
                Debug.Log("pp");
            }
            // 있을때만
            if (m_Volume.profile.HasSettings<ChromaticAberration>() == true)
            {
                m_Volume.profile.GetSetting<ChromaticAberration>().intensity.value = 0.725f;
                m_Volume.profile.GetSetting<ChromaticAberration>().intensity.overrideState = true;
            }*/
        }
}
