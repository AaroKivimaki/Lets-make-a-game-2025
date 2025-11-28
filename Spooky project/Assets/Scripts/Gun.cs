using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    public int gunDamage = 1;
    public float weaponRange = 50f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    public AudioSource gunAudio;
    public AudioClip clip;
    //private LineRenderer laserLine;
    public VisualEffect muzzleFLash;

    void Start()
    {
        //laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,  0.5f, 0));
            RaycastHit hit;

            //laserLine.SetPosition(0, gunEnd.position);

            muzzleFLash.Play();

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                //laserLine.SetPosition(1, hit.point);
                MonsterAI health = hit.collider.GetComponent<MonsterAI>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }
            }
            //else
            //{
            //laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            //}
        }
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.PlayOneShot(clip);
        //laserLine.enabled = true;
        yield return shotDuration;
        //laserLine.enabled = false;
    }
}
