using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Landlord.GUI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        LandlordEntities context = new LandlordEntities(CreateConnectString());
        private void test_Load(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(123, "This is product 123, one of the best one two threes ever made"));
            products.Add(new Product(456, "This is product 456, an excellent choice"));
            products.Add(new Product(789, "This is product 789, an outstanding value"));
            List<Category> categories = new List<Category>();
            categories.Add(new Category("Bikes", products));
            categories.Add(new Category("Accessories", products));
            categories.Add(new Category("Clothing", products));
            radTreeView1.RootRelationDisplayName = "Categories";
            radTreeView1.RelationBindings.Add(new RelationBinding("Products", products, null, "Description", "ID"));
            radTreeView1.DataSource = categories;



            ObjectQuery<源房> ys = context.源房 ;
            //IQueryable<客房> ks = ys.Select(m => m.客房);

            radTreeView2.RootRelationDisplayName = "KKKKKKKKKKKK";
            radTreeView2.DisplayMember = "房名";
            radTreeView2.ValueMember = "ID";
            radTreeView2.DataSource = ys;

            radTreeView2.RelationBindings.Add(new RelationBinding("客房", ys));

        }
        private void button1_Click(object sender, EventArgs e)
        {
            context.DeleteObject(context.源房.First());
            context.SaveChanges();
            radTreeView2.Text = "deleted the 2 node";
        }    
        
        
        #region 构造实体连接字符串
        private static string CreateConnectString()
        {
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = "System.Data.SqlServerCe.3.5";

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = @"Data Source=|DataDirectory|\Data\Landlord.sdf;Password ='qwlpy0a'";

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";


            return entityBuilder.ToString();
        }
        #endregion


        private void radTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {

        }

        private void radTreeView1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs args = e as MouseEventArgs;
            RadTreeNode clickedNode = radTreeView1.GetNodeAt(args.X, args.Y);
            if (clickedNode != null)
            {
                MessageBox.Show("Node Text: " + clickedNode.Text + "  Node Value: " + clickedNode.Tag);
            }

        }


    }


    public class Category
    {
        public Category(string name, List<Product> products)
        {
            _name = name;
            _products = products;
        }
        private List<Product> _products;
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
    }
    public class Product
    {
        public Product(int id, string description)
        {
            _id = id;
            _description = description;
        }
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }

}
