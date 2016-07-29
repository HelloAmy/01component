using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace Help.Common.ViewModel
{
    public class PagerBuilder
    {
        // Fields
        private readonly string actionNameGang;
        private readonly AjaxHelper ajaxGang;
        private readonly AjaxOptions ajaxOptionGang;
        private readonly string controllerNameGang;
        private const string CopyrightText = "";
        private readonly int endPageIndex;
        private const string GoToPageScript = "function _MvcPager_GoToPage(_pib,_mp){var pageIndex;if(_pib.tagName==\"SELECT\"){pageIndex=_pib.options[_pib.selectedIndex].value;}else{pageIndex=_pib.value;var r=new RegExp(\"^\\\\s*(\\\\d+)\\\\s*$\");if(!r.test(pageIndex)){alert(\"%InvalidPageIndexErrorMessage%\");return;}else if(RegExp.$1<1){ _pib.value = pageIndex = 1;}else if(RegExp.$1>_mp){_pib.value = pageIndex = _mp;}}var _hl=document.getElementById(_pib.id+'link').childNodes[0];var _lh=_hl.href;_hl.href=_lh.replace('_MvcPager_PageIndex_',pageIndex);if(_hl.click){_hl.click();}else{var evt=document.createEvent('MouseEvents');evt.initEvent('click',true,true);_hl.dispatchEvent(evt);}_hl.href=_lh;}";
        private IDictionary<string, object> htmlAttributesGang;
        private readonly HtmlHelper htmlGang;
        private const string KeyDownScript = "function _MvcPager_Keydown(e){var _kc,_pib;if(window.event){_kc=e.keyCode;_pib=e.srcElement;}else if(e.which){_kc=e.which;_pib=e.target;}var validKey=(_kc==8||_kc==46||_kc==37||_kc==39||(_kc>=48&&_kc<=57)||(_kc>=96&&_kc<=105));if(!validKey){if(_kc==13){ _MvcPager_GoToPage(_pib,%TotalPageCount%);}if(e.preventDefault){e.preventDefault();}else{event.returnValue=false;}}}";
        private readonly bool mmsAjaxPagingGang;
        private readonly int pageIndexGang;
        private readonly PagerOptions pagerOpitonGang;
        private readonly string routeNameGang;
        private readonly RouteValueDictionary routeValuesGang;
        private const string ScriptPageIndexName = "_MvcPager_PageIndex_";
        private readonly int startPageIndexGang;
        private readonly int totalPageCountGang;

        // Methods
        internal PagerBuilder(HtmlHelper html, AjaxHelper ajax, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes)
        {
            this.totalPageCountGang = 1;
            this.startPageIndexGang = 1;
            this.endPageIndex = 1;
            if (pagerOptions == null)
            {
                pagerOptions = new PagerOptions();
            }
            this.htmlGang = html;
            this.ajaxGang = ajax;
            this.pagerOpitonGang = pagerOptions;
            this.htmlAttributesGang = htmlAttributes;
        }

        internal PagerBuilder(HtmlHelper helper, string actionName, string controllerName, int totalPageCount, int pageIndex, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
            : this(helper, null, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, routeValues, null, htmlAttributes)
        {
        }

        internal PagerBuilder(AjaxHelper helper, string actionName, string controllerName, int totalPageCount, int pageIndex, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
            : this(null, helper, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, routeValues, ajaxOptions, htmlAttributes)
        {
        }

        internal PagerBuilder(HtmlHelper helper, string actionName, string controllerName, int totalPageCount, int pageIndex, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
            : this(helper, null, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, routeValues, ajaxOptions, htmlAttributes)
        {
        }

        internal PagerBuilder(HtmlHelper html, AjaxHelper ajax, string actionName, string controllerName, int totalPageCount, int pageIndex, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            this.totalPageCountGang = 1;
            this.startPageIndexGang = 1;
            this.endPageIndex = 1;
            this.mmsAjaxPagingGang = ajax != null;
            if (string.IsNullOrEmpty(actionName))
            {
                if (ajax != null)
                {
                    actionName = (string)ajax.ViewContext.RouteData.Values["action"];
                }
                else
                {
                    actionName = (string)html.ViewContext.RouteData.Values["action"];
                }
            }
            if (string.IsNullOrEmpty(controllerName))
            {
                if (ajax != null)
                {
                    controllerName = (string)ajax.ViewContext.RouteData.Values["controller"];
                }
                else
                {
                    controllerName = (string)html.ViewContext.RouteData.Values["controller"];
                }
            }
            if (pagerOptions == null)
            {
                pagerOptions = new PagerOptions();
            }
            this.htmlGang = html;
            this.ajaxGang = ajax;
            this.actionNameGang = actionName;
            this.controllerNameGang = controllerName;
            if ((pagerOptions.MaxPageIndex == 0) || (pagerOptions.MaxPageIndex > totalPageCount))
            {
                this.totalPageCountGang = totalPageCount;
            }
            else
            {
                this.totalPageCountGang = pagerOptions.MaxPageIndex;
            }
            this.pageIndexGang = pageIndex;
            this.pagerOpitonGang = pagerOptions;
            this.routeNameGang = routeName;
            this.routeValuesGang = routeValues;
            this.ajaxOptionGang = ajaxOptions;
            this.htmlAttributesGang = htmlAttributes;
            this.startPageIndexGang = pageIndex - (pagerOptions.NumericPagerItemCount / 2);
            if ((this.startPageIndexGang + pagerOptions.NumericPagerItemCount) > this.totalPageCountGang)
            {
                this.startPageIndexGang = (this.totalPageCountGang + 1) - pagerOptions.NumericPagerItemCount;
            }
            if (this.startPageIndexGang < 1)
            {
                this.startPageIndexGang = 1;
            }
            this.endPageIndex = (this.startPageIndexGang + this.pagerOpitonGang.NumericPagerItemCount) - 1;
            if (this.endPageIndex > this.totalPageCountGang)
            {
                this.endPageIndex = this.totalPageCountGang;
            }
        }

        private void AddFirst(ICollection<PagerItem> results)
        {
            PagerItem item = new PagerItem(this.pagerOpitonGang.FirstPageText, 1, this.pageIndexGang == 1, PagerItemType.FirstPage);
            if (!item.Disabled || (item.Disabled && this.pagerOpitonGang.ShowDisabledPagerItems))
            {
                results.Add(item);
            }
        }

        private void AddLast(ICollection<PagerItem> results)
        {
            PagerItem item = new PagerItem(this.pagerOpitonGang.LastPageText, this.totalPageCountGang, this.pageIndexGang >= this.totalPageCountGang, PagerItemType.LastPage);
            if (!item.Disabled || (item.Disabled && this.pagerOpitonGang.ShowDisabledPagerItems))
            {
                results.Add(item);
            }
        }

        private void AddMoreAfter(ICollection<PagerItem> results)
        {
            if (this.endPageIndex < this.totalPageCountGang)
            {
                int pageIndex = this.startPageIndexGang + this.pagerOpitonGang.NumericPagerItemCount;
                if (pageIndex > this.totalPageCountGang)
                {
                    pageIndex = this.totalPageCountGang;
                }
                PagerItem item = new PagerItem(this.pagerOpitonGang.MorePageText, pageIndex, false, PagerItemType.MorePage);
                results.Add(item);
            }
        }

        private void AddMoreBefore(ICollection<PagerItem> results)
        {
            if ((this.startPageIndexGang > 1) && this.pagerOpitonGang.ShowMorePagerItems)
            {
                int pageIndex = this.startPageIndexGang - 1;
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                PagerItem item = new PagerItem(this.pagerOpitonGang.MorePageText, pageIndex, false, PagerItemType.MorePage);
                results.Add(item);
            }
        }

        private void AddNext(ICollection<PagerItem> results)
        {
            PagerItem item = new PagerItem(this.pagerOpitonGang.NextPageText, this.pageIndexGang + 1, this.pageIndexGang >= this.totalPageCountGang, PagerItemType.NextPage);
            if (!item.Disabled || (item.Disabled && this.pagerOpitonGang.ShowDisabledPagerItems))
            {
                results.Add(item);
            }
        }

        private void AddPageNumbers(ICollection<PagerItem> results)
        {
            for (int i = this.startPageIndexGang; i <= this.endPageIndex; i++)
            {
                string str = i.ToString();
                if ((i == this.pageIndexGang) && !string.IsNullOrEmpty(this.pagerOpitonGang.CurrentPageNumberFormatString))
                {
                    str = string.Format(this.pagerOpitonGang.CurrentPageNumberFormatString, str);
                }
                else if (!string.IsNullOrEmpty(this.pagerOpitonGang.PageNumberFormatString))
                {
                    str = string.Format(this.pagerOpitonGang.PageNumberFormatString, str);
                }
                PagerItem item = new PagerItem(str, i, false, PagerItemType.NumericPage);
                results.Add(item);
            }
        }

        private void AddPrevious(ICollection<PagerItem> results)
        {
            PagerItem item = new PagerItem(this.pagerOpitonGang.PrevPageText, this.pageIndexGang - 1, this.pageIndexGang == 1, PagerItemType.PrevPage);
            if (!item.Disabled || (item.Disabled && this.pagerOpitonGang.ShowDisabledPagerItems))
            {
                results.Add(item);
            }
        }

        private string BuildGoToPageSection(ref string pagerScript)
        {
            int num;
            ViewContext context = this.mmsAjaxPagingGang ? this.ajaxGang.ViewContext : this.htmlGang.ViewContext;
            if (int.TryParse((string)context.HttpContext.Items["_MvcPager_ControlIndex"], out num))
            {
                num++;
            }
            context.HttpContext.Items["_MvcPager_ControlIndex"] = num.ToString();
            string str = "_MvcPager_Ctrl" + num;
            string str2 = this.GenerateAnchor(new PagerItem("0", 0, false, PagerItemType.NumericPage));
            if (num == 0)
            {
                pagerScript = pagerScript + "function _MvcPager_Keydown(e){var _kc,_pib;if(window.event){_kc=e.keyCode;_pib=e.srcElement;}else if(e.which){_kc=e.which;_pib=e.target;}var validKey=(_kc==8||_kc==46||_kc==37||_kc==39||(_kc>=48&&_kc<=57)||(_kc>=96&&_kc<=105));if(!validKey){if(_kc==13){ _MvcPager_GoToPage(_pib,%TotalPageCount%);}if(e.preventDefault){e.preventDefault();}else{event.returnValue=false;}}}".Replace("%TotalPageCount%", this.totalPageCountGang.ToString()) + "function _MvcPager_GoToPage(_pib,_mp){var pageIndex;if(_pib.tagName==\"SELECT\"){pageIndex=_pib.options[_pib.selectedIndex].value;}else{pageIndex=_pib.value;var r=new RegExp(\"^\\\\s*(\\\\d+)\\\\s*$\");if(!r.test(pageIndex)){alert(\"%InvalidPageIndexErrorMessage%\");return;}else if(RegExp.$1<1){ _pib.value = pageIndex = 1;}else if(RegExp.$1>_mp){_pib.value = pageIndex = _mp;}}var _hl=document.getElementById(_pib.id+'link').childNodes[0];var _lh=_hl.href;_hl.href=_lh.replace('_MvcPager_PageIndex_',pageIndex);if(_hl.click){_hl.click();}else{var evt=document.createEvent('MouseEvents');evt.initEvent('click',true,true);_hl.dispatchEvent(evt);}_hl.href=_lh;}".Replace("%InvalidPageIndexErrorMessage%", this.pagerOpitonGang.InvalidPageIndexErrorMessage).Replace("%PageIndexOutOfRangeErrorMessage%", this.pagerOpitonGang.PageIndexOutOfRangeErrorMessage);
            }
            string str3 = null;
            if (!this.pagerOpitonGang.ShowGoButton)
            {
                str3 = " onchange=\"_MvcPager_GoToPage(this," + this.totalPageCountGang + ")\"";
            }
            StringBuilder builder = new StringBuilder();
            if (this.pagerOpitonGang.PageIndexBoxType == PageIndexBoxType.DropDownList)
            {
                int num2 = this.pageIndexGang - (this.pagerOpitonGang.MaximumPageIndexItems / 2);
                if ((num2 + this.pagerOpitonGang.MaximumPageIndexItems) > this.totalPageCountGang)
                {
                    num2 = (this.totalPageCountGang + 1) - this.pagerOpitonGang.MaximumPageIndexItems;
                }
                if (num2 < 1)
                {
                    num2 = 1;
                }
                int totalPageCountGang = (num2 + this.pagerOpitonGang.MaximumPageIndexItems) - 1;
                if (totalPageCountGang > this.totalPageCountGang)
                {
                    totalPageCountGang = this.totalPageCountGang;
                }
                builder.AppendFormat("<select id=\"{0}\"{1}>", str + "_pib", str3);
                for (int i = num2; i <= totalPageCountGang; i++)
                {
                    builder.AppendFormat("<option value=\"{0}\"", i);
                    if (i == this.pageIndexGang)
                    {
                        builder.Append(" selected=\"selected\"");
                    }
                    builder.AppendFormat(">{0}</option>", i);
                }
                builder.Append("</select>");
            }
            else
            {
                builder.AppendFormat("<input type=\"text\" id=\"{0}\" value=\"{1}\" style=\"width:30px;\" onkeydown=\"_MvcPager_Keydown(event)\"{2}/>", str + "_pib", this.pageIndexGang, str3);
            }
            if (!string.IsNullOrEmpty(this.pagerOpitonGang.PageIndexBoxWrapperFormatString))
            {
                builder = new StringBuilder(string.Format(this.pagerOpitonGang.PageIndexBoxWrapperFormatString, builder));
            }
            if (this.pagerOpitonGang.ShowGoButton)
            {
                builder.AppendFormat("<button onclick=\"_MvcPager_GoToPage(document.getElementById('{1}')," + this.totalPageCountGang + ")\">{0} </button>", this.pagerOpitonGang.GoButtonText, str + "_pib");
            }
            builder.AppendFormat("<span id=\"{0}\" style=\"display:none;width:0px;height:0px\">{1}</span>", str + "_piblink", str2);
            if (!string.IsNullOrEmpty(this.pagerOpitonGang.GoToPageSectionWrapperFormatString) || !string.IsNullOrEmpty(this.pagerOpitonGang.PagerItemWrapperFormatString))
            {
                return string.Format(this.pagerOpitonGang.GoToPageSectionWrapperFormatString ?? this.pagerOpitonGang.PagerItemWrapperFormatString, builder);
            }
            return builder.ToString();
        }

        private MvcHtmlString CreateWrappedPagerElement(PagerItem item, string el)
        {
            string str = el;
            switch (item.Type)
            {
                case PagerItemType.FirstPage:
                case PagerItemType.NextPage:
                case PagerItemType.PrevPage:
                case PagerItemType.LastPage:
                    if (!string.IsNullOrEmpty(this.pagerOpitonGang.NavigationPagerItemWrapperFormatString) || !string.IsNullOrEmpty(this.pagerOpitonGang.PagerItemWrapperFormatString))
                    {
                        str = string.Format(this.pagerOpitonGang.NavigationPagerItemWrapperFormatString ?? this.pagerOpitonGang.PagerItemWrapperFormatString, el);
                    }
                    break;

                case PagerItemType.MorePage:
                    if (!string.IsNullOrEmpty(this.pagerOpitonGang.MorePagerItemWrapperFormatString) || !string.IsNullOrEmpty(this.pagerOpitonGang.PagerItemWrapperFormatString))
                    {
                        str = string.Format(this.pagerOpitonGang.MorePagerItemWrapperFormatString ?? this.pagerOpitonGang.PagerItemWrapperFormatString, el);
                    }
                    break;

                case PagerItemType.NumericPage:
                    if ((item.PageIndex != this.pageIndexGang) || (string.IsNullOrEmpty(this.pagerOpitonGang.CurrentPagerItemWrapperFormatString) && string.IsNullOrEmpty(this.pagerOpitonGang.PagerItemWrapperFormatString)))
                    {
                        if (!string.IsNullOrEmpty(this.pagerOpitonGang.NumericPagerItemWrapperFormatString) || !string.IsNullOrEmpty(this.pagerOpitonGang.PagerItemWrapperFormatString))
                        {
                            str = string.Format(this.pagerOpitonGang.NumericPagerItemWrapperFormatString ?? this.pagerOpitonGang.PagerItemWrapperFormatString, el);
                        }
                        break;
                    }
                    str = string.Format(this.pagerOpitonGang.CurrentPagerItemWrapperFormatString ?? this.pagerOpitonGang.PagerItemWrapperFormatString, el);
                    break;
            }
            return MvcHtmlString.Create(str + this.pagerOpitonGang.SeparatorHtml);
        }

        private string GenerateAnchor(PagerItem item)
        {
            if (this.mmsAjaxPagingGang)
            {
                RouteValueDictionary currentRouteValues = this.GetCurrentRouteValues(this.ajaxGang.ViewContext);
                if (item.PageIndex == 0)
                {
                    currentRouteValues.Add(this.pagerOpitonGang.PageIndexParameterName, "_MvcPager_PageIndex_");
                }
                else
                {
                    currentRouteValues.Add(this.pagerOpitonGang.PageIndexParameterName, item.PageIndex);
                }
                if (!string.IsNullOrEmpty(this.routeNameGang))
                {
                    return this.ajaxGang.RouteLink(item.Text, this.routeNameGang, currentRouteValues, this.ajaxOptionGang).ToString();
                }
                return this.ajaxGang.RouteLink(item.Text, currentRouteValues, this.ajaxOptionGang).ToString();
            }
            string str = this.GenerateUrl(item.PageIndex);
            if (!this.pagerOpitonGang.UseJqueryAjax)
            {
                return ("<a href=\"" + str + "\" onclick=\"window.open(this.attributes.getNamedItem('href').value,'_self')\"></a>");
            }
            StringBuilder builder = new StringBuilder();
            if ((!string.IsNullOrEmpty(this.ajaxOptionGang.OnFailure) || !string.IsNullOrEmpty(this.ajaxOptionGang.OnBegin)) || (!string.IsNullOrEmpty(this.ajaxOptionGang.OnComplete) && (this.ajaxOptionGang.HttpMethod.ToUpper() != "GET")))
            {
                builder.Append("$.ajax({type:'").Append((this.ajaxOptionGang.HttpMethod.ToUpper() == "GET") ? "get" : "post");
                builder.Append("',url:$(this).attr('href')");
                if (!string.IsNullOrEmpty(this.pagerOpitonGang.AjaxPara))
                {
                    builder.Append(",data:" + this.pagerOpitonGang.AjaxPara);
                }
                builder.Append(",success:function(data,status,xhr){$('#");
                builder.Append(this.ajaxOptionGang.UpdateTargetId).Append("').html(data);}");
                if (!string.IsNullOrEmpty(this.ajaxOptionGang.OnFailure))
                {
                    builder.Append(",error:").Append(HttpUtility.HtmlAttributeEncode(this.ajaxOptionGang.OnFailure));
                }
                if (!string.IsNullOrEmpty(this.ajaxOptionGang.OnBegin))
                {
                    builder.Append(",beforeSend:").Append(HttpUtility.HtmlAttributeEncode(this.ajaxOptionGang.OnBegin));
                }
                if (!string.IsNullOrEmpty(this.ajaxOptionGang.OnComplete))
                {
                    builder.Append(",complete:").Append(HttpUtility.HtmlAttributeEncode(this.ajaxOptionGang.OnComplete));
                }
                builder.Append("});return false;");
            }
            else if (this.ajaxOptionGang.HttpMethod.ToUpper() == "GET")
            {
                builder.Append("$('#").Append(this.ajaxOptionGang.UpdateTargetId);
                builder.Append("').load($(this).attr('href')");
                if (!string.IsNullOrEmpty(this.pagerOpitonGang.AjaxPara))
                {
                    builder.Append("," + this.pagerOpitonGang.AjaxPara);
                }
                if (!string.IsNullOrEmpty(this.ajaxOptionGang.OnComplete))
                {
                    builder.Append(",").Append(HttpUtility.HtmlAttributeEncode(this.ajaxOptionGang.OnComplete));
                }
                builder.Append(");return false;");
            }
            else
            {
                builder.Append("$.post($(this).attr('href'),");
                if (!string.IsNullOrEmpty(this.pagerOpitonGang.AjaxPara))
                {
                    builder.Append(this.pagerOpitonGang.AjaxPara);
                }
                builder.Append(",function(data) {$('#");
                builder.Append(this.ajaxOptionGang.UpdateTargetId);
                builder.Append("').html(data);});return false;");
            }
            if (!string.IsNullOrEmpty(str))
            {
                return string.Format(CultureInfo.InvariantCulture, "<a href=\"{0}\" onclick=\"{1}\">{2}</a>", new object[] { str, builder, item.Text });
            }
            return this.htmlGang.Encode(item.Text);
        }

        private MvcHtmlString GenerateJqAjaxPagerElement(PagerItem item)
        {
            if (item.Disabled)
            {
                return this.CreateWrappedPagerElement(item, string.Format("<a style=\"color:#808080; text-decoration:none\" disabled=\"disabled\">{0}</a>", item.Text));
            }
            return this.CreateWrappedPagerElement(item, this.GenerateAnchor(item));
        }

        private MvcHtmlString GenerateMsAjaxPagerElement(PagerItem item)
        {
            if ((item.PageIndex == this.pageIndexGang) && !item.Disabled)
            {
                return this.CreateWrappedPagerElement(item, item.Text);
            }
            if (item.Disabled)
            {
                return this.CreateWrappedPagerElement(item, string.Format("<a style=\"color:#808080; text-decoration:none\" disabled=\"disabled\">{0}</a>", item.Text));
            }
            if ((item.PageIndex >= 1) && (item.PageIndex <= this.totalPageCountGang))
            {
                return this.CreateWrappedPagerElement(item, this.GenerateAnchor(item));
            }
            return null;
        }

        private MvcHtmlString GeneratePagerElement(PagerItem item)
        {
            string str = this.GenerateUrl(item.PageIndex);
            if (item.Disabled)
            {
                return this.CreateWrappedPagerElement(item, string.Format("<a style=\"color:#808080; text-decoration:none\" disabled=\"disabled\">{0}</a>", item.Text));
            }
            return this.CreateWrappedPagerElement(item, string.IsNullOrEmpty(str) ? this.htmlGang.Encode(item.Text) : string.Format("<a href='{0}'>{1}</a>", str, item.Text));
        }

        private string GenerateUrl(int pageIndex)
        {
            if ((pageIndex > this.totalPageCountGang) || (pageIndex == this.pageIndexGang))
            {
                return null;
            }
            RouteValueDictionary currentRouteValues = this.GetCurrentRouteValues(this.htmlGang.ViewContext);
            if (pageIndex == 0)
            {
                currentRouteValues.Add(this.pagerOpitonGang.PageIndexParameterName, "_MvcPager_PageIndex_");
            }
            else
            {
                currentRouteValues.Add(this.pagerOpitonGang.PageIndexParameterName, pageIndex);
            }
            UrlHelper helper = new UrlHelper(this.htmlGang.ViewContext.RequestContext);
            if (!string.IsNullOrEmpty(this.routeNameGang))
            {
                return helper.RouteUrl(this.routeNameGang, currentRouteValues);
            }
            return helper.RouteUrl(currentRouteValues);
        }

        private RouteValueDictionary GetCurrentRouteValues(ViewContext viewContext)
        {
            RouteValueDictionary dictionary = this.routeValuesGang ?? new RouteValueDictionary();
            if (string.IsNullOrEmpty(this.pagerOpitonGang.AjaxPara))
            {
                NameValueCollection values = viewContext.HttpContext.Request.QueryString;
                if ((values != null) && (values.Count > 0))
                {
                    string[] array = new string[] { "x-requested-with", "xmlhttprequest", this.pagerOpitonGang.PageIndexParameterName.ToLower() };
                    foreach (string str in values.Keys)
                    {
                        if (!string.IsNullOrEmpty(str) && (Array.IndexOf<string>(array, str.ToLower()) < 0))
                        {
                            dictionary.Add(str, values[str]);
                        }
                    }
                }
            }
            dictionary.Add("action", this.actionNameGang);
            dictionary.Add("controller", this.controllerNameGang);
            return dictionary;
        }

        internal MvcHtmlString RenderPager()
        {
            if ((this.totalPageCountGang <= 1) && this.pagerOpitonGang.AutoHide)
            {
                return MvcHtmlString.Create("");
            }
            if (((this.pageIndexGang > this.totalPageCountGang) && (this.totalPageCountGang > 0)) || (this.pageIndexGang < 1))
            {
                return MvcHtmlString.Create(string.Format("{0}<div style=\"color:red;font-weight:bold\">{1}</div>{0}", "", this.pagerOpitonGang.PageIndexOutOfRangeErrorMessage));
            }
            List<PagerItem> results = new List<PagerItem>();
            if (this.pagerOpitonGang.ShowFirstLast)
            {
                this.AddFirst(results);
            }
            if (this.pagerOpitonGang.ShowPrevNext)
            {
                this.AddPrevious(results);
            }
            if (this.pagerOpitonGang.ShowNumericPagerItems)
            {
                if (this.pagerOpitonGang.AlwaysShowFirstLastPageNumber && (this.startPageIndexGang > 1))
                {
                    results.Add(new PagerItem("1", 1, false, PagerItemType.NumericPage));
                }
                if (this.pagerOpitonGang.ShowMorePagerItems)
                {
                    this.AddMoreBefore(results);
                }
                this.AddPageNumbers(results);
                if (this.pagerOpitonGang.ShowMorePagerItems)
                {
                    this.AddMoreAfter(results);
                }
                if (this.pagerOpitonGang.AlwaysShowFirstLastPageNumber && (this.endPageIndex < this.totalPageCountGang))
                {
                    results.Add(new PagerItem(this.totalPageCountGang.ToString(), this.totalPageCountGang, false, PagerItemType.NumericPage));
                }
            }
            if (this.pagerOpitonGang.ShowPrevNext)
            {
                this.AddNext(results);
            }
            if (this.pagerOpitonGang.ShowFirstLast)
            {
                this.AddLast(results);
            }
            StringBuilder builder = new StringBuilder();
            if (this.mmsAjaxPagingGang)
            {
                foreach (PagerItem item in results)
                {
                    builder.Append(this.GenerateMsAjaxPagerElement(item));
                }
            }
            else if (this.pagerOpitonGang.UseJqueryAjax)
            {
                foreach (PagerItem item2 in results)
                {
                    builder.Append(this.GenerateJqAjaxPagerElement(item2));
                }
            }
            else
            {
                foreach (PagerItem item3 in results)
                {
                    builder.Append(this.GeneratePagerElement(item3));
                }
            }
            TagBuilder builder2 = new TagBuilder(this.pagerOpitonGang.ContainerTagName);
            if (!string.IsNullOrEmpty(this.pagerOpitonGang.Id))
            {
                builder2.GenerateId(this.pagerOpitonGang.Id);
            }
            if (!string.IsNullOrEmpty(this.pagerOpitonGang.CssClass))
            {
                builder2.AddCssClass(this.pagerOpitonGang.CssClass);
            }
            if (!string.IsNullOrEmpty(this.pagerOpitonGang.HorizontalAlign))
            {
                string str = "text-align:" + this.pagerOpitonGang.HorizontalAlign.ToLower();
                if (this.htmlAttributesGang == null)
                {
                    RouteValueDictionary dictionary = new RouteValueDictionary();
                    dictionary.Add("style", str);
                    this.htmlAttributesGang = dictionary;
                }
                else if (this.htmlAttributesGang.Keys.Contains("style"))
                {
                    IDictionary<string, object> dictionary2;
                    (dictionary2 = this.htmlAttributesGang)["style"] = dictionary2["style"] + ";" + str;
                }
            }
            builder2.MergeAttributes<string, object>(this.htmlAttributesGang, true);
            if (!string.IsNullOrEmpty(this.pagerOpitonGang.PageHeadSectionAttachFormatString))
            {
                builder.Insert(0, this.pagerOpitonGang.PageHeadSectionAttachFormatString + this.pagerOpitonGang.SeparatorHtml);
            }
            if (!string.IsNullOrEmpty(this.pagerOpitonGang.PagerTailSectionAttachFormatString))
            {
                builder.Append(this.pagerOpitonGang.PagerTailSectionAttachFormatString);
                builder.Append(this.pagerOpitonGang.SeparatorHtml);
            }
            string pagerScript = string.Empty;
            if (this.pagerOpitonGang.ShowPageIndexBox)
            {
                builder.Append(this.BuildGoToPageSection(ref pagerScript));
            }
            else
            {
                builder.Length -= this.pagerOpitonGang.SeparatorHtml.Length;
            }
            builder2.InnerHtml = builder.ToString();
            if (!string.IsNullOrEmpty(pagerScript))
            {
                pagerScript = "<script type=\"text/javascript\">//<![CDATA[\r\n" + pagerScript + "\r\n//]]>\r\n</script>";
            }
            return MvcHtmlString.Create(pagerScript + builder2.ToString(TagRenderMode.Normal));
        }

    }
}
