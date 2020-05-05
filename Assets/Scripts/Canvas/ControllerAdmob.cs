using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.

public class ControllerAdmob : MonoBehaviour {
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAdAgain;
    private RewardedAd rewardedAdMoney;
    private RewardedAd rewardedAdXp;
    private float deltaTime = 0.0f;
    private static string outputMessage = string.Empty;

    [SerializeField] private Text a;

    public static Image[] borderBanner;

    public static string OutputMessage {
        set { outputMessage = value; }
    }

    private void Awake() {
        borderBanner = new Image[3];

#if UNITY_ANDROID
        string appId = "ca-app-pub-4584542733843452~1260144968";
#else
        string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
    }

    public void Update() {
        // Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
        // value.
        this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.1f;
    }

    /* #region OnGUI
    public void OnGUI() {
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        style.alignment = TextAnchor.LowerRight;
        style.fontSize = (int)(Screen.height * 0.06);
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float fps = 1.0f / this.deltaTime;
        string text = string.Format("{0:0.} fps", fps);
        GUI.Label(rect, text, style);

        // Puts some basic buttons onto the screen.
        GUI.skin.button.fontSize = (int)(0.035f * Screen.width);
        float buttonWidth = 0.35f * Screen.width;
        float buttonHeight = 0.15f * Screen.height;
        float columnOnePosition = 0.1f * Screen.width;
        float columnTwoPosition = 0.55f * Screen.width;

        Rect destroyBannerRect = new Rect(
            columnOnePosition,
            0.225f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(destroyBannerRect, "Destroy\nBanner")) {
            this.bannerView.Destroy();
        }

        Rect requestInterstitialRect = new Rect(
            columnOnePosition,
            0.4f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestInterstitialRect, "Request\nInterstitial")) {
            this.RequestInterstitial();
        }

        Rect showInterstitialRect = new Rect(
            columnOnePosition,
            0.575f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(showInterstitialRect, "Show\nInterstitial")) {
            this.ShowInterstitial();
        }

        Rect destroyInterstitialRect = new Rect(
            columnOnePosition,
            0.75f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(destroyInterstitialRect, "Destroy\nInterstitial")) {
            this.interstitial.Destroy();
        }

        Rect requestRewardedRect = new Rect(
            columnTwoPosition,
            0.05f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestRewardedRect, "Request\nRewarded Ad")) {
            this.CreateAndLoadRewardedAd();
        }

        Rect showRewardedRect = new Rect(
            columnTwoPosition,
            0.225f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(showRewardedRect, "Show\nRewarded Ad")) {
            this.ShowRewardedAd();
        }

        Rect textOutputRect = new Rect(
            columnTwoPosition,
            0.925f * Screen.height,
            buttonWidth,
            0.05f * Screen.height);
        GUI.Label(textOutputRect, outputMessage);
    }

    #endregion*/

    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest() {
        return new AdRequest.Builder()
            .AddTestDevice("8FF636E9FC9239899FE4AF91D332FA89")
            .Build();
    }

    public void RequestBanner() {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4584542733843452/2462202536";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-4584542733843452/3854534621";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null) {
            this.bannerView.Destroy();
        }      

        int height = 0;
        int heightBorderBanner = 0;
        int widthBorderBanner = 0;
        if (DisplayMetricsAndroid.AdWidth <= 400) {
            height = 32; // Altura em  DP
            heightBorderBanner = 28; // Altura em Pixel
            widthBorderBanner = 100; // Largura em Pixel
        } else if (DisplayMetricsAndroid.AdWidth > 400 && DisplayMetricsAndroid.AdWidth <= 700) {
            height = 50; // Altura em DP
            heightBorderBanner = 44; // Altura em Pixel
            widthBorderBanner = 100; // Largura em Pixel
        } else if (DisplayMetricsAndroid.AdWidth > 700) {
            height = 55; // Altura em DP
            heightBorderBanner = 50; // Altura em Pixel
            widthBorderBanner = 100; // Largura em Pixel
        }

        int asSize = (int)(DisplayMetricsAndroid.AdWidth - 200);
        AdSize adSize = new AdSize(asSize, height);

        this.bannerView = new BannerView(adUnitId, adSize, AdPosition.BottomRight);

        //Border Banner Background
        borderBanner[0].rectTransform.sizeDelta = new Vector2(asSize * DisplayMetricsAndroid.Density, height * DisplayMetricsAndroid.Density);
        borderBanner[0].rectTransform.position = new Vector2(Screen.width - (asSize * DisplayMetricsAndroid.Density) / 2, borderBanner[0].rectTransform.sizeDelta.y / 2);
        //Border Banner Toprrr
        borderBanner[2].rectTransform.sizeDelta = new Vector2(asSize * DisplayMetricsAndroid.Density, heightBorderBanner);
        borderBanner[2].rectTransform.position = new Vector2(Screen.width - ((asSize * DisplayMetricsAndroid.Density) / 2), (height * DisplayMetricsAndroid.Density) + borderBanner[2].rectTransform.sizeDelta.y / 2);
        //Border Banner Left
        borderBanner[1].rectTransform.sizeDelta = new Vector2(widthBorderBanner, (height * DisplayMetricsAndroid.Density) + borderBanner[2].rectTransform.sizeDelta.y);
        borderBanner[1].rectTransform.position = new Vector2((Screen.width - (asSize * DisplayMetricsAndroid.Density)) - widthBorderBanner / 2 + 1, borderBanner[1].rectTransform.sizeDelta.y / 2);

        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());
    }

    public void RequestInterstitial() {
         // These ad units are configured to always serve test ads.
 #if UNITY_EDITOR
         string adUnitId = "unused";
 #elif UNITY_ANDROID
         string adUnitId = "ca-app-pub-3940256099942544/1033173712";
 #else
         string adUnitId = "unexpected_platform";
 #endif

         // Clean up interstitial ad before creating a new one.
         if (this.interstitial != null) {
             this.interstitial.Destroy();
         }

         // Create an interstitial.
         this.interstitial = new InterstitialAd(adUnitId);

         // Register for ad events.
         this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
         this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
         this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
         this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
         this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

         // Load an interstitial ad.
         this.interstitial.LoadAd(this.CreateAdRequest());
     }
    
    public void ShowInterstitial() {
        if (this.interstitial.IsLoaded()) {
            this.interstitial.Show();
        } else {
            MonoBehaviour.print("Interstitial is not ready yet");
        }
    }
    
    public void CreateAndLoadRewardedAdAgain() {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Create new rewarded ad instance.
        this.rewardedAdAgain = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAdAgain.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAdAgain.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAdAgain.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAdAgain.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAdAgain.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAdAgain.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = this.CreateAdRequest();
        // Load the rewarded ad with the request.
        this.rewardedAdAgain.LoadAd(request);
    }

    public void CreateAndLoadRewardedAdMoreMoney() {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Create new rewarded ad instance.
        this.rewardedAdMoney = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAdMoney.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAdMoney.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAdMoney.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAdMoney.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAdMoney.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAdMoney.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = this.CreateAdRequest();
        // Load the rewarded ad with the request.
        this.rewardedAdMoney.LoadAd(request);
    }

    public void CreateAndLoadRewardedAdMoreEXP() {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Create new rewarded ad instance.
        this.rewardedAdXp = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAdXp.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAdXp.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAdXp.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAdXp.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAdXp.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAdXp.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = this.CreateAdRequest();
        // Load the rewarded ad with the request.
        this.rewardedAdXp.LoadAd(request);
    }

    public void ShowRewardedAdAgain() {
        if (this.rewardedAdAgain.IsLoaded()) {
            this.rewardedAdAgain.Show();
        } else {
            MonoBehaviour.print("Rewarded ad is not ready yet");
        }
    }

    public void ShowRewardedAdMoney() {
        if (this.rewardedAdMoney.IsLoaded()) {
            this.rewardedAdMoney.Show();
        } else {
            MonoBehaviour.print("Rewarded ad is not ready yet");
        }
    }

    public void ShowRewardedAdEXP() {
        if (this.rewardedAdXp.IsLoaded()) {
            this.rewardedAdXp.Show();
        } else {
            MonoBehaviour.print("Rewarded ad is not ready yet");
        }
    }

    public Image[] BorderBanner {
        set { borderBanner = value; }
    }

    public BannerView BannerView {
        get { return bannerView; }
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args) {
        //MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
        //MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args) {
        //MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args) {
        //MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args) {
       // MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args) {
        //MonoBehaviour.print("HandleInterstitialLoaded event received");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
        //MonoBehaviour.print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args) {
        //MonoBehaviour.print("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args) {
        //MonoBehaviour.print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args) {
       // MonoBehaviour.print("HandleInterstitialLeftApplication event received");
    }

    #endregion

    #region RewardedAd callback handlers

    public void HandleRewardedAdLoaded(object sender, EventArgs args) {
        //a.text = "HandleRewardedAdLoaded event received";
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args) {
        //a.text = "HandleRewardedAdFailedToLoad event received with message: " + args.Message;
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args) {
        //a.text = "HandleRewardedAdOpening event received";
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args) {
        //a.text =   "HandleRewardedAdFailedToShow event received with message: " + args.Message;
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args) {
        //MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args) {
        a.text = args.Type.ToString();

        if (args.Type == "Again") {
            ButtonsHUDFingers btnFingers = GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<ButtonsHUDFingers>();
            MoveController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>();

            btnFingers.ResetListSkillsAndDelete();
            btnFingers.CanvasGameOver = false;
            btnFingers.SetResetTime();

            btnFingers.SetActive(true);
            btnFingers.SetSkillSpritesSelected(playerController.GetListSkills());
            btnFingers.GetDropController.SimpleAttack.MoveSpeedY = 0.175f;
        } else if(args.Type == "Coins") {

        } else if(args.Type == "Exp") {

        }
    }

    #endregion
}