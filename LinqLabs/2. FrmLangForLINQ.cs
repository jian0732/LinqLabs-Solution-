using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//Notes: LINQ 主要參考 
//組件 System.Core.dll,
//namespace {}  System.Linq
//public static class Enumerable
//


//public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);

//1. 泛型 (泛用方法)                                                                        (ex.  void SwapAnyType<T>(ref T a, ref T b)
//2. 委派參數 Lambda Expression (匿名方法簡潔版)               (ex.  MyWhere(nums, n => n %2==0);
//3. Iterator                                                                                      (ex.  MyIterator)
//4. 擴充方法                                                                                    (ex.  MyStringExtend.WordCount(s); 

namespace Starter
{
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(nwDataSet1.Products);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n1, n2;
            n1 = 100;
            n2 = 200;

            MessageBox.Show(n1 + "," + n2);
            ClsMyUtility.Swap(ref n1, ref n2);
            MessageBox.Show(n1 + "," + n2);
            //=================
            string s1, s2;
            s1 = "aaa";
            s2 = "bbb";
            MessageBox.Show(s1 + "," + s2);
            ClsMyUtility.Swap(ref s1, ref s2);    //call method
            MessageBox.Show(s1 + "," + s2);
            //=====================

            MessageBox.Show(SystemInformation.ComputerName);

        }
        //


        private void button7_Click(object sender, EventArgs e)
        {
            int n1, n2;
            n1 = 100;
            n2 = 200;

            MessageBox.Show(n1 + "," + n2);
            //ClsMyUtility.SwapAnyType<int>(ref n1, ref n2);
            ClsMyUtility.SwapAnyType(ref n1, ref n2); //推斷型別
            MessageBox.Show(n1 + "," + n2);
            //========================
            string s1, s2;
            s1 = "aaa";
            s2 = "bbb";
            MessageBox.Show(s1 + "," + s2);
            ClsMyUtility.SwapAnyType(ref s1, ref s2);
            MessageBox.Show(s1 + "," + s2);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //具名方法
            this.buttonX.Click += ButtonX_Click;
            this.buttonX.Click += aaa;

            //            嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
            //錯誤  CS0123  'bbb' 沒有任何多載符合委派 'EventHandler' LinqLabs C:\shared\LINQ\LinqLabs(Solution)\LinqLabs\2.FrmLangForLINQ.cs    88  作用中

            //            this.buttonX.Click += bbb;

            //=======================
            //2.0 匿名方法
            this.buttonX.Click += delegate (object sender1, EventArgs e1)
                                                                  {
                                                                      MessageBox.Show("匿名方法");
                                                                  };

            this.buttonX.Click += (object sender1, EventArgs e1) =>
            {
                MessageBox.Show("匿名方法");
            };


        }



        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ButtonX click");
        }
        private void aaa(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }
        private void bbb()
        {
            MessageBox.Show("aaa");
        }
        bool test(int n)
        {
            return n > 5;
        }
        bool 找偶數(int n)
        {
            return n % 2 == 0;
        }
        internal delegate bool Mydelegate(int n);//STEP 1 新增委派類別
        private void button9_Click(object sender, EventArgs e)
        {
            bool result;
            MessageBox.Show("result = " + test(10));

            Mydelegate delegateobj = test;//new Mydelegate(test); //STEP 2 新增物件指向方法


            //result = delegateobj(2); //STEP 3 呼叫方法
            result = delegateobj.Invoke(2);
            MessageBox.Show("result =" + result);

            delegateobj = delegate (int a)
            {
                return a % 2 == 0;

            };
            result = delegateobj(9);
            MessageBox.Show("result = " + result);

            delegateobj = n => n % 2 == 0; //labmda
            result = delegateobj(100);
            MessageBox.Show("result= " + result);
        }
        internal List<int> Mywhere(int[] num, Mydelegate Obj)
        {
            List<int> list = new List<int>();
            foreach (int n in num)
            {
                if (Obj(n))
                    list.Add(n);
            }

            return list;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> result = Mywhere(num, test);
            List<int> odd = Mywhere(num, 找偶數);
            List<int> even = Mywhere(num, n => n % 2 == 1);
            foreach (int n in odd)
            {
                listBox1.Items.Add(n);
            }
            foreach (int c in even)
            {
                listBox2.Items.Add(c);
            }
        }



        IEnumerable<int> MyIterator(int[] num, Mydelegate Obj)
        {

            foreach (int n in num)
            {
                if (Obj(n))
                    yield return (n);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> aaa = MyIterator(num, n => n % 2 == 0);

            foreach (int c in aaa)
            {
                listBox1.Items.Add(c);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {


            int[] num = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //IEnumerable<int> q = from ab in num

            //        where ab > 5
            //        select ab;

            ////foreach (var cc in q)
            ////{
            ////    listBox1.Items.Add(cc);
            ////}

            IEnumerable<int> aaa = num.Where(n => n > 5);
            foreach (int s in aaa)
            {
                listBox1.Items.Add(s);
            }

            string[] word = { "aaa", "bbb", "ccccc", "hhhhh" };
            IEnumerable<string> z = word.Where(w => w.Length > 3);
            foreach (string ss in z)
            {
                listBox2.Items.Add(ss);
            }
            this.productsTableAdapter1.Fill(nwDataSet1.Products);
            var d = nwDataSet1.Products.Where(f => f.UnitPrice > 30);

            dataGridView1.DataSource = d.ToList();

        }

        private void button45_Click(object sender, EventArgs e)
        {

            int a = 10;
            int b = 20;
            string x = "aasas";

            var c = new Point(a, b);
            MessageBox.Show(x.ToUpper());
        }
        class Mypoint
        {
           public Mypoint(int p1)
            {

            }
            public Mypoint(int p1,int p2)
            {
                p1 = 100;
                p2 = 200;
            }
            public Mypoint() { }
            private int m_q;
            public int p2 { get; set; }
            public int p1
            {
                get
                {
                    return m_q;
                }
                set
                {
                    m_q = value;
                }
                  
            }
            
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Mypoint pt1 = new Mypoint();
            pt1.p1 = 100;
            pt1.p1 = 200;

            int q = pt1.p1;
            List<Mypoint> hhh = new List<Mypoint>();
            hhh.Add(pt1);


            hhh.Add(new Mypoint { p1 = 100, p2 = 200 });

            dataGridView1.DataSource = hhh;

            List<Mypoint> list2 = new List<Mypoint>
            {
            new Mypoint { p1 = 200, p2 = 300 }

            };


            dataGridView2.DataSource = list2;
        

            

        }

        private void button43_Click(object sender, EventArgs e)
        {
            var pt1 = new { p1 = 123, p2 = 5646, p3 = 456 };
            var pt2 = new { p1 = 123, p2 = 5646, p3 = 456,p4=5455 };
            var pt3 = new { p1 = 123, p2 = 5646, p3 = 456,p4=455,p5=543 };
            listBox1.Items.Add(pt1.GetType());
            int[] asasa = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var tt = asasa.Where(h => h > 5).Select(h => new {總 = h });
            dataGridView1.DataSource = tt.ToList();

            //var q = from dd in asasa

            //        select  new { 初始=q,=q*q}
            productsTableAdapter1.Fill(nwDataSet1.Products);
            //var q = from ww in nwDataSet1.Products
            var q = nwDataSet1.Products.Where(cc => cc.UnitPrice > 30).Select(cc => new { cc.ProductID, cc.UnitPrice, cc.UnitsInStock, 總和 = ($"{cc.UnitsInStock * cc.UnitPrice:C2}")});
             //        where ww.UnitPrice > 30
             //        select new
             //        {
             //            ID = ww.ProductID,
             //            ww.UnitPrice,
             //            ww.UnitsInStock,
             //            total = ww.UnitPrice * ww.UnitsInStock
             //        };

             dataGridView2.DataSource = q.ToList();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            string aa = "123456789";
            
            int count = aa.方法();
            MessageBox.Show("" + count);

            Char ch = aa.Chars(2);
            MessageBox.Show("" + ch);
        }

    }
}
public static class MystringExit
{
    public static int 方法(this string s)
    {
        return s.Length;
    }
    public static Char Chars(this string s,int index)
    {
        return s[index];
    }
}

