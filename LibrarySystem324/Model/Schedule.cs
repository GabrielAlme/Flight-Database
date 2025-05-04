using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem324.Model
{
    internal class Schedule
    {
        private DataRow _Row;
        public Schedule(DataRow aRow)
        {
            int PlaneNo = (int)aRow["Plane_ID"];
            DataTable dt = DBEngine.GetTable("Select * From schedule where PlaneNo="+PlaneNo.ToString());

            _Row =dt.Rows[0];
        }

       
        public static DataTable search(string filter)
        {
            DataTable Tbl = new DataTable();
            string SQL = "Select PlaneNo as Plane_ID, ArrivalLocation as Arrival_Airport, ArrivalGate as Arrival_Gate,(SELECT COUNT(*) from Boarding b where b.PlaneNo = s.PlaneNo) as Num_Passengers, a.AirportName as Departure_Airport from schedule s Join plane p on s.PlaneNo = p.PlaneID Join Airport a on p.Location = a.ICAO_Code ";
            if (filter.Trim() != "") { SQL += "where " + filter.Trim(); }

             Tbl=  DBEngine.GetTable(SQL);
         
            return Tbl;
        }
        public static DataTable booksTable()
        {
            return DBEngine.GetTable("\r\n\tSelect PlaneNo as Plane_ID, ArrivalLocation as Arrival_Airport, ArrivalGate as Arrival_Gate,\r\n\t(SELECT COUNT(*) from Boarding b \r\n\twhere b.PlaneNo = s.PlaneNo) as Num_Passengers, a.AirportName as \r\n\tDeparture_Airport from schedule s\r\n\tJoin plane p on s.PlaneNo = p.PlaneID\r\n\tJoin Airport a on p.Location = a.ICAO_Code\r\n\torder by PlaneNo asc;");
        }
        public static DataTable booksTableWithAuthorName()
        {
            return DBEngine.GetTable("Select PlaneNo as Plane_ID, ArrivalLocation as Arrival_Airport, ArrivalGate as Arrival_Gate,\r\n(SELECT COUNT(*) from Boarding b \r\nwhere b.PlaneNo = s.PlaneNo) as Num_Passengers, a.AirportName as \r\nDeparture_Airport from schedule s\r\nJoin plane p on s.PlaneNo = p.PlaneID\r\nJoin Airport a on p.Location = a.ICAO_Code\r\norder by PlaneNo asc;");
    
        }
        public static void createNew()
        {//
            string SQL = "INSERT INTO Schedule (PlaneNo, ArrivalLocation, ArrivalGate) VALUES (0, 'PH', 'PH')";
            DBEngine.Execute(SQL);
        }

        public  void save()
        {
            
                string SQL = "UPDATE Schedule SET PlaneNo='" + PlaneNo + "', Arrival_Gate='" + Arrival_Gate + " WHERE PlaneID=" + PlaneID.ToString() ;
                DBEngine.Execute(SQL);
          
        }

        public  void delete()
        {
            string SQL = "DELETE FROM Schedule WHERE PlaneNo=" + PlaneID.ToString();
                DBEngine.Execute(SQL);
            

        }

        public int PlaneID => (int)_Row["PlaneNo"];
        public string Arrival_Airport
        {
            get
            {
                return (string) _Row["Arrival_Airport"];
            }
            set
            {
                _Row["Arrival_Airport"] = value;
            }
        }
        public string Arrival_Gate
        {
            get
            {
                return (string) _Row["Arrival_Gate"];
            }
            set
            {
                _Row["Arrival_Gate"] = value;
            }
        }
        public int Num_Passengers
        {
            get
            {
                return (int)_Row["Num_Passengers"];
            }
            set
            {
                _Row["Num_Passengers"] = value;
            }
        }
        public int PlaneNo
        {
            get
            {
                return (int)_Row["PlaneNo"];
            }
            set
            {
                _Row["PlaneNo"] = value;
            }
        }


    }
}
