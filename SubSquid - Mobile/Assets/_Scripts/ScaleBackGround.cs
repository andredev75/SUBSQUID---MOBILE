using UnityEngine;
using UnityEngine.UI;

namespace Mushroom_Angels_Games
{
    /**
   * @author Luiz Marian
   * @version 1.0
   * @Site https://www.mushroomangelsgames.com/
   * @Youtube https://www.youtube.com/channel/UCOY8F_82Rg6LDDR3SnzSuMQ
   * OBRIGADO - SE INSCREVA NO CANAL E ACOMPANHE OS JOGOS */

    [ExecuteInEditMode]
    public class ScaleBackGround : MonoBehaviour
    {
        #region VARIABLES
        [SerializeField] private float WidthAdpatation = 0.5625f;

        private float screenWidth;
        private float screenHeight;

        private CanvasScaler CanvasScaler;
        #endregion

        #region LOGIC
        //TO ATRIBUTE DATA
        private void Awake() => Init();

        //VOID UPDATE - CALCULATE NEW SCREEN SIZE!!
        void Update()
        {
            GetScreenCurrectSize();
            transform.localScale = new Vector3((WidthAdpatation * screenWidth / screenHeight), transform.localScale.y, transform.localScale.z);
        }

        //SETTIGS START
        void Init()
        {
            CanvasScaler = transform.GetComponentInParent<CanvasScaler>();
            CanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            CanvasScaler.referenceResolution = new Vector2(1920, 1080);
            CanvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            CanvasScaler.matchWidthOrHeight = 1;
            CanvasScaler.referencePixelsPerUnit = 100;
        }

        //GET CURRECT VALUES TO SCREEN
        void GetScreenCurrectSize()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }
        #endregion
    }

}


