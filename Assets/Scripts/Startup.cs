using BonusGameLottery;
using BonusGameMemory;
using BonusSystem;
using DailyBonus;
using PlayerWallet;
using SaveLoadSystem;
using ScreenChanger;
using UnityEngine;
using Wheel;

public class Startup : MonoBehaviour
{
    [SerializeField] private BonusView bonusView;
    [SerializeField] private BonusModel _bonusModel = new BonusModel();

    [SerializeField] private PlayerWalletView playerWalletView;
    [SerializeField] private PlayerWalletModel _playerWalletModel = new PlayerWalletModel();

    [SerializeField] private WheelView wheelView;
    [SerializeField] private WheelModel _wheelModel = new WheelModel();

    [SerializeField] private ScreenChangerModel _screenChangerModel = new ScreenChangerModel();

    [SerializeField] private BonusGameLotteryView bonusGameLotteryView;
    [SerializeField] private BonusGameLotteryModel _bonusGameLotteryModel = new BonusGameLotteryModel();

    [SerializeField] private BonusGameMemoryView bonusGameMemoryView;
    [SerializeField] private BonusGameMemoryModel _bonusGameMemoryModel = new BonusGameMemoryModel();

    [SerializeField] private DailyBonusView dailyBonusView;
    [SerializeField] private DailyBonusModel _dailyBonusModel;


    private const string _bonusModelKey = "bonus_model";
    private const string _playerWalletKey = "player_wallet_model";
    private const string _dailyBonusKey = "daily_bonus_model";
    private void Awake()
    {
        Load();

        _bonusModel.OnChange += Save;
        _playerWalletModel.OnChange += Save;
        _dailyBonusModel.OnChange += Save;
        
        
        var playerWalletPresenter = new PlayerWalletPresenter(_playerWalletModel, playerWalletView);
        var wheelPresenter = new WheelPresenter(_wheelModel, wheelView);
        var bonusShowPresenter = new BonusShowPresenter(_bonusModel, bonusView);

        var mainMenuScreenPresenter = new ScreenChangePresenter(_screenChangerModel, _screenChangerModel.mainMenu);
        var gameplayScreenPresenter = new ScreenChangePresenter(_screenChangerModel, _screenChangerModel.gameplay);
        var settingsScreenPresenter = new ScreenChangePresenter(_screenChangerModel, _screenChangerModel.settings);
        var bonusGame1ScreenPresenter = new ScreenChangePresenter(_screenChangerModel, _screenChangerModel.bonusGame1);
        var bonusGame2ScreenPresenter = new ScreenChangePresenter(_screenChangerModel, _screenChangerModel.bonusGame2);
        var dailyBonusScreenPresenter = new ScreenChangePresenter(_screenChangerModel, _screenChangerModel.dailyBonus);
        var emailPresenter = new ScreenChangePresenter(_screenChangerModel, _screenChangerModel.email);

        var bonusGameLotteryPresenter =
            new BonusGameLotteryPresenter(_bonusGameLotteryModel, _bonusModel, bonusGameLotteryView);

        var bonusGameMemoryPresenter =
            new BonusGameMemoryPresenter(_bonusGameMemoryModel, _bonusModel, bonusGameMemoryView);

        var dailyBonusPresenter = new DailyBonusPresenter(_dailyBonusModel, _bonusModel, dailyBonusView);


        wheelPresenter.Init();
        wheelPresenter.OnWinSpin += WheelPresenterOnOnWinSpin;
        _screenChangerModel.mainMenu.Show();
        playerWalletPresenter.Init();
    }

    private void WheelPresenterOnOnWinSpin(Bubble bubble)
    {
        PlayerWalletAddBubble.AddBubble(_playerWalletModel, _bonusModel, bubble);
    }

    private void Load()
    {
        var newBonusModel= LoadSystem.LoadValue<BonusModel>(_bonusModelKey);
        if (newBonusModel!=null)
        {
            _bonusModel= newBonusModel;
        }
       
        var newPlayerWalletModel= LoadSystem.LoadValue<PlayerWalletModel>(_playerWalletKey);
        if (newPlayerWalletModel!=null)
        {
            _playerWalletModel= newPlayerWalletModel;
        }
        
        var newDailyBonusModel= LoadSystem.LoadValue<DailyBonusModel>(_dailyBonusKey);
        if (newDailyBonusModel!=null)
        {
            _dailyBonusModel= newDailyBonusModel;
        }
        
    }

    private void Save()
    {
        Debug.Log("Save");
        SaveSystem.Save(_bonusModelKey,_bonusModel);
        SaveSystem.Save(_playerWalletKey,_playerWalletModel);
        SaveSystem.Save(_dailyBonusKey,_dailyBonusModel);
    }
}