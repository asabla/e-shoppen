using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using Eshoppen.Eshop;
using System.Data;

namespace Eshoppen.Code
{
    /// <summary>
    /// To heavy integrated with page to be outsourced to class library
    /// </summary>
    public class DynamicSiteMapProvider : StaticSiteMapProvider
    {
        private readonly object _siteMapLock = new object();
        private SiteMapNode _siteMapRoot;
        private SiteMapNode _siteChildNode;
        private DataTable table;
        private Dictionary<int, SiteMapNode> _siteList = new Dictionary<int, SiteMapNode>();
        //public const string CacheDependencyKey = "WebbshopCache";

        public override SiteMapNode BuildSiteMap()
        {
            lock (_siteMapLock)
            {
                if (_siteMapRoot != null)
                {
                    //If root node already is constructed, return it instead
                    return _siteMapRoot;
                }

                //Clear outs the current sitemap, to make sure that no duplicates excists
                base.Clear();
              
                //Here will the creation be later on
                //CreateSiteMapRoot();
                //CreateSiteMapNodes();

                CreateSiteMap();

                return _siteMapRoot;
            }
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }

        private void CreateSiteMap()
        {
            I_EshopserviceClient client = new I_EshopserviceClient();
            table = new DataTable();
            _siteList.Clear();  //Makes sure that the list is clear and ready to be used

            string key = "";
            string url = "";
            string title = "";
            int parent = 0;
            int id = 0;

            try
            {
                table = client.GetSiteMap().Copy();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when sitemap was loading: " + ex.Message);
            }

            foreach (DataRow row in table.Rows)
            {
                key = row["Title"].ToString();
                url = row["Url"].ToString();
                title = row["Title"].ToString();
                parent = Convert.ToInt32(row["Parent"]);
                id = Convert.ToInt32(row["ID"]);

                try
                {
                    if (parent == 0)
                    {
                        //Then it is root (first node)
                        CreateSiteMapRoot(key, url, title);
                        _siteList.Add(id, _siteMapRoot);  //Makes it possible for childnodes to find it
                    }
                    else
                    {
                        _siteList.Add(id, _siteMapRoot);  //Makes it possible for childnodes to find it

                        //Then it is a childnode
                        int itemp = parent;   //Gets the parent for current row
                        SiteMapNode root = _siteList[itemp];    //Finds the right root node
                        //SiteMapNode test = FindSiteMapNodeFromKey(itemp);
                        //CreateSiteMapNodes(row["Title"].ToString(), row["Url"].ToString(), row["Title"].ToString(), root);
                        CreateSiteMapNodes(key, url, title, root);
                        ChildNodes(id, _siteChildNode);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Något gick fel med Menyn: " + ex.Message);
                    System.Diagnostics.Debug.WriteLine("Parent(itemp): " + parent);
                    System.Diagnostics.Debug.WriteLine("Key: " + key);
                    System.Diagnostics.Debug.WriteLine("Url: " + url);
                    System.Diagnostics.Debug.WriteLine("Title: " + title);
                    System.Diagnostics.Debug.WriteLine("ID: " + id);
                }

                //_siteMapRoot = null;  //Clears it...just in case
            }
        }

        /// <summary>
        /// Add this method right under the ordinary method to add a new node.
        /// This method will find all it's relevent childnodes
        /// </summary>
        /// <param name="id">Parent id</param>
        /// <param name="rootToChild">Sitemapnode from root</param>
        /// <returns>If needed it will also return the last added childnode</returns>
        private SiteMapNode ChildNodes(int id, SiteMapNode rootToChild)
        {
            SiteMapNode childnode = null;
            string key = "";
            string url = "";
            string title = "";
            
            foreach (DataRow row in table.Rows)
            {
                if ((Convert.ToInt32(row["Parent"])) == id)
                {
                    key = row["Title"].ToString();
                    url = row["Url"].ToString();
                    title = row["Title"].ToString();

                    childnode = new SiteMapNode(this, key, url, title);
                    AddNode(childnode, rootToChild);
                }
            }

            return childnode;
        }

        private void CreateSiteMapRoot()    //Default
        {
            _siteMapRoot = new SiteMapNode(this, "Hem", "~/Default.aspx", "Hem");
            AddNode(_siteMapRoot);
        }

        private void CreateSiteMapNodes()   //Default
        {
            SiteMapNode node = null;
            SiteMapNode node2 = null;
            for (int i = 0; i <= 3; i++)
            {
                node = new SiteMapNode(this,
                    string.Format("Child{0}", i),
                    string.Format("~/Default{0}.aspx", i),
                    string.Format("Child{0}", i));
                AddNode(node, _siteMapRoot);

                node2 = new SiteMapNode(this,
                    string.Format("sChild{0}", i),
                    string.Format("~/Sites/Products.aspx?id={0}", i),
                    string.Format("sChild{0}", i));
                AddNode(node2, node);
            }
        }

        /// <summary>
        /// Is used for the root of the site
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        /// <param name="title"></param>
        private void CreateSiteMapRoot(string key, string url, string title)
        {
            _siteMapRoot = new SiteMapNode(this, key, url, title);
            AddNode(_siteMapRoot);
        }

        private void CreateSiteMapNodes(string key, string url, string title, SiteMapNode Root)
        {
            try
            {
                _siteChildNode = new SiteMapNode(this, key, url, title);
                AddNode(_siteChildNode, Root);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Line already excists: " + ex.Message);
            }
        }
    }
}