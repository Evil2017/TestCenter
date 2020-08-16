using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCenter.Business.OrganizationManage;
using TestCenter.Business.SystemManage;
using TestCenter.Enum;
using TestCenter.Model.Result;
using TestCenter.Util;
using TestCenter.Util.Extension;
using TestCenter.Util.Model;
using TestCenter.Web.Code;

namespace TestCenter.WebMvc.Controllers
{
    public class HomeController : BaseController
    {
        private MenuBLL menuBLL = new MenuBLL();
        private UserBLL userBLL = new UserBLL();
        private LogLoginBLL logLoginBLL = new LogLoginBLL();
        private MenuAuthorizeBLL menuAuthorizeBLL = new MenuAuthorizeBLL();

        #region 视图功能
        [HttpGet]
        [AuthorizeFilter]
        public async Task<IActionResult> Index()
        {
            OperatorInfo operatorInfo = await Operator.Instance.Current();

            TData<List<MenuEntity>> objMenu = await menuBLL.GetList(null);
            List<MenuEntity> menuList = objMenu.Data;
            menuList = menuList.Where(p => p.MenuStatus == StatusEnum.Yes.ParseToInt()).ToList();

            if (operatorInfo.IsSystem != 1)
            {
                TData<List<MenuAuthorizeInfo>> objMenuAuthorize = await menuAuthorizeBLL.GetAuthorizeList(operatorInfo);
                List<long?> authorizeMenuIdList = objMenuAuthorize.Data.Select(p => p.MenuId).ToList();
                menuList = menuList.Where(p => authorizeMenuIdList.Contains(p.Id)).ToList();
            }

            ViewBag.MenuList = menuList;
            ViewBag.OperatorInfo = operatorInfo;
            return View();
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (GlobalContext.SystemConfig.Demo)
            {
                ViewBag.UserName = "admin";
                ViewBag.Password = "123456";
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoginOff()
        {
            #region 退出系统
            OperatorInfo user = await Operator.Instance.Current();
            if (user != null)
            {
                // 如果不允许同一个用户多次登录，当用户登出的时候，就不在线了
                if (!GlobalContext.SystemConfig.LoginMultiple)
                {
                    await userBLL.UpdateUser(new UserEntity { Id = user.UserId, IsOnline = 0 });
                }

                // 登出日志
                await logLoginBLL.SaveForm(new LogLoginEntity
                {
                    LogStatus = OperateStatusEnum.Success.ParseToInt(),
                    Remark = "退出系统",
                    IpAddress = NetHelper.Ip,
                    IpLocation = string.Empty,
                    Browser = NetHelper.Browser,
                    OS = NetHelper.GetOSVersion(),
                    ExtraRemark = NetHelper.UserAgent,
                    BaseCreatorId = user.UserId
                });

                Operator.Instance.RemoveCurrent();
                new CookieHelper().RemoveCookie("RememberMe");
            }
            #endregion
            return View(nameof(Login));
        }

        [HttpGet]
        public IActionResult NoPermission()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public IActionResult Skin()
        {
            return View();
        }
        #endregion

        #region 获取数据
        public IActionResult GetCaptchaImage()
        {
            string sessionId = GlobalContext.ServiceProvider?.GetService<IHttpContextAccessor>().HttpContext.Session.Id;

            Tuple<string, int> captchaCode = CaptchaHelper.GetCaptchaCode();
            byte[] bytes = CaptchaHelper.CreateCaptchaImage(captchaCode.Item1);
            new SessionHelper().WriteSession("CaptchaCode", captchaCode.Item2);
            return File(bytes, @"image/jpeg");
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<IActionResult> LoginJson(string userName, string password, string captchaCode)
        {
            TData obj = new TData();
            if (string.IsNullOrEmpty(captchaCode))
            {
                obj.Message = "验证码不能为空";
                return Json(obj);
            }
            if (captchaCode != new SessionHelper().GetSession("CaptchaCode").ParseToString())
            {
                obj.Message = "验证码错误，请重新输入";
                return Json(obj);
            }
            TData<UserEntity> userObj = await userBLL.CheckLogin(userName, password, (int)PlatformEnum.Web);
            if (userObj.Tag == 1)
            {
                await new UserBLL().UpdateUser(userObj.Data);
                await Operator.Instance.AddCurrent(userObj.Data.WebToken);
            }

            string ip = NetHelper.Ip;
            string browser = NetHelper.Browser;
            string os = NetHelper.GetOSVersion();
            string userAgent = NetHelper.UserAgent;

            Action taskAction = async () =>
            {
                LogLoginEntity logLoginEntity = new LogLoginEntity
                {
                    LogStatus = userObj.Tag == 1 ? OperateStatusEnum.Success.ParseToInt() : OperateStatusEnum.Fail.ParseToInt(),
                    Remark = userObj.Message,
                    IpAddress = ip,
                    IpLocation = IpLocationHelper.GetIpLocation(ip),
                    Browser = browser,
                    OS = os,
                    ExtraRemark = userAgent,
                    BaseCreatorId = userObj.Data?.Id
                };

                // 让底层不用获取HttpContext
                logLoginEntity.BaseCreatorId = logLoginEntity.BaseCreatorId ?? 0;

                await logLoginBLL.SaveForm(logLoginEntity);
            };
            AsyncTaskHelper.StartTask(taskAction);

            obj.Tag = userObj.Tag;
            obj.Message = userObj.Message;
            return Json(obj);
        }
        #endregion
    }

    /// <summary>
    /// 基础控制器，用来记录访问日志
    /// </summary>
    public class BaseController : Controller
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string action = context.RouteData.Values["Action"].ParseToString();
            OperatorInfo user = await Operator.Instance.Current();

            if (GlobalContext.SystemConfig.Demo)
            {
                if (context.HttpContext.Request.Method.ToUpper() == "POST")
                {
                    string[] allowAction = new string[] { "LoginJson", "ExportUserJson", "CodePreviewJson" };
                    if (!allowAction.Select(p => p.ToUpper()).Contains(action.ToUpper()))
                    {
                        TData obj = new TData();
                        obj.Message = "演示模式，不允许操作";
                        context.Result = new JsonResult(obj);
                        return;
                    }
                }
            }

            var resultContext = await next();

            sw.Stop();
            string ip = NetHelper.Ip;
            LogOperateEntity operateEntity = new LogOperateEntity();
            var areaName = context.RouteData.DataTokens["area"] + "/";
            var controllerName = context.RouteData.Values["controller"] + "/";
            string currentUrl = "/" + areaName + controllerName + action;

            string[] notLogAction = new string[] { "GetServerJson", "Error" };
            if (!notLogAction.Select(p => p.ToUpper()).Contains(action.ToUpper()))
            {
                #region 获取请求参数
                switch (context.HttpContext.Request.Method.ToUpper())
                {
                    case "GET":
                        operateEntity.ExecuteParam = context.HttpContext.Request.QueryString.Value.ParseToString();
                        break;

                    case "POST":
                        if (context.ActionArguments?.Count > 0)
                        {
                            operateEntity.ExecuteUrl += context.HttpContext.Request.QueryString.Value.ParseToString();
                            operateEntity.ExecuteParam = TextHelper.GetSubString(JsonConvert.SerializeObject(context.ActionArguments), 4000);
                        }
                        else
                        {
                            operateEntity.ExecuteParam = context.HttpContext.Request.QueryString.Value.ParseToString();
                        }
                        break;
                }
                #endregion

                #region 异常获取
                StringBuilder sbException = new StringBuilder();
                if (resultContext.Exception != null)
                {
                    Exception exception = resultContext.Exception;
                    sbException.AppendLine(exception.Message);
                    while (exception.InnerException != null)
                    {
                        sbException.AppendLine(exception.InnerException.Message);
                        exception = exception.InnerException;
                    }
                    sbException.AppendLine(resultContext.Exception.StackTrace);
                    operateEntity.LogStatus = OperateStatusEnum.Fail.ParseToInt();
                }
                else
                {
                    operateEntity.LogStatus = OperateStatusEnum.Success.ParseToInt();
                }
                #endregion

                #region 日志实体                  
                if (user != null)
                {
                    operateEntity.BaseCreatorId = user.UserId;
                }

                operateEntity.ExecuteTime = sw.ElapsedMilliseconds.ParseToInt();
                operateEntity.IpAddress = ip;
                operateEntity.ExecuteUrl = currentUrl.Replace("//", "/");
                operateEntity.ExecuteResult = TextHelper.GetSubString(sbException.ToString(), 4000);
                #endregion

                Action taskAction = async () =>
                {
                    // 让底层不用获取HttpContext
                    operateEntity.BaseCreatorId = operateEntity.BaseCreatorId ?? 0;

                    // 耗时的任务异步完成
                    // operateEntity.IpLocation = IpLocationHelper.GetIpLocation(ip);
                    await new LogOperateBLL().SaveForm(operateEntity);
                };
                AsyncTaskHelper.StartTask(taskAction);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }

    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}
}
