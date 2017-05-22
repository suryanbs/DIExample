using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DIExample
{
    //UI
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer objcontainer = new UnityContainer();
            objcontainer.RegisterType<Customer>();
            objcontainer.RegisterType<IDAL, OracleServerDAL>();
            objcontainer.RegisterType<IDAL, SQLServerDAL>();
            
            Customer cst = objcontainer.Resolve<Customer>();
           // Customer cst = new Customer(new SQLServerDAL());
            cst.CustomerName = "test";
            cst.Add();
        }
    }

    //Middle layer
    public class Customer
    {
        //private SQLServerDAL sdal = new SQLServerDAL();
        //private OracleServerDAL odal = new OracleServerDAL();
        private IDAL Odal;
        public string CustomerName { get; set; }
        public Customer(IDAL iodal)
        {
            Odal = iodal;
        }
        public void Add()
        {

            //if (true)
            //    sdal.Add();
            //else
            //    odal.Add();


            //if (true)
            //    odal = new SQLServerDAL();
            //else
            //    odal = new OracleServerDAL();

            Odal.Add();

        }
    }

    //DAL
    public interface IDAL
    {
        void Add();
    }
    public class SQLServerDAL : IDAL
    {
        public void Add() { }
    }

    public class OracleServerDAL : IDAL
    {
        public void Add() { }
    }
}
