using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.EcologyDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-02 15:29
    /// 描 述：HrmResource
    /// </summary>
    public class HrmResourceEntity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// loginid
        /// </summary>
        /// <returns></returns>
        [Column("LOGINID")]
        public string loginid { get; set; }
        /// <summary>
        /// password
        /// </summary>
        /// <returns></returns>
        [Column("PASSWORD")]
        public string password { get; set; }
        /// <summary>
        /// lastname
        /// </summary>
        /// <returns></returns>
        [Column("LASTNAME")]
        public string lastname { get; set; }
        /// <summary>
        /// sex
        /// </summary>
        /// <returns></returns>
        [Column("SEX")]
        public string sex { get; set; }
        /// <summary>
        /// birthday
        /// </summary>
        /// <returns></returns>
        [Column("BIRTHDAY")]
        public string birthday { get; set; }
        /// <summary>
        /// nationality
        /// </summary>
        /// <returns></returns>
        [Column("NATIONALITY")]
        public int? nationality { get; set; }
        /// <summary>
        /// systemlanguage
        /// </summary>
        /// <returns></returns>
        [Column("SYSTEMLANGUAGE")]
        public int? systemlanguage { get; set; }
        /// <summary>
        /// maritalstatus
        /// </summary>
        /// <returns></returns>
        [Column("MARITALSTATUS")]
        public string maritalstatus { get; set; }
        /// <summary>
        /// telephone
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string telephone { get; set; }
        /// <summary>
        /// mobile
        /// </summary>
        /// <returns></returns>
        [Column("MOBILE")]
        public string mobile { get; set; }
        /// <summary>
        /// mobilecall
        /// </summary>
        /// <returns></returns>
        [Column("MOBILECALL")]
        public string mobilecall { get; set; }
        /// <summary>
        /// email
        /// </summary>
        /// <returns></returns>
        [Column("EMAIL")]
        public string email { get; set; }
        /// <summary>
        /// locationid
        /// </summary>
        /// <returns></returns>
        [Column("LOCATIONID")]
        public int? locationid { get; set; }
        /// <summary>
        /// workroom
        /// </summary>
        /// <returns></returns>
        [Column("WORKROOM")]
        public string workroom { get; set; }
        /// <summary>
        /// homeaddress
        /// </summary>
        /// <returns></returns>
        [Column("HOMEADDRESS")]
        public string homeaddress { get; set; }
        /// <summary>
        /// resourcetype
        /// </summary>
        /// <returns></returns>
        [Column("RESOURCETYPE")]
        public string resourcetype { get; set; }
        /// <summary>
        /// startdate
        /// </summary>
        /// <returns></returns>
        [Column("STARTDATE")]
        public string startdate { get; set; }
        /// <summary>
        /// enddate
        /// </summary>
        /// <returns></returns>
        [Column("ENDDATE")]
        public string enddate { get; set; }
        /// <summary>
        /// jobtitle
        /// </summary>
        /// <returns></returns>
        [Column("JOBTITLE")]
        public int? jobtitle { get; set; }
        /// <summary>
        /// jobactivitydesc
        /// </summary>
        /// <returns></returns>
        [Column("JOBACTIVITYDESC")]
        public string jobactivitydesc { get; set; }
        /// <summary>
        /// joblevel
        /// </summary>
        /// <returns></returns>
        [Column("JOBLEVEL")]
        public int? joblevel { get; set; }
        /// <summary>
        /// seclevel
        /// </summary>
        /// <returns></returns>
        [Column("SECLEVEL")]
        public int? seclevel { get; set; }
        /// <summary>
        /// departmentid
        /// </summary>
        /// <returns></returns>
        [Column("DEPARTMENTID")]
        public int? departmentid { get; set; }
        /// <summary>
        /// subcompanyid1
        /// </summary>
        /// <returns></returns>
        [Column("SUBCOMPANYID1")]
        public int? subcompanyid1 { get; set; }
        /// <summary>
        /// costcenterid
        /// </summary>
        /// <returns></returns>
        [Column("COSTCENTERID")]
        public int? costcenterid { get; set; }
        /// <summary>
        /// managerid
        /// </summary>
        /// <returns></returns>
        [Column("MANAGERID")]
        public int? managerid { get; set; }
        /// <summary>
        /// assistantid
        /// </summary>
        /// <returns></returns>
        [Column("ASSISTANTID")]
        public int? assistantid { get; set; }
        /// <summary>
        /// bankid1
        /// </summary>
        /// <returns></returns>
        [Column("BANKID1")]
        public int? bankid1 { get; set; }
        /// <summary>
        /// accountid1
        /// </summary>
        /// <returns></returns>
        [Column("ACCOUNTID1")]
        public string accountid1 { get; set; }
        /// <summary>
        /// resourceimageid
        /// </summary>
        /// <returns></returns>
        [Column("RESOURCEIMAGEID")]
        public int? resourceimageid { get; set; }
        /// <summary>
        /// createrid
        /// </summary>
        /// <returns></returns>
        [Column("CREATERID")]
        public int? createrid { get; set; }
        /// <summary>
        /// createdate
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDATE")]
        public string createdate { get; set; }
        /// <summary>
        /// lastmodid
        /// </summary>
        /// <returns></returns>
        [Column("LASTMODID")]
        public int? lastmodid { get; set; }
        /// <summary>
        /// lastmoddate
        /// </summary>
        /// <returns></returns>
        [Column("LASTMODDATE")]
        public string lastmoddate { get; set; }
        /// <summary>
        /// lastlogindate
        /// </summary>
        /// <returns></returns>
        [Column("LASTLOGINDATE")]
        public string lastlogindate { get; set; }
        /// <summary>
        /// datefield1
        /// </summary>
        /// <returns></returns>
        [Column("DATEFIELD1")]
        public string datefield1 { get; set; }
        /// <summary>
        /// datefield2
        /// </summary>
        /// <returns></returns>
        [Column("DATEFIELD2")]
        public string datefield2 { get; set; }
        /// <summary>
        /// datefield3
        /// </summary>
        /// <returns></returns>
        [Column("DATEFIELD3")]
        public string datefield3 { get; set; }
        /// <summary>
        /// datefield4
        /// </summary>
        /// <returns></returns>
        [Column("DATEFIELD4")]
        public string datefield4 { get; set; }
        /// <summary>
        /// datefield5
        /// </summary>
        /// <returns></returns>
        [Column("DATEFIELD5")]
        public string datefield5 { get; set; }
      
        /// <summary>
        /// textfield1
        /// </summary>
        /// <returns></returns>
        [Column("TEXTFIELD1")]
        public string textfield1 { get; set; }
        /// <summary>
        /// textfield2
        /// </summary>
        /// <returns></returns>
        [Column("TEXTFIELD2")]
        public string textfield2 { get; set; }
        /// <summary>
        /// textfield3
        /// </summary>
        /// <returns></returns>
        [Column("TEXTFIELD3")]
        public string textfield3 { get; set; }
        /// <summary>
        /// textfield4
        /// </summary>
        /// <returns></returns>
        [Column("TEXTFIELD4")]
        public string textfield4 { get; set; }
        /// <summary>
        /// textfield5
        /// </summary>
        /// <returns></returns>
        [Column("TEXTFIELD5")]
        public string textfield5 { get; set; }
        /// <summary>
        /// tinyintfield1
        /// </summary>
        /// <returns></returns>
        [Column("TINYINTFIELD1")]
        public byte? tinyintfield1 { get; set; }
        /// <summary>
        /// tinyintfield2
        /// </summary>
        /// <returns></returns>
        [Column("TINYINTFIELD2")]
        public byte? tinyintfield2 { get; set; }
        /// <summary>
        /// tinyintfield3
        /// </summary>
        /// <returns></returns>
        [Column("TINYINTFIELD3")]
        public byte? tinyintfield3 { get; set; }
        /// <summary>
        /// tinyintfield4
        /// </summary>
        /// <returns></returns>
        [Column("TINYINTFIELD4")]
        public byte? tinyintfield4 { get; set; }
        /// <summary>
        /// tinyintfield5
        /// </summary>
        /// <returns></returns>
        [Column("TINYINTFIELD5")]
        public byte? tinyintfield5 { get; set; }
        /// <summary>
        /// certificatenum
        /// </summary>
        /// <returns></returns>
        [Column("CERTIFICATENUM")]
        public string certificatenum { get; set; }
        /// <summary>
        /// nativeplace
        /// </summary>
        /// <returns></returns>
        [Column("NATIVEPLACE")]
        public string nativeplace { get; set; }
        /// <summary>
        /// educationlevel
        /// </summary>
        /// <returns></returns>
        [Column("EDUCATIONLEVEL")]
        public int? educationlevel { get; set; }
        /// <summary>
        /// bememberdate
        /// </summary>
        /// <returns></returns>
        [Column("BEMEMBERDATE")]
        public string bememberdate { get; set; }
        /// <summary>
        /// bepartydate
        /// </summary>
        /// <returns></returns>
        [Column("BEPARTYDATE")]
        public string bepartydate { get; set; }
        /// <summary>
        /// workcode
        /// </summary>
        /// <returns></returns>
        [Column("WORKCODE")]
        public string workcode { get; set; }
        /// <summary>
        /// regresidentplace
        /// </summary>
        /// <returns></returns>
        [Column("REGRESIDENTPLACE")]
        public string regresidentplace { get; set; }
        /// <summary>
        /// healthinfo
        /// </summary>
        /// <returns></returns>
        [Column("HEALTHINFO")]
        public string healthinfo { get; set; }
        /// <summary>
        /// residentplace
        /// </summary>
        /// <returns></returns>
        [Column("RESIDENTPLACE")]
        public string residentplace { get; set; }
        /// <summary>
        /// policy
        /// </summary>
        /// <returns></returns>
        [Column("POLICY")]
        public string policy { get; set; }
        /// <summary>
        /// degree
        /// </summary>
        /// <returns></returns>
        [Column("DEGREE")]
        public string degree { get; set; }
        /// <summary>
        /// height
        /// </summary>
        /// <returns></returns>
        [Column("HEIGHT")]
        public string height { get; set; }
        /// <summary>
        /// usekind
        /// </summary>
        /// <returns></returns>
        [Column("USEKIND")]
        public int? usekind { get; set; }
        /// <summary>
        /// jobcall
        /// </summary>
        /// <returns></returns>
        [Column("JOBCALL")]
        public int? jobcall { get; set; }
        /// <summary>
        /// accumfundaccount
        /// </summary>
        /// <returns></returns>
        [Column("ACCUMFUNDACCOUNT")]
        public string accumfundaccount { get; set; }
        /// <summary>
        /// birthplace
        /// </summary>
        /// <returns></returns>
        [Column("BIRTHPLACE")]
        public string birthplace { get; set; }
        /// <summary>
        /// folk
        /// </summary>
        /// <returns></returns>
        [Column("FOLK")]
        public string folk { get; set; }
        /// <summary>
        /// residentphone
        /// </summary>
        /// <returns></returns>
        [Column("RESIDENTPHONE")]
        public string residentphone { get; set; }
        /// <summary>
        /// residentpostcode
        /// </summary>
        /// <returns></returns>
        [Column("RESIDENTPOSTCODE")]
        public string residentpostcode { get; set; }
        /// <summary>
        /// extphone
        /// </summary>
        /// <returns></returns>
        [Column("EXTPHONE")]
        public string extphone { get; set; }
        /// <summary>
        /// managerstr
        /// </summary>
        /// <returns></returns>
        [Column("MANAGERSTR")]
        public string managerstr { get; set; }
        /// <summary>
        /// status
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public int? status { get; set; }
        /// <summary>
        /// fax
        /// </summary>
        /// <returns></returns>
        [Column("FAX")]
        public string fax { get; set; }
        /// <summary>
        /// islabouunion
        /// </summary>
        /// <returns></returns>
        [Column("ISLABOUUNION")]
        public string islabouunion { get; set; }
        /// <summary>
        /// weight
        /// </summary>
        /// <returns></returns>
        [Column("WEIGHT")]
        public int? weight { get; set; }
        /// <summary>
        /// tempresidentnumber
        /// </summary>
        /// <returns></returns>
        [Column("TEMPRESIDENTNUMBER")]
        public string tempresidentnumber { get; set; }
        /// <summary>
        /// probationenddate
        /// </summary>
        /// <returns></returns>
        [Column("PROBATIONENDDATE")]
        public string probationenddate { get; set; }
        /// <summary>
        /// countryid
        /// </summary>
        /// <returns></returns>
        [Column("COUNTRYID")]
        public int? countryid { get; set; }
        /// <summary>
        /// passwdchgdate
        /// </summary>
        /// <returns></returns>
        [Column("PASSWDCHGDATE")]
        public string passwdchgdate { get; set; }
        /// <summary>
        /// needusb
        /// </summary>
        /// <returns></returns>
        [Column("NEEDUSB")]
        public int? needusb { get; set; }
        /// <summary>
        /// serial
        /// </summary>
        /// <returns></returns>
        [Column("SERIAL")]
        public string serial { get; set; }
        /// <summary>
        /// account
        /// </summary>
        /// <returns></returns>
        [Column("ACCOUNT")]
        public string account { get; set; }
        /// <summary>
        /// lloginid
        /// </summary>
        /// <returns></returns>
        [Column("LLOGINID")]
        public string lloginid { get; set; }
        /// <summary>
        /// needdynapass
        /// </summary>
        /// <returns></returns>
        [Column("NEEDDYNAPASS")]
        public int? needdynapass { get; set; }
        
        /// <summary>
        /// passwordstate
        /// </summary>
        /// <returns></returns>
        [Column("PASSWORDSTATE")]
        public int? passwordstate { get; set; }
        /// <summary>
        /// accounttype
        /// </summary>
        /// <returns></returns>
        [Column("ACCOUNTTYPE")]
        public int? accounttype { get; set; }
        /// <summary>
        /// belongto
        /// </summary>
        /// <returns></returns>
        [Column("BELONGTO")]
        public int? belongto { get; set; }
        /// <summary>
        /// dactylogram
        /// </summary>
        /// <returns></returns>
        [Column("DACTYLOGRAM")]
        public string dactylogram { get; set; }
        /// <summary>
        /// assistantdactylogram
        /// </summary>
        /// <returns></returns>
        [Column("ASSISTANTDACTYLOGRAM")]
        public string assistantdactylogram { get; set; }
        /// <summary>
        /// passwordlock
        /// </summary>
        /// <returns></returns>
        [Column("PASSWORDLOCK")]
        public int? passwordlock { get; set; }
        /// <summary>
        /// sumpasswordwrong
        /// </summary>
        /// <returns></returns>
        [Column("SUMPASSWORDWRONG")]
        public int? sumpasswordwrong { get; set; }
        /// <summary>
        /// oldpassword1
        /// </summary>
        /// <returns></returns>
        [Column("OLDPASSWORD1")]
        public string oldpassword1 { get; set; }
        /// <summary>
        /// oldpassword2
        /// </summary>
        /// <returns></returns>
        [Column("OLDPASSWORD2")]
        public string oldpassword2 { get; set; }
        /// <summary>
        /// msgStyle
        /// </summary>
        /// <returns></returns>
        [Column("MSGSTYLE")]
        public string msgStyle { get; set; }
        /// <summary>
        /// messagerurl
        /// </summary>
        /// <returns></returns>
        [Column("MESSAGERURL")]
        public string messagerurl { get; set; }
        /// <summary>
        /// pinyinlastname
        /// </summary>
        /// <returns></returns>
        [Column("PINYINLASTNAME")]
        public string pinyinlastname { get; set; }
        /// <summary>
        /// tokenkey
        /// </summary>
        /// <returns></returns>
        [Column("TOKENKEY")]
        public string tokenkey { get; set; }
        /// <summary>
        /// userUsbType
        /// </summary>
        /// <returns></returns>
        [Column("USERUSBTYPE")]
        public string userUsbType { get; set; }
        /// <summary>
        /// outkey
        /// </summary>
        /// <returns></returns>
        [Column("OUTKEY")]
        public string outkey { get; set; }
        /// <summary>
        /// adsjgs
        /// </summary>
        /// <returns></returns>
        [Column("ADSJGS")]
        public string adsjgs { get; set; }
        /// <summary>
        /// adgs
        /// </summary>
        /// <returns></returns>
        [Column("ADGS")]
        public string adgs { get; set; }
        /// <summary>
        /// adbm
        /// </summary>
        /// <returns></returns>
        [Column("ADBM")]
        public string adbm { get; set; }
        /// <summary>
        /// mobileshowtype
        /// </summary>
        /// <returns></returns>
        [Column("MOBILESHOWTYPE")]
        public int? mobileshowtype { get; set; }
        /// <summary>
        /// usbstate
        /// </summary>
        /// <returns></returns>
        [Column("USBSTATE")]
        public int? usbstate { get; set; }
    
        /// <summary>
        /// ecology_pinyin_search
        /// </summary>
        /// <returns></returns>
        [Column("ECOLOGY_PINYIN_SEARCH")]
        public string ecology_pinyin_search { get; set; }
        /// <summary>
        /// isADAccount
        /// </summary>
        /// <returns></returns>
        [Column("ISADACCOUNT")]
        public string isADAccount { get; set; }
        /// <summary>
        /// accountname
        /// </summary>
        /// <returns></returns>
        [Column("ACCOUNTNAME")]
        public string accountname { get; set; }
        /// <summary>
        /// notallot
        /// </summary>
        /// <returns></returns>
        [Column("NOTALLOT")]
        public int? notallot { get; set; }
        /// <summary>
        /// beforefrozen
        /// </summary>
        /// <returns></returns>
        [Column("BEFOREFROZEN")]
        public int? beforefrozen { get; set; }
        /// <summary>
        /// resourcefrom
        /// </summary>
        /// <returns></returns>
        [Column("RESOURCEFROM")]
        public string resourcefrom { get; set; }
        /// <summary>
        /// isnewuser
        /// </summary>
        /// <returns></returns>
        [Column("ISNEWUSER")]
        public string isnewuser { get; set; }
        /// <summary>
        /// created
        /// </summary>
        /// <returns></returns>
        [Column("CREATED")]
        public DateTime? created { get; set; }
        /// <summary>
        /// creater
        /// </summary>
        /// <returns></returns>
        [Column("CREATER")]
        public int? creater { get; set; }
        /// <summary>
        /// modified
        /// </summary>
        /// <returns></returns>
        [Column("MODIFIED")]
        public DateTime? modified { get; set; }
        /// <summary>
        /// modifier
        /// </summary>
        /// <returns></returns>
        [Column("MODIFIER")]
        public int? modifier { get; set; }
        /// <summary>
        /// salt
        /// </summary>
        /// <returns></returns>
        [Column("SALT")]
        public string salt { get; set; }
        /// <summary>
        /// mobilecaflag
        /// </summary>
        /// <returns></returns>
        [Column("MOBILECAFLAG")]
        public string mobilecaflag { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(int? keyValue)
        {
            this.id = keyValue;
        }
        #endregion
    }
}

