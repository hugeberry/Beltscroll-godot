using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayerTotalData : MonoBehaviour
{
    public string myID;
    public static int HealthPoint, ManaPoint, AttackPoint, DfancePoint, IntegerPoint, DropCoin;//피통, 마나통, 공, 수, 마, 돈
    public static string star;//스테이지 값 저장

    public static int MHP, MMP, AK, IN, DF, CO = 0;
    private int NHP = 150;
    private int NMP = 100;
    private int NAK = 7;
    private int NIN = 5;
    private int NDF = 0;
    public static int DMain, DSub, DArmor = -1;

    public GameObject Re;


    public void RePan()
    {
        StartCoroutine("RePanel");
    }
    IEnumerator RePanel()
    {
        yield return new WaitForSeconds(0.3f);
        Re.SetActive(true);
    }
    
    public void nextPage()
    {
        if (PlayerTotalData.star == "Stage1")
        {
            SetDataOne();
        }
        if (PlayerTotalData.star == "Stage2")
        {
            SetDataTwo();
        }
        if (PlayerTotalData.star == "Stage3")
        {
            SetDataThree();
        }
    }
    public void nextBuyPage()
    {
        if (PlayerTotalData.star == "Stage1")
        {
            SetDataOne();
            SetOne();
        }
        if (PlayerTotalData.star == "Stage2")
        {
            SetDataTwo();
            SetTwo();
        }
        if (PlayerTotalData.star == "Stage3")
        {
            SetThree();
            SetDataThree();
        }
    }
    public void NewDataLoad()
    {
        MHP = 150;
        MMP = 100;
        AK = 7;
        IN = 5;
        DF = 0;
        CO = HaveCoin.Coin;
        DMain = 0;
        DSub = -1;
        DArmor = -1;
    }
    public static void GetData()
    {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, (result) => star = result.Data["Stage"].Value, (error) => print("데이터 불러오기 실패"));
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    switch (eachStat.StatisticName)
                    {
                        case "MaxHP": MHP = eachStat.Value; break;
                        case "MaxMP": MMP = eachStat.Value; break;
                        case "ATK": AK = eachStat.Value; break;
                        case "DEF": DF = eachStat.Value; break;
                        case "INT": IN = eachStat.Value; break;
                        case "Coin": CO = eachStat.Value; break;
                        case "Main": DMain = eachStat.Value; break;
                        case "Sub": DSub = eachStat.Value; break;
                        case "Armor": DArmor = eachStat.Value; break;
                        case "gogo": PlayFabManager.NL = eachStat.Value; break;
                    }
                DBStatus.ReData();
                HaveCoin.Coin = CO;
            },
            (error) => { print("값 저장됨"); });
    }

    public void NewData()
    {
        var request = new UpdateUserDataRequest() { Data = new Dictionary<string, string>() { { "Stage", "Stage1" } } };
        PlayFabClientAPI.UpdateUserData(request, (result) => print("데이터 저장 성공"), (error) => print("데이터 저장 실패"));

        PlayerStatus save = new PlayerStatus();
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "MaxHP", Value = 150},
                new StatisticUpdate {StatisticName = "MaxMP", Value = 100},
                new StatisticUpdate {StatisticName = "ATK", Value = 7},
                new StatisticUpdate {StatisticName = "DEF", Value = 0},
                new StatisticUpdate {StatisticName = "INT", Value = 5},
                new StatisticUpdate {StatisticName = "Coin", Value = 0},
                new StatisticUpdate {StatisticName = "Main", Value = 0},
                new StatisticUpdate {StatisticName = "Sub", Value = -1},
                new StatisticUpdate {StatisticName = "Armor", Value = -1},
                new StatisticUpdate {StatisticName = "gogo", Value = 0},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
    }

    public void LoadData()
    {
        var request = new GetUserDataRequest() { PlayFabId = myID };
        PlayFabClientAPI.GetUserData(request, (result) => star = result.Data["Stage"].Value, (error) => print("데이터 불러오기 실패"));
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    switch (eachStat.StatisticName)
                    {
                        case "MaxHP": MHP = eachStat.Value; break;
                        case "MaxMP": MMP = eachStat.Value; break;
                        case "ATK": AK = eachStat.Value; break;
                        case "DEF": DF = eachStat.Value; break;
                        case "INT": IN = eachStat.Value; break;
                        case "Coin": CO = eachStat.Value; break;
                        case "Main": DMain = eachStat.Value; break;
                        case "Sub": DSub = eachStat.Value; break;
                        case "Armor": DArmor = eachStat.Value; break;
                    }
                DBStatus.ReData();
                HaveCoin.Coin = CO;
            },
            (error) => { print("실패!"); });
    }

    public void StageLoad()
    {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, (result) => star = result.Data["Stage"].Value, (error) => print("데이터 불러오기 실패"));
    }

    public void SetDataOne()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "MaxHP", Value = PlayerStatus.MaxHP},
                new StatisticUpdate {StatisticName = "MaxMP", Value = PlayerStatus.MaxMP},
                new StatisticUpdate {StatisticName = "ATK", Value = PlayerStatus.ATK},
                new StatisticUpdate {StatisticName = "DEF", Value = PlayerStatus.DEF},
                new StatisticUpdate {StatisticName = "INT", Value = PlayerStatus.INT},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
    }
    public void SetOne()
    {
        var request = new UpdateUserDataRequest() { Data = new Dictionary<string, string>() { { "Stage", "Stage2" } } };
        PlayFabClientAPI.UpdateUserData(request, (result) => print("데이터 저장 성공"), (error) => print("데이터 저장 실패"));
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "Coin", Value = HaveCoin.Coin},
                new StatisticUpdate {StatisticName = "Main", Value = WeaponArray.SaveDBWeapon()},
                new StatisticUpdate {StatisticName = "Sub", Value = SubWeaponArray.SaveDBSubWeapon()},
                new StatisticUpdate {StatisticName = "Armor", Value = ArmorManager.NowDBArmor()},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
        HealthPoint = 0;
        ManaPoint = 0;
        AttackPoint = 0;
        IntegerPoint = 0;
        DfancePoint = 0;
    }
    public void SetDataTwo()
    {
        MHP = 150;
        MMP = 100;
        AK = 7;
        IN = 5;
        DF = 0;
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "MaxHP", Value = PlayerStatus.MaxHP},
                new StatisticUpdate {StatisticName = "MaxMP", Value = PlayerStatus.MaxMP},
                new StatisticUpdate {StatisticName = "ATK", Value = PlayerStatus.ATK},
                new StatisticUpdate {StatisticName = "DEF", Value = PlayerStatus.DEF},
                new StatisticUpdate {StatisticName = "INT", Value = PlayerStatus.INT},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
    }
    public void SetTwo()
    {
        var request = new UpdateUserDataRequest() { Data = new Dictionary<string, string>() { { "Stage", "Stage3" } } };
        PlayFabClientAPI.UpdateUserData(request, (result) => print("데이터 저장 성공"), (error) => print("데이터 저장 실패"));

        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "Coin", Value = HaveCoin.Coin},
                new StatisticUpdate {StatisticName = "Main", Value = WeaponArray.SaveDBWeapon()},
                new StatisticUpdate {StatisticName = "Sub", Value = SubWeaponArray.SaveDBSubWeapon()},
                new StatisticUpdate {StatisticName = "Armor", Value = ArmorManager.NowDBArmor()},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
        HealthPoint = 0;
        ManaPoint = 0;
        AttackPoint = 0;
        IntegerPoint = 0;
        DfancePoint = 0;
    }
    public void SetDataThree()
    {
        MHP = 150;
        MMP = 100;
        AK = 7;
        IN = 5;
        DF = 0;
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "MaxHP", Value = PlayerStatus.MaxHP},
                new StatisticUpdate {StatisticName = "MaxMP", Value = PlayerStatus.MaxMP},
                new StatisticUpdate {StatisticName = "ATK", Value = PlayerStatus.ATK},
                new StatisticUpdate {StatisticName = "DEF", Value = PlayerStatus.DEF},
                new StatisticUpdate {StatisticName = "INT", Value = PlayerStatus.INT},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
    }
    public void SetThree()
    {
        var request = new UpdateUserDataRequest() { Data = new Dictionary<string, string>() { { "Stage", "Stage1" } } };
        PlayFabClientAPI.UpdateUserData(request, (result) => print("데이터 저장 성공"), (error) => print("데이터 저장 실패"));
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "Coin", Value = HaveCoin.Coin},
                new StatisticUpdate {StatisticName = "Main", Value = WeaponArray.SaveDBWeapon()},
                new StatisticUpdate {StatisticName = "Sub", Value = SubWeaponArray.SaveDBSubWeapon()},
                new StatisticUpdate {StatisticName = "Armor", Value = ArmorManager.NowDBArmor()},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
        HealthPoint = 0;
        ManaPoint = 0;
        AttackPoint = 0;
        IntegerPoint = 0;
        DfancePoint = 0;
    }
}
