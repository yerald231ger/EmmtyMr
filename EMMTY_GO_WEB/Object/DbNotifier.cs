using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EMMTY_GO_WEB.Models;
using Newtonsoft.Json;

namespace EMMTY_GO_WEB.Object
{
    public class DbNotifier
    {
        public event OnChangeEventHandler OnNewChange;
        public int IdCondicional { get; }

        private SqlDependency _dependencyObj;
        private SqlConnection _connection;
        private SqlCommand _command;

        private readonly string _connectionsString;
        private readonly string _query;
        private static List<DbNotifier> _listInstances;

        private static readonly Lazy<List<DbNotifier>> listInstances = 
            new Lazy<List<DbNotifier>>(() =>
            {
                _listInstances = new List<DbNotifier>();
                using (var db = new ApplicationDbContext())
                {
                    _listInstances.AddRange(db.Cajeros.ToList().Select(cajeros => new DbNotifier(cajeros.IdCajero)));
                }
                return _listInstances;
            });

        public static List<DbNotifier> ListInstances => listInstances.Value;

        public static DbNotifier AddDbNotifier(int idCondicional)
        {
            var dbnotifier = new DbNotifier(idCondicional);
            _listInstances.Add(dbnotifier);
            return dbnotifier;
        }

        private DbNotifier(int idCondicional)
        {
            _connectionsString = ConfigurationManager.ConnectionStrings["EmmtyGoDbDefaultConnection"].ConnectionString;
            _query = ConfigurationManager.AppSettings["SqlDependencyQuery"] + idCondicional;
            IdCondicional = idCondicional;
            ResgisterNotification();
        }   

        private void ResgisterNotification()
        {
            using (_connection = new SqlConnection(_connectionsString))
            {
                using (_command = new SqlCommand(_query, _connection))
                {
                    _command.Notification = null;
                    _dependencyObj = new SqlDependency(_command);
                    _dependencyObj.OnChange += dependency_OnChange;
                    if (_connection.State == ConnectionState.Closed)
                        _connection.Open();
                    using (_command.ExecuteReader())
                    {
                    }
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Subscribe || e.Info == SqlNotificationInfo.Error)
                return;
            string jsonCajero;

            if (e.Info == SqlNotificationInfo.Delete)
            {
                var dbnn = _listInstances.Find(dbn => dbn.IdCondicional == IdCondicional);
                _listInstances.Remove(dbnn);
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                var cajero = db.Cajeros.Find(IdCondicional).ToSimpleCajero();
                jsonCajero = JsonConvert.SerializeObject(cajero);
            }

            if (OnNewChange != null) OnNewChange(jsonCajero, e);

            ResgisterNotification();
        }

        public class MethodList
        {
            public List<Action<object,SqlNotificationEventArgs>> Methods { get; set; }
        }
    }
}