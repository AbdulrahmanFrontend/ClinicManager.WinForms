using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsAppointmentStatus
    {
        public enum enMode { enAddNew, enUpdate}
        public enMode Mode { get; set; }
        public enum enContext 
        { 
            NewReservation, UpdateReservation, UpdateTodayAppointment 
        }
        public static enContext Context { get; set; }
        private static string _StrContext()
        {
            switch (Context)
            {
                case enContext.NewReservation:
                    return "New Reservation";
                case enContext.UpdateReservation:
                    return "Update Reservation";
                case enContext.UpdateTodayAppointment:
                    return "Update Today Appointment";
                default:
                    return "New Reservation";
            }
        }
        public int StatusID { get; private set; }
        public string StatusName { get; set; }
        private clsAppointmentStatus(int AppointmentStatusID, string Status)
        {
            this.StatusID = AppointmentStatusID;
            this.StatusName = Status;
            this.Mode = enMode.enUpdate;
        }
        public static clsAppointmentStatus FindByStatusName(string StatusName)
        {
            var Status = 
                clsAppointmentStatusDataAccess.FindStatusByStatusName(StatusName);
            if (Status.HasValue)
            {
                int StatusID = Status.Value.StatusID;
                string AppointmentStatus = Status.Value.StatusName;
                return new clsAppointmentStatus(StatusID, AppointmentStatus);
            }
            return null;
        }
        public static clsAppointmentStatus FindByStatusID(int StatusID)
        {
            var Status = 
                clsAppointmentStatusDataAccess.FindStatusByStatusID(StatusID);
            if (Status.HasValue)
            {
                string StatusName = Status.Value.StatusName;
                int AppointmentStatusID = Status.Value.StatusID;
                return new clsAppointmentStatus(AppointmentStatusID, StatusName);
            }
            return null;
        }
        public static List<string> GetAppointmentStatusListByContext()
        {
            return clsAppointmentStatusDataAccess.
                GetAppointmentStatusListByContext(_StrContext());
        }
        public static bool IsAppointmentStatusFound(int AppointmentStatusID)
        {
            return clsAppointmentStatusDataAccess.
                IsAppointmentStatusFound(AppointmentStatusID);
        }
    }
}
