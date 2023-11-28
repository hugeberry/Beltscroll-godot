using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class ResetData : MonoBehaviour
{
    public string myID;
    public static int HealthPoint, AttackPoint, DfancePoint, IntegerPoint;
    public int xX, yY = 0;
    public Text LogText;

    public void SetData()
    {
        Status save = new Status();
        HealthPoint = save.Hp;
        AttackPoint = save.Ap;
        DfancePoint = save.Df;
        IntegerPoint = save.In;
        save.x = (int)transform.position.x;
        save.y = (int)transform.position.y;

        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate {StatisticName = "Hp", Value = HealthPoint},
                new StatisticUpdate {StatisticName = "Ap", Value = AttackPoint},
                new StatisticUpdate {StatisticName = "Df", Value = DfancePoint},
                new StatisticUpdate {StatisticName = "In", Value = IntegerPoint},
                new StatisticUpdate {StatisticName = "x좌표", Value = save.x},
                new StatisticUpdate {StatisticName = "y좌표", Value = save.y},
            }
        }, (result) => { print("값 저장됨"); },
        (error) => { print("값 저장실패"); });
    }

    public void GetData()
    {
        var request = new GetUserDataRequest() { PlayFabId = myID };
        PlayFabClientAPI.GetUserData(request, (result) => { foreach (var eachData in result.Data) LogText.text += eachData.Key + " : " + eachData.Value.Value + "\n"; }, (error) => print("데이터 불러오기 실패"));

        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    switch (eachStat.StatisticName)
                    {
                        case "Hp": HealthPoint = eachStat.Value; break;
                        case "Ap": AttackPoint = eachStat.Value; break;
                        case "Df": DfancePoint = eachStat.Value; break;
                        case "In": IntegerPoint = eachStat.Value; break;
                        case "x좌표": xX = eachStat.Value; break;
                        case "y좌표": yY = eachStat.Value; break;
                    }
                transform.position = (new Vector3((float)xX, (float)yY, 0));
                //StatText.text += eachStat.StatisticName + " : " + eachStat.Value + "\n";//이름과 값을 출력
            },
            (error) => { print("값 저장됨"); });
    }
}
