using UnityEngine;
using System.Collections;
public class Laser : MonoBehaviour
{
    public Color corLaser = Color.green;
    public int DistanciaDoLaser = 100;
    public float LarguraInicial = 0.2f, LarguraFinal = 0.1f;
    public float fireRate = 3f;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.8f);
    public Material material;
    private GameObject luzColisao;
    private Vector3 posicLuz;
    private bool ligado;
    private float nextFire;
    private AudioSource laserAudio;

    void Start()
    {
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        luzColisao.GetComponent<Light>().intensity = 8;
        luzColisao.GetComponent<Light>().bounceIntensity = 8;
        luzColisao.GetComponent<Light>().range = LarguraFinal * 2;
        luzColisao.GetComponent<Light>().color = corLaser;
        posicLuz = new Vector3(0, 0, LarguraFinal);
        //
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        laserAudio = GetComponent<AudioSource>();
        lineRenderer.material = new Material(material);
        lineRenderer.SetColors(corLaser, corLaser);
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
        lineRenderer.SetVertexCount(2);
    }
    void Update()
    {
        if (ligado == true)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            luzColisao.SetActive(true);
            Vector3 PontoFinalDoLaser = transform.position + transform.right * DistanciaDoLaser;
            RaycastHit PontoDeColisao;
            if (Physics.Raycast(transform.position, transform.right, out PontoDeColisao, DistanciaDoLaser))
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, PontoDeColisao.point);
                luzColisao.transform.position = (PontoDeColisao.point - posicLuz);
            }
            else
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, PontoFinalDoLaser);
                luzColisao.transform.position = PontoFinalDoLaser;
            }
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
            luzColisao.SetActive(false);
        }
        if (Input.GetKey(KeyCode.I) && Time.time > nextFire)
        {
                       
            ligado = !ligado;
        }


      IEnumerator ShotEffect()
        {
            laserAudio.Play();
            ligado= true;
            yield return shotDuration;
            ligado = false;
            
                }


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {

                Destroy(this.gameObject, 0.1f);
            }

            if (other.gameObject.tag == "Boss1")
            {

                Destroy(this.gameObject, 0.1f);
            }

            if (other.gameObject.tag == "Boss2")
            {

                Destroy(this.gameObject, 0.1f);
            }

        }
    }

}
