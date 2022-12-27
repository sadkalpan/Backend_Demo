using System;

namespace YoutubeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IoC Container Ninject
            CustomerManager customerManager = 
                new CustomerManager(new NhCustomerDal(),
                new MainLoggerAdapter());
            customerManager.Save(new Customer());
        }
    }

    class NhCustomerDal : ICustomerDal
    {
        public void Save(Customer customer)
        {
            Console.WriteLine("Customer added with nh");
        }
    }
    class EfCustomerDal : ICustomerDal
    {
        public void Save(Customer customer)
        {
            Console.WriteLine("Customer added with ef");
        }
    }
    internal interface ICustomerDal
    {
        public void Save(Customer customer);
    }

    class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private ILogger _logger;
        //Logger logger = new Logger();
        public CustomerManager(ICustomerDal customerDal, ILogger logger)
        {
            _customerDal = customerDal;
            _logger = logger;
            //logger.Log(LoggerType.File);
        }

        public void Save(Customer customer)
        {
            _customerDal.Save(customer);
            _logger.Log();
        }
    }

    internal interface ICustomerService
    {
        void Save(Customer customer);
    }

    class Customer
    {
        public int Id { get; set; }
        public int FirstName { get; set; }

    }
    
    class Logger
    {
        DatabaseLogger databaseLogger = new DatabaseLogger();
        public void Log(/*LoggerType loggerType*/)
        {
            //if (loggerType == LoggerType.File)
            //{
            //    Console.WriteLine("Log to file");
            //}
            //else if(loggerType == LoggerType.DataBase)
            //{
            //    Console.WriteLine("Log to db");
            //}
            //--------------------------------------
            

        }
    } 
    //enum LoggerType
    //{
    //    DataBase, File
    //}

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log to db");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log to file");
        }
    }

    class EmailLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log to email");
        }
    }

    class MainLoggerAdapter : ILogger
    {
        public void Log()
        {
            MainLogger _mainLogger = new MainLogger();
            _mainLogger.LogToMain();
        }
    }
    class MainLogger
    {
        public void LogToMain()
        {
            Console.WriteLine("Log to main");
        }
    }
}
