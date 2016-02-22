using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.Text;

namespace WebApplication.Models
{
    public class Data
    {
        WebApplication.Models.ds _ds = new WebApplication.Models.ds();
        WebApplication.Models.ds.CategoryRow _current_Category;

        public WebApplication.Models.ds.CategoryRow AddCategory(string category)
        {
            _current_Category = _ds.Category.AddCategoryRow(category);
            return _current_Category; 
        }

        public void AddPortlet(string link,int column_No,string title,int row_Sequence,bool is_Image_Allowed)
        {
            _ds.Portlet.AddPortletRow(_current_Category, link, column_No, title, row_Sequence, is_Image_Allowed, "");
        }


        public WebApplication.Models.ds Complete()
        {
            XmlDocument objDoc = new XmlDocument();
            DataRow[] rows = _ds.Portlet.Select("");
       

            foreach (WebApplication.Models.ds.PortletRow row in rows)
            {
                try
                {
                    objDoc.Load( row.Link);
                    row.RSS_Feed = objDoc.InnerXml;
                }
                catch
                {
                    row.RSS_Feed = "";
                }
            }
            return _ds;
        }

    }
}
