﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Ucoin.Authority.IServices;
using Ucoin.Identity.DataObjects;

namespace Ucoin.Authority.Site.Areas.Rms.Controllers
{
    public class ResourceController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }

    public class ResourceApiController : ApiController
    {
        public ResourceApiController()
        { 
        }

        private IResourceService resourceService;
        public ResourceApiController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var userName = this.User.Identity.Name;
            var result = await resourceService.GetResourceListByUserName(userName);
            return Json(result);
        }

//        // GET api/menu
//        public dynamic GetEnabled(string id)
//        {
//            var result = new sys_menuService().GetEnabledMenusAndButtons(id);
//            return result;
//        }

        // GET api/menu
        public async Task<IHttpActionResult> GetAll()
        {
            return await this.Get();
        }

//        /// <summary>
//        /// 地址：POST api/mms/send
//        /// 功能：保存菜单数据
//        /// 调用：菜单数据页面，保存按钮
//        /// </summary>
//        [System.Web.Http.HttpPost]
//        public void Edit(dynamic data)
//        {
//            var listWrapper = RequestWrapper.Instance().LoadSettingXmlString(@"
//<settings>
//    <table>
//        sys_menu
//    </table>
//    <where>
//        <field name='MenuCode' cp='equal' variable='_Id'></field>
//    </where>
//</settings>");

//            var service = new sys_menuService();
//            var result = service.Edit(null, listWrapper, data);

//            service.Logger("api/mms/send", "菜单数据", "修改", data);
//        }

        public async Task<IHttpActionResult> GetResourceActions(int id)
        {
            var result = await resourceService.GetResourceActionsByResourceId(id);

            return Json(result);
        }

//        public IEnumerable<dynamic> GetButtons()
//        {
//            var pQuery = ParamQuery.Instance().OrderBy("ButtonSeq");
//            return new sys_buttonService().GetModelList(pQuery);
//        }

//        [System.Web.Http.HttpPost]
//        public void EditMenuButtons(string id, dynamic data)
//        {
//            var service = new sys_menuService();
//            service.SaveMenuButtons(id, data as JToken);
//        }

//        [System.Web.Http.HttpPost]
//        public void EditButton(dynamic data)
//        {
//            var listWrapper = RequestWrapper.Instance().LoadSettingXmlString(@"
//<settings>
//    <table>sys_button</table>
//    <where>
//        <field name='ButtonCode' cp='equal'></field>
//    </where>
//</settings>");
//            var service = new sys_buttonService();
//            var result = service.Edit(null, listWrapper, data);
//        }
    }
}
