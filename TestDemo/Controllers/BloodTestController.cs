using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestDemo.Controllers
{
    public class BloodTestController : Controller
    {
        //
        // GET: /BloodTest/

        public ActionResult Index()
        {

            return View();
        }


        /// <summary>
        /// 酶标版列表
        /// </summary>
        /// <returns></returns>

        public ActionResult BoardList()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult BloodFastTest()
        {
            return View();
        }
        /// <summary>
        /// 获取酶标版列表
        /// </summary>
        /// <returns></returns>
        public string GetBoardList(string Sdate, string Edate, string BoardNO, string type)
        {
            // return VilnkDAL.BloodTest.BoardList_Get(Sdate, Edate, BoardNO, type);
            return "";
        }
        public ActionResult View_BoardCreate()
        {
            return View();
        }

        public ActionResult TestPotencySend()
        {
            return View();
        }

        public ActionResult TestPotencyAloneSend()
        {
            return View();
        }

        /// <summary>
        /// 创建酶标版
        /// </summary>
        /// <returns></returns>
        public string BoardCreate(string ModelNO, string BloodType = "", string IfReTest = "", string type = "", string NewBoardNO = "")
        {
            // return VilnkDAL.BloodTest.CreateBoard(ModelNO, BloodType, IfReTest, type, NewBoardNO);
            return "";
        }
        public string getBoardNO(string BloodType = "")
        {
            //return VilnkDAL.BloodTest.getBoardNO(BloodType);
            return "";
        }
        public string getBoardNOType(string BoardNO)
        {
            //return VilnkDAL.BloodTest.getBoardNOType(BoardNO);
            return "";
        }
        /// <summary>
        /// 酶标版详情
        /// </summary>
        /// <returns></returns>
        public ActionResult BoardDedail()
        {
            return View();
        }
        /// <summary>
        /// 获取酶标版的详情
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string getBoardDedail(string BoardNO, string TestItem)
        {
            // return VilnkDAL.BloodTest.getBoardNODedail(BoardNO, TestItem);
            return "";
        }

        /// <summary>
        /// 获取酶标版的基本信息
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string getBoardInfo(string BoardNO)
        {
            // return VilnkDAL.BloodTest.getBoardInfo(BoardNO);
            return "";
        }
        /// <summary>
        /// 批量修改酶标版的内容
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <param name="InitType"></param>
        /// <param name="SNum"></param>
        /// <param name="ENum"></param>
        /// <param name="StartNum"></param>
        /// <returns></returns>
        public string BoardInit(string BoardNO, string InitType, string SNum, string ENum, string StartNum = "0", string Row = "A", string Cell = "01", string TG = "")
        {
            //return VilnkDAL.BloodTest.BoardInit(BoardNO, InitType, SNum, ENum, StartNum, Row, Cell, TG);
            return "";
        }
        /// <summary>
        /// 发布化验结果的界面
        /// </summary>
        /// <returns></returns>
        public ActionResult TestResultView()
        {
            return View();
        }
        /// <summary>
        /// 初始化酶标版上面的化验信息
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <param name="TestItems"></param>
        /// <returns></returns>
        public string TestResultInit(string BoardNO, string TestItems)
        {
            // return VilnkDAL.BloodTest.TestResultInit(BoardNO, TestItems);
            return "";
        }
        /// <summary>
        /// 清空酶标版的布板信息
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string BoardClear(string BoardNO)
        {
            //return VilnkDAL.BloodTest.BoardClear(BoardNO);
            return "";
        }
        /// <summary>
        /// 检验结果发布
        /// </summary>
        /// <returns></returns>
        public ActionResult TestResultSend()
        {
            return View();
        }
        /// <summary>
        /// 根据原始数据计算的结果发布
        /// </summary>
        /// <returns></returns>
        public ActionResult TestResultSendCheck()
        {
            return View();
        }
        /// <summary>
        /// 获取某些检测项目的信息列表
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public string GetItemListInfo(string ItemID)
        {
            //return VilnkDAL.BloodTest.GetItemListInfo(ItemID);
            return "";
        }
        /// <summary>
        /// 获取某个酶标版的标本信息列表用于发布结果
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string getTestResultSendList(string BoardNO)
        {
            //return VilnkDAL.BloodTest.getTestResultSendList(BoardNO);
            return "";
        }
        /// <summary>
        /// 修改某个化验结果的值
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeResult()
        {
            return View();
        }
        /// <summary>
        /// 取得要修改的化验信息
        /// </summary>
        /// <param name="DonateID"></param>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public string getTestResult(string DonateID, string ItemID)
        {
            //return VilnkDAL.BloodTest.getTestResult(DonateID, ItemID);
            return "";
        }
        /// <summary>
        /// 保存修改的结果
        /// </summary>
        /// <param name="DonateID"></param>
        /// <param name="ItemID"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        public string TestResultSave(string DonateID, string ItemID, string Result, string BoardNo, string TestResult)
        {
           // return VilnkDAL.BloodTest.TestResultSave(DonateID, ItemID, Result, BoardNo, TestResult);
            return "";
        }
        /// <summary>
        /// 判断酶标版的结果是否已经发布
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string CheckTestisSend(string BoardNO)
        {
            //  return VilnkDAL.BloodTest.CheckTestisSend(BoardNO);
            return "";
        }

        /// <summary>
        /// 化验结果发布的方法
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <param name="ItemIDs"></param>
        /// <param name="SendDoctor"></param>
        /// <param name="ADoctor"></param>
        /// <returns></returns>
        public string TestResultSendAcion(string BoardNO = "", string ItemIDs = "", string SendDoctor = "", string ADoctor = "", string FID = "", string FID1 = "", string STime = "")
        {
            // return VilnkDAL.BloodTest.TestResultSend(BoardNO, ItemIDs, SendDoctor, ADoctor, FID, FID1, STime);
            return "";
        }
        /// <summary>
        /// 修改酶标版的布局弹出框
        /// </summary>
        /// <returns></returns>
        public ActionResult Dialog_ChangeBoardDail()
        {
            return View();
        }
        /// <summary>
        /// 根据版号和位置获取默认值
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <param name="Row"></param>
        /// <param name="Col"></param>
        /// <returns></returns>
        public string getBoardNODedailInfo(string BoardNO, string Row, string Col)
        {
            //return VilnkDAL.BloodTest.getBoardNODedailInfo(BoardNO, Row, Col);
            return "";
        }
        /// <summary>
        /// 保存酶标版的布局
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <param name="Row"></param>
        /// <param name="Col"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public string BoardDailSave(string BoardNO, string Row, string Col, string Value, string CollNum, string nextType)
        {
            //return VilnkDAL.BloodTest.BoardDailSave(BoardNO, Row, Col, Value, CollNum, nextType);
            return "";
        }
        /// <summary>
        /// 获取酶标版的试剂、检验方法等基本信息
        /// </summary>
        /// <returns></returns>
        public string getBoardSetting(string BoardNO)
        {
            // return VilnkDAL.BloodTest.getBoardSetting(BoardNO);
            return "";
        }
        /// <summary>
        /// 获取酶标版计算公式
        /// </summary>
        /// <returns></returns>
        public string getBoardFormula(string BoardNO)
        {
            //return VilnkDAL.BloodTest.getBoardFormula(BoardNO);
            return "";
        }
        public string getBoardEve(string BoardNO)
        {
            //return VilnkDAL.BloodTest.getBoardEve(BoardNO);
            return "";
        }
        /// <summary>
        /// 删除酶标版计算公式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DelLISFormula(string id)
        {
            //return VilnkDAL.BloodTest.DelLISFormula(id);
            return "";
        }

        /// <summary>
        /// 保存酶标版
        /// </summary>
        /// <returns></returns>
        public string BoardSave()
        {
            //Dictionary<string, string> list = new Dictionary<string, string>();
            //for (int i = 0; i < Request.Form.Count; i++)
            //{
            //    list.Add(Request.Form.Keys[i].ToString(), Request.Form[i].ToString());
            //}
            //return VilnkDAL.BloodTest.BoardSave(list);
            return "";

        }
        public string BoardSavenow()
        {
            //Dictionary<string, string> list = new Dictionary<string, string>();
            //for (int i = 0; i < Request.Form.Count; i++)
            //{
            //    list.Add(Request.Form.Keys[i].ToString(), Request.Form[i].ToString());
            //}
            //return VilnkDAL.BloodTest.BoardSavenow(list);
             return "";

        }
        /// <summary>
        /// 解锁酶标版
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string unLockBoard(string BoardNO)
        {
            //return VilnkDAL.BloodTest.unLockBoard(BoardNO);
            return "";
        }

        public ActionResult TestResult()
        {
            return View();
        }

        public ActionResult TestResultList()
        {
            return View();
        }
        /// <summary>
        /// 获取检验结果列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="DonorID"></param>
        /// <param name="Stime"></param>
        /// <param name="Etime"></param>
        /// <param name="DonorName"></param>
        /// <param name="CertID"></param>
        /// <param name="TestResult"></param>
        /// <returns></returns>
        public string getTestResultList(int page, int rows, string DonorID, string Stime = "", string Etime = "", string DonorName = "", string CertID = "", string TestResult = "", string Donateids = "", string Bectnos = "", string DataType = "")
        {
            //return VilnkDAL.BloodTest.getTestResultList(page, rows, DonorID, Stime, Etime, DonorName, CertID, TestResult, Donateids, Bectnos, DataType);
            return "";
        }
        /// <summary>
        /// 获取原始数据列表
        /// </summary>
        /// <returns></returns>
        public string getSocureResultList(int page, int rows, string boardNO, string TestItem, string Place, string DonateID, string TestResult, string sort)
        {
            // return VilnkDAL.BloodTest.getSocureResultList(page, rows, boardNO, TestItem, Place, DonateID, TestResult, sort);
            return "";
        }
        /// <summary>
        /// 更新标本对应关系
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string SocureResultApply(string BoardNO, string isreturnHtml = "1")
        {
            //return VilnkDAL.BloodTest.SocureResultApply(BoardNO, isreturnHtml);
            return "";
        }
        /// <summary>
        /// 修改原始数据
        /// </summary>
        /// <returns></returns>
        public ActionResult view_Dialog_ChangeSocureResult()
        {
            return View();
        }
        /// <summary>
        /// 获取原始数据的详细信息
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <param name="TestItem"></param>
        /// <param name="Row"></param>
        /// <param name="Coll"></param>
        /// <returns></returns>
        public string get_ChangeSocureResult(string BoardNO, string TestItem, string Row, string Coll)
        {
            // return VilnkDAL.BloodTest.get_ChangeSocureResult(BoardNO, TestItem, Row, Coll);
            return "";
        }
        /// <summary>
        /// 保存原始数据
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <param name="TestItem"></param>
        /// <param name="Row"></param>
        /// <param name="Coll"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string save_ChangeSocureResult(string BoardNO, string TestItem, string Row, string Coll, string value)
        {
            // return VilnkDAL.BloodTest.save_ChangeSocureResult(BoardNO, TestItem, Row, Coll, value);
            return "";
        }
        public string BoardTestInit(string BoardNO)
        {
            //return VilnkDAL.BloodTest.BoardTestInit(BoardNO);
            return "";
        }
        /// <summary>
        /// 化验结果签发
        /// </summary>
        /// <returns></returns>
        public ActionResult view_Result_SendCheck()
        {
            return View();
        }
        /// <summary>
        /// 获取签发的详情
        /// </summary>
        /// <param name="BoardNO"></param>
        /// <returns></returns>
        public string get_Result_SendCheckInfo(string BoardNO)
        {
            //return VilnkDAL.BloodTest.get_Result_SendCheckInfo(BoardNO);
            return "";
        }
        public string save_Result_SendCheckInfo(string BoardNO, string SendDoctor, string SendDate, string SHFIDs)
        {
            // return VilnkDAL.BloodTest.save_Result_SendCheckInfo(BoardNO, SendDoctor, SendDate, SHFIDs);
            return "";
        }
        /// <summary>
        /// 打印酶标版
        /// </summary>
        /// <param name="BoardNo"></param>
        /// <returns></returns>
        public string PrintBoard(string BoardNo, string Type)
        {
            //return VilnkDAL.BloodTest.PrintBoard(BoardNo, Type);
            return "";
        }
        /// <summary>
        /// 打印酶标版信息表
        /// </summary>
        /// <param name="BoardNo"></param>
        /// <returns></returns>
        public string PrintBoardInfo(string BoardNo)
        {
            // return VilnkDAL.BloodTest.PrintBoardInfo(BoardNo);
            return "";
        }
        /// <summary>
        /// 打印化验记录
        /// </summary>
        /// <param name="BoardNo"></param>
        /// <returns></returns>
        public string PrintTestRecoard(string BoardNo, string DonateID, string TestResults = "")
        {
            //return VilnkDAL.BloodTest.PrintTestRecoard(BoardNo, DonateID, TestResults);
            return "";
        }
        public string PrintBHGTestRecoard(string BoardNo, string DonateID, string TestResults = "")
        {
            //return VilnkDAL.BloodTest.PrintBHGTestRecoard(BoardNo, DonateID, TestResults);
            return "";
        }

        public string PrintTestRecoard2(string BoardNo, string DonateID, string TestResults = "")
        {
            //return VilnkDAL.BloodTest.PrintTestRecoard2(BoardNo, DonateID, TestResults);
            return "";
        }

        //007

        public string PrintTestRecoards(string BoardNo, string DonateID)
        {
            //return VilnkDAL.BloodTest.PrintTestRecoardlist(BoardNo, DonateID);
            return "";
        }



        public ActionResult WaitTestDonorList()
        {
            return View();
        }

        public string GetWaitTestDonorList(int page, int rows, string Stime = "", string Etime = "", string DonorID = "")
        {
            //return VilnkDAL.BloodTest.GetWaitTestDonorList(page, rows, Stime, Etime, DonorID);
            return "";
        }
        /// <summary>
        /// 检验报告单
        /// </summary>
        /// <returns></returns>
        public ActionResult TestBoardReport()
        {
            return View();
        }

        /// <summary>
        /// 获取检验报告单数据
        /// </summary>
        /// <returns></returns>
        public ContentResult getTestBoardReport()
        {
            //int page = Request["page"].ToInt32();
            //int rows = Request["rows"].ToInt32();
            //string Stime = Request["Stime"].ToNullString();
            //string Etime = Request["Etime"].ToNullString();
            //string DonorID = Request["_donorid"].ToNullString();
            //string DonateID = Request["_donateid"].ToNullString();
            //string BoardNo = Request["_boardno"].ToNullString();
            //string action = Request["action"].ToNullString();
            //string TestResult = Request["testResult"].ToNullString();
            //string DataType = Request["DataType"].ToNullString();
            //int count = 0;
            //var result = VilnkDAL.BloodTest.getTestBoardReport(action, page, rows, Stime, Etime, DonorID, DonateID, BoardNo, TestResult, out count, "TestResult asc,Place asc", DataType);
            ////  result = "{\"total\":" + count + ",\"rows\":" + result + "}";
            //return Content(result);
            return Content("");
        }
        public string getBloardList(string Stime, string Etime)
        {
            //return VilnkDAL.BloodTest.getBloardList(Stime, Etime);
            return "";
        }
        public string GetIsReagent(string BoardNO)
        {
            //return VilnkDAL.BloodTest.GetIsReagent(BoardNO);
            return "";
        }
        /// <summary>
        /// 快速检测
        /// </summary>
        /// <returns></returns>
        public string TestFastSave()
        {
            //Dictionary<string, string> list = new Dictionary<string, string>();
            //for (int i = 0; i < Request.Form.Count; i++)
            //{
            //    list.Add(Request.Form.Keys[i].ToString(), Request.Form[i].ToString());
            //}
            //return VilnkDAL.BloodTest.TestFastSave(list);
            return "";

        }
        /// <summary>
        /// 删除酶标版
        /// </summary>
        /// <param name="BoardNo"></param>
        /// <returns></returns>
        public string DeleteBoard(string BoardNo)
        {
            //return VilnkDAL.BloodTest.DeleteBoard(BoardNo);
            return "";
        }
        /// <summary>
        /// 试剂使用情况
        /// </summary>
        /// <returns></returns>
        public ActionResult UseOfReagents()
        {
            return View();
        }
        public string getUseOfReagents(int rows, int page, string Sdate, string Edate, string BoardNO)
        {
            //return VilnkDAL.BloodTest.getUseOfReagents(rows, page, Sdate, Edate, BoardNO);
            return "";
        }
        //蛋白发布20190528
        public ActionResult DBTestResultSend()
        {
            return View();
        }

        //初始化数据
        public string ZDBBoardsinit(string BoardNO)
        {
            // return VilnkDAL.BloodTest.ZDBBoardsinit(BoardNO);
            return "";
        }


        public string getSocureResultList1(int rows, int page, string boardNO, string Stime, string Etime, string SDate, string Place, string DonorIDs, string DonorName, string fidle)
        {
            // return VilnkDAL.BloodTest.getSocureResultList1(rows, page, boardNO, Stime, Etime, SDate, Place, DonorIDs, DonorName, "Place asc");
            return "";
        }


        public string getTestPotencySendList(int rows, int page, string boardNO, string Stime, string Etime, string SDate, string Place, string DonorIDs, string DonorName, string fidle)
        {
            // return VilnkDAL.BloodTest.getTestPotencySendList(rows, page, boardNO, Stime, Etime, SDate, Place, DonorIDs, DonorName, "Place asc");
            return "";
        }

        public string TestPotencySave(string json)
        {
            //return VilnkDAL.BloodTest.TestPotencySave(json);
            return "";
        }


        /// <summary>
        /// 打印蛋白原始记录表
        /// </summary>
        /// <param name="BoardNo"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string PrintBoard_DB(string BoardNo, string Type)
        {
            //return VilnkDAL.BloodTest.PrintBoard_DB(BoardNo, Type);
            return "";
        }

        public string PrintBoard_DBKB(string BoardNo, string Type)
        {
            // return VilnkDAL.BloodTest.PrintBoard_DBKB(BoardNo, Type);
            return "";
        }

        // update 修改数据
        public string Updatedbhlxx(string DonorID, string BoardNo, string sDonateID, string Results, string Place, string DonateIDss, string SampleTypess)
        {
            //  return VilnkDAL.BloodTest.updatedbhlxx(DonorID, BoardNo, sDonateID, Results, Place, DonateIDss, SampleTypess);
            return "";
        }



        //总蛋白记录

        public ActionResult DBTestResultSendList()
        {
            return View();
        }

        public string GetDBTestResultSendList(int rows, int page, string boardNO, string Stime, string Etime, string SDate, string DonorIDs, string DonorName, string fidle)
        {
            // return VilnkDAL.BloodTest.GetDBTestResultSendList(rows, page, boardNO, Stime, Etime, SDate, DonorIDs, DonorName, "SPRDate desc");
            return "";
        }

        /// <summary>
        /// 总蛋白数据发布(邵阳)
        /// </summary>
        /// <returns></returns>
        public ActionResult DBTestResultSend_SY()
        {
            return View();
        }


        /// <summary>
        /// 蛋白电泳数据发布(邵阳)
        /// </summary>
        /// <returns></returns>
        public ActionResult DMTestResultSend_SY()
        {
            return View();
        }

        public string GetIsCheckSPR(string DonorID, string Place = "")
        {
            //return VilnkDAL.BloodTest.GetIsCheckSPR(DonorID, Place);
            return "";
        }


        //总蛋白记录

        public ActionResult DBTestResultSendList_sy()
        {
            return View();
        }

        public string GetDBTestResultSendList_sy(int rows, int page, string Stime = "", string Etime = "", string DonorID = "", string DonorName = "")
        {
            //return VilnkDAL.BloodTest.GetDBTestResultSendList_sy(rows, page, Stime, Etime, DonorID, DonorName);
            return "";
        }

        public ActionResult DMTestResultSendList_sy()
        {
            return View();
        }

        public string GetDMTestResultSendList_sy(int rows, int page, string SendNO, string Stime, string Etime, string SDate, string DonorIDs, string DonorName, string DataType)
        {
            //return VilnkDAL.BloodTest.GetDMTestResultSendList_sy(rows, page, SendNO, Stime, Etime, SDate, DonorIDs, DonorName, DataType);
            return "";
        }

        //public string SPRResultSave(string DonateID, string Result, string UserUD,string IfPass, string FID)
        //{
        //    return VilnkDAL.BloodTest.SPRResultSave(DonateID, Result, UserUD, IfPass, FID);
        //}
        /// <summary>
        /// 总蛋白结果发布
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public string SPRResultSave(string json)
        {
            // return VilnkDAL.BloodTest.SPRResultSave(json);
            return "";
        }

        /// <summary>
        /// 蛋白电泳结果发布
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public string SPEResultSave(string json)
        {
            //return VilnkDAL.BloodTest.SPEResultSave(json);
            return "";
        }

        //修改蛋白记录功能
        public ActionResult UpdateDBTestResult()
        {
            return View();
        }

        public string UpdateZdbjl(string sDonateID, string DonorID, string DonorName, string DonateID, string DBHL, string sSampleType)
        {
            //return VilnkDAL.BloodTest.UpdateZdbjl(sDonateID, DonorID, DonorID, DonateID, DBHL, sSampleType);
            return "";
        }
        public string GetSampleSendPrint(string SendNO)
        {
            //return VilnkDAL.BloodTest.GetSampleSendPrint(SendNO);
            return "";
        }
    }
}
