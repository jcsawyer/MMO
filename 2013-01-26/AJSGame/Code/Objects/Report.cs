using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Report
    {
        #region Properties

        public int ID { get; set; }
        public int User { get; set; }
        public int FromVillage { get; set; }
        public int ToVillage { get; set; }
        public int ASpear { get; set; }
        public int AspearLost { get; set; }
        public int ASword { get; set; }
        public int ASwordLost { get; set; }
        public int AAxe { get; set; }
        public int AAxeLost { get; set; }
        public int AScout { get; set; }
        public int AScoutLost { get; set; }
        public int ALight { get; set; }
        public int ALightLost { get; set; }
        public int AHeavy { get; set; }
        public int AHeavyLost { get; set; }
        public int ARam { get; set; }
        public int ARamLost { get; set; }
        public int ACata { get; set; }
        public int ACataLost { get; set; }
        public int DSpear { get; set; }
        public int DspearLost { get; set; }
        public int DSword { get; set; }
        public int DSwordLost { get; set; }
        public int DAxe { get; set; }
        public int DAxeLost { get; set; }
        public int DScout { get; set; }
        public int DScoutLost { get; set; }
        public int DLight { get; set; }
        public int DLightLost { get; set; }
        public int DHeavy { get; set; }
        public int DHeavyLost { get; set; }
        public int DRam { get; set; }
        public int DRamLost { get; set; }
        public int DCata { get; set; }
        public int DCataLost { get; set; }
        public int HaulWood { get; set; }
        public int HaulClay { get; set; }
        public int HaulMetal { get; set; }
        public int HaulFood { get; set; }
        public int SpiedWood { get; set; }
        public int SpiedClay { get; set; }
        public int SpiedMetal { get; set; }
        public int SpiedFood { get; set; }
        public int SpiedMainBuilding { get; set; }
        public int SpiedTimbercamp { get; set; }
        public int SpiedClaypit { get; set; }
        public int SpiedMine { get; set; }
        public int SpiedFarm { get; set; }
        public int SpiedWarehouse { get; set; }
        public int SpiedGranary { get; set; }
        public int SpiedBarracks { get; set; }
        public int SpiedStable { get; set; }
        public int SpiedResearchAcademy { get; set; }
        public int SpiedSiegeWorkshop { get; set; }
        public int SpiedWall { get; set; }
        public int SpiedMarket { get; set; }
        public int SpiedRallyPoint { get; set; }
        public int SpiedShelter { get; set; }
        public bool IsRead { get; set; }
        public DateTime Timestamp { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Report report)
        {
            report.ID = Convert.ToInt32(dr["id"]);
            report.User = Convert.ToInt32(dr["uref"]);
            report.FromVillage = Convert.ToInt32(dr["fromvillage"]);
            report.ToVillage = Convert.ToInt32(dr["tovillage"]);
            report.ASpear = Convert.ToInt32(dr["aspear"]);
            report.AspearLost = Convert.ToInt32(dr["aspearlost"]);
            report.ASword = Convert.ToInt32(dr["asword"]);
            report.ASwordLost = Convert.ToInt32(dr["aswordlost"]);
            report.AAxe = Convert.ToInt32(dr["aaxe"]);
            report.AAxeLost = Convert.ToInt32(dr["aaxelost"]);
            report.AScout = Convert.ToInt32(dr["ascout"]);
            report.AScoutLost = Convert.ToInt32(dr["ascoutlost"]);
            report.ALight = Convert.ToInt32(dr["alight"]);
            report.ALightLost = Convert.ToInt32(dr["alightlost"]);
            report.AHeavy = Convert.ToInt32(dr["aheavy"]);
            report.AHeavyLost = Convert.ToInt32(dr["aheavylost"]);
            report.ARam = Convert.ToInt32(dr["aram"]);
            report.ARamLost = Convert.ToInt32(dr["aramlost"]);
            report.ACata = Convert.ToInt32(dr["acata"]);
            report.ACataLost = Convert.ToInt32(dr["acatalost"]);
            report.DSpear = Convert.ToInt32(dr["dspear"]);
            report.DspearLost = Convert.ToInt32(dr["dspearlost"]);
            report.DSword = Convert.ToInt32(dr["dsword"]);
            report.DSwordLost = Convert.ToInt32(dr["dswordlost"]);
            report.DAxe = Convert.ToInt32(dr["daxe"]);
            report.DAxeLost = Convert.ToInt32(dr["daxelost"]);
            report.DScout = Convert.ToInt32(dr["dscout"]);
            report.DScoutLost = Convert.ToInt32(dr["dscoutlost"]);
            report.DLight = Convert.ToInt32(dr["dlight"]);
            report.DLightLost = Convert.ToInt32(dr["dlightlost"]);
            report.DHeavy = Convert.ToInt32(dr["dheavy"]);
            report.DHeavyLost = Convert.ToInt32(dr["dheavylost"]);
            report.DRam = Convert.ToInt32(dr["dram"]);
            report.DRamLost = Convert.ToInt32(dr["dramlost"]);
            report.DCata = Convert.ToInt32(dr["dcata"]);
            report.DCataLost = Convert.ToInt32(dr["dcatalost"]);
            report.HaulWood = Convert.ToInt32(dr["haulwood"]);
            report.HaulClay = Convert.ToInt32(dr["haulclay"]);
            report.HaulMetal = Convert.ToInt32(dr["haulmetal"]);
            report.HaulFood = Convert.ToInt32(dr["haulfood"]);
            report.SpiedWood = Convert.ToInt32(dr["spiedwood"]);
            report.SpiedClay = Convert.ToInt32(dr["spiedclay"]);
            report.SpiedMetal = Convert.ToInt32(dr["spiedmetal"]);
            report.SpiedFood = Convert.ToInt32(dr["spiedfood"]);
            report.SpiedMainBuilding = Convert.ToInt32(dr["spiedmain"]);
            report.SpiedTimbercamp = Convert.ToInt32(dr["spiedtimbercamp"]);
            report.SpiedClaypit = Convert.ToInt32(dr["spiedclaypit"]);
            report.SpiedMine = Convert.ToInt32(dr["spiedmine"]);
            report.SpiedFarm = Convert.ToInt32(dr["spiedfarm"]);
            report.SpiedWarehouse = Convert.ToInt32(dr["spiedwarehouse"]);
            report.SpiedGranary = Convert.ToInt32(dr["spiedgranary"]);
            report.SpiedBarracks = Convert.ToInt32(dr["spiedbarracks"]);
            report.SpiedStable = Convert.ToInt32(dr["spiedstable"]);
            report.SpiedResearchAcademy = Convert.ToInt32(dr["spiedacademy"]);
            report.SpiedSiegeWorkshop = Convert.ToInt32(dr["spiedworkshop"]);
            report.SpiedWall = Convert.ToInt32(dr["spiedwall"]);
            report.SpiedMarket = Convert.ToInt32(dr["spiedmarket"]);
            report.SpiedRallyPoint = Convert.ToInt32(dr["spiedrally"]);
            report.SpiedShelter = Convert.ToInt32(dr["spiedshelter"]);
            report.IsRead = Convert.ToBoolean(dr["isread"]);
            report.Timestamp = Convert.ToDateTime(dr["timestamp"]);
        }

        #endregion

        #region Public Methods

        public void Delete()
        {
            DeleteReport(this);
            this.ID = 0;
        }

        #endregion

        #region Public Static Methods

        public static Report GetReport(int id)
        {
            Report result = new Report();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM reports WHERE id = '" + id + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static List<Report> GetReports()
        {
            List<Report> result = new List<Report>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM reports");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Report report = new Report();
                    Fill(dr, report);
                    result.Add(report);
                }
            }
            return result;
        }

        public static List<Report> GetReports(string where)
        {
            List<Report> result = new List<Report>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM reports WHERE " + where);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Report report = new Report();
                    Fill(dr, report);
                    result.Add(report);
                }
            }
            return result;
        }

        public static bool NewReport(int uref, int fromvillage, int tovillage, int aspear, int aspearlost, int asword, int aswordlost, int aaxe, int aaxelost, int ascout, int ascoutlost, int alight, int alightlost, int aheavy, int aheavylost, int aram, int aramlost, int acata, int acatalost, int dspear, int dspearlost, int dsword, int dswordlost, int daxe, int daxelost, int dscout, int dscoutlost, int dlight, int dlightlost, int dheavy, int dheavylost, int dram, int dramlost, int dcata, int dcatalost, int haulwood, int haulclay, int haulmetal, int haulfood, int spiedwood, int spiedclay, int spiedmetal, int spiedfood, int spiedmain, int spiedtimbercamp, int spiedclaypit, int spiedmine, int spiedfarm, int spiedwarehouse, int spiedgranary, int spiedbarracks, int spiedstable, int spiedacademy, int spiedworkshop, int spiedwall, int spiedmarket, int spiedrally, int spiedshelter)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("uref", uref);
            hashtable.Add("fromvillage", fromvillage);
            hashtable.Add("tovillage", tovillage);
            hashtable.Add("aspear", aspear);
            hashtable.Add("aspearlost", aspearlost);
            hashtable.Add("asword", asword);
            hashtable.Add("aswordlost", aswordlost);
            hashtable.Add("aaxe", aaxe);
            hashtable.Add("aaxelost", aaxelost);
            hashtable.Add("ascout", ascout);
            hashtable.Add("ascoutlost", ascoutlost);
            hashtable.Add("alight", alight);
            hashtable.Add("alightlost", alightlost);
            hashtable.Add("aheavy", aheavy);
            hashtable.Add("aheavylost", aheavylost);
            hashtable.Add("aram", aram);
            hashtable.Add("aramlost", aramlost);
            hashtable.Add("acata", acata);
            hashtable.Add("acatalost", acatalost);
            hashtable.Add("dspear", aspear);
            hashtable.Add("dspearlost", dspearlost);
            hashtable.Add("dsword", dsword);
            hashtable.Add("dswordlost", dswordlost);
            hashtable.Add("daxe", daxe);
            hashtable.Add("daxelost", daxelost);
            hashtable.Add("dscout", dscout);
            hashtable.Add("dscoutlost", dscoutlost);
            hashtable.Add("dlight", dlight);
            hashtable.Add("dlightlost", dlightlost);
            hashtable.Add("dheavy", dheavy);
            hashtable.Add("dheavylost", dheavylost);
            hashtable.Add("dram", dram);
            hashtable.Add("dramlost", dramlost);
            hashtable.Add("dcata", dcata);
            hashtable.Add("dcatalost", dcatalost);
            hashtable.Add("haulwood", haulwood);
            hashtable.Add("haulclay", haulclay);
            hashtable.Add("haulmetal", haulmetal);
            hashtable.Add("haulfood", haulfood);
            hashtable.Add("spiedwood", spiedwood);
            hashtable.Add("spiedclay", spiedclay);
            hashtable.Add("spiedmetal", spiedmetal);
            hashtable.Add("spiedfood", spiedfood);
            hashtable.Add("spiedmain", spiedmain);
            hashtable.Add("spiedtimbercamp", spiedtimbercamp);
            hashtable.Add("spiedclaypit", spiedclaypit);
            hashtable.Add("spiedmine", spiedmine);
            hashtable.Add("spiedfarm", spiedfarm);
            hashtable.Add("spiedwarehouse", spiedwarehouse);
            hashtable.Add("spiedgranary", spiedgranary);
            hashtable.Add("spiedbarracks", spiedbarracks);
            hashtable.Add("spiedstable", spiedstable);
            hashtable.Add("spiedacademy", spiedacademy);
            hashtable.Add("spiedworkshop", spiedworkshop);
            hashtable.Add("spiedwall", spiedwall);
            hashtable.Add("spiedmarket", spiedmarket);
            hashtable.Add("spiedrally", spiedrally);
            hashtable.Add("spiedshelter", spiedshelter);
            hashtable.Add("isread", 0);
            hashtable.Add("timestamp", AJSGame.Core.Functions.DateString(DateTime.UtcNow));

            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static void DeleteReport(Report report)
        {
            Hashtable hashtable = SQL.DeleteData("reports", "id = '" + report.ID + "'");
        }

        #endregion
    }
}