using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    public string myID;
    public static int HealthPoint, ManaPoint, AttackPoint, DfancePoint, IntegerPoint, DropCoin;//피통, 마나통, 공, 수, 마, 돈
    public static int MHP, MMP, AK, IN, DF, CO = 0;
    void Start()
    {
        LoadData();
    }
    public void LoadData()
    {
        var request = new GetUserDataRequest() { PlayFabId = myID };
        PlayFabClientAPI.GetUserData(request, (result) => PlayerTotalData.star = result.Data["Stage"].Value, (error) => print("데이터 불러오기 실패"));
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    switch (eachStat.StatisticName)
                    {
                        case "MaxHP": HealthPoint = eachStat.Value; break;
                        case "MaxMP": ManaPoint = eachStat.Value; break;
                        case "ATK": AttackPoint = eachStat.Value; break;
                        case "DEF": DfancePoint = eachStat.Value; break;
                        case "INT": IntegerPoint = eachStat.Value; break;
                        case "Coin": DropCoin = eachStat.Value; break;
                    }
                MHP = 150 + HealthPoint;
                MMP = 100 + ManaPoint;
                AK = 7 + AttackPoint;
                DF = 0 + DfancePoint;
                IN = 5 + IntegerPoint;
                DBStatus.ReData();
                HaveCoin.Coin = CO;
            },
            (error) => { print("실패!"); });
    }
}