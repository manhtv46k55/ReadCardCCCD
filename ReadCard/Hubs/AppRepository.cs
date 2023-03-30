using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ReadCard.Data.Entities;
using Newtonsoft.Json;
using ReadCard.Models;

namespace ReadCard.Hubs
{
    public class AppRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<CCCDCardView> GetCard()
        {
            var messages = new List<CCCDCardView>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [ID]
                                                      ,[DATA]
                                                      ,[CREATED_DATE]
                                                  FROM [dbo].[CCCD] ", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);

                    //dependency.OnChange -= new OnChangeEventHandler(dependency_OnChange);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CCCDCardView card = new CCCDCardView();
                        card.ID = Convert.ToInt32(reader["ID"].ToString());
                        card.UploadTime = Convert.ToDateTime(reader["CREATED_DATE"].ToString());
                        card.CCCDCard = JsonConvert.DeserializeObject<CCCDCard>(reader["DATA"].ToString());
                        messages.Add(card);
                    }
                }

            }
            return messages;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {

            if (e.Type == SqlNotificationType.Change && (e.Info == SqlNotificationInfo.Insert || e.Info == SqlNotificationInfo.Update || e.Info == SqlNotificationInfo.Delete))
            {
                MyHub.GetCard();
            }

            // Giải phóng tài nguyên của SqlDependency
            ((SqlDependency)sender).OnChange -= dependency_OnChange;

        }


    }
}