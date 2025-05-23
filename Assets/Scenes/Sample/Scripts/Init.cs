using System.Collections;
using System.Collections.Generic;
using System.IO;
using odysseyAnalytics.Adapters.Logger;
using odysseyAnalytics.Adapters.RabbitMQ;
using odysseyAnalytics.Adapters.REST;
using odysseyAnalytics.Adapters.Sqlite;
using UnityEngine;
using odysseyAnalytics.Core.Application.Session;
using odysseyAnalytics.Core.Ports;
using ILogger = odysseyAnalytics.Core.Ports.ILogger;

public class Init : MonoBehaviour
{
    public SessionHandler session;
    async void Start()
    {
        string token = "QSRBAtavWWSxfkbRKUtiXlZF1CoPQyYDDYaU5Bls5OrfgzXPTu9CjXVRFyjqlhSK";
        RESTAdapter gatewayPort = new RESTAdapter("https://odysseyanalytics.ir/api/");
        ILogger logger = new DefaultLogger();
        RabbitMQAdapter rabbitMqAdapter = new RabbitMQAdapter();
        SQLitePCL.Batteries_V2.Init();
        SqliteAdapter sqliteAdapter = new SqliteAdapter(Path.Combine(Application.persistentDataPath,"events.db"));
        session = new SessionHandler(gatewayPort,rabbitMqAdapter,rabbitMqAdapter,logger,sqliteAdapter,token);
        await session.InitializeSessionAsync();
        await session.StartSessionAsync("Android");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
