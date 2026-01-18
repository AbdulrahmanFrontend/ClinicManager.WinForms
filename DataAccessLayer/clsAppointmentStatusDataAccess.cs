using LoggingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsAppointmentStatusDataAccess : clsDataAccessHelper
    {
        public struct stStatus
        {
            public int StatusID { get; set; }
            public string StatusName { get; set; }
        }
        public static stStatus? FindStatusByStatusName(string StatusName)
        {
            string Query = @"SELECT * FROM AppointmentStatus 
            WHERE Status = @Status;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "status", StatusName },
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if (Row != null)
            {
                return new stStatus()
                {
                    StatusID = (int)Row["AppointmentStatusID"],
                    StatusName = Row["Status"].ToString()
                };
            }
            return null;
        }
        public static stStatus? FindStatusByStatusID(int StatusID)
        {
            string Query = @"SELECT * FROM AppointmentStatus 
            WHERE AppointmentStatusID = @AppointmentStatusID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentStatusID", StatusID },
            };
            DataRow Row = _GetFirstRow(Query, Params);
            if (Row != null)
            {
                return new stStatus()
                {
                    StatusID = (int)Row["AppointmentStatusID"],
                    StatusName = Row["Status"].ToString()
                };
            }
            return null;
        }
        public static List<string> 
            GetAppointmentStatusListByContext(string Context)
        {
            string Query = @"SELECT Status FROM AppointmentStatus
            where
            (
                @Context = 'New Reservation' AND Status IN ('Confirmed', 'Pending')
            ) OR (
                @Context = 'Update Reservation' 
                AND 
                Status IN ('Canceled', 'Rescheduled', 'Confirmed', 'Pending')
            ) OR (
                @Context = 'Update Today Appointment' 
                AND 
                Status IN 
                ('No Show', 'Canceled', 'Rescheduled', 'Completed', 'Confirmed')
            );";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@Context", Context }
            };
            List<string> StatusList = _GetDataTable(Query, Params).AsEnumerable()
                .Select(r => r["Status"].ToString()).ToList();
            return StatusList;
        }
        public static bool IsAppointmentStatusFound(int AppointmentStatusID)
        {
            int num = 0;
            string Query = @"select IsFound = 1 from AppointmentStatus 
            where AppointmentStatusID = @AppointmentStatusID;";
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                { "@AppointmentStatusID", AppointmentStatusID }
            };
            object Result = _GetScalar(Query, Params);
            if(Result != null)
            {
                int.TryParse(Result.ToString(), out num);
            }
            return num > 0;
        }
    }
}
