using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using Net;
using System.IO;

using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace ConsoleApp1
{
    class Program
    {
        private static byte[] result = new byte[1024];
        private const int port = 8088;
        private static string IpStr = "172.24.48.6";
        private static Socket serverSocket;
        


        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse(IpStr);
            IPEndPoint ip_end_point = new IPEndPoint(ip, port);
            //创建服务器Socket对象，并设置相关属性  
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定ip和端口  
            serverSocket.Bind(ip_end_point);
            //设置最长的连接请求队列长度  
            serverSocket.Listen(10);
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            //在新线程中监听客户端的连接  
            Thread thread = new Thread(ClientConnectListen);
            thread.Start();
            Console.ReadLine();
        }

        /// <summary>  
        /// 客户端连接请求监听  
        /// </summary>  
        private static void ClientConnectListen()
        {
            while (true)
            {
                //为新的客户端连接创建一个Socket对象  
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("客户端{0}成功连接", clientSocket.RemoteEndPoint.ToString());
                //向连接的客户端发送连接成功的数据  
                ByteBuffer buffer = new ByteBuffer();
                buffer.WriteString("Connected Server");
                clientSocket.Send(WriteMessage(buffer.ToBytes()));
                //每个客户端连接创建一个线程来接受该客户端发送的消息  
                Thread thread = new Thread(RecieveMessage);
                thread.Start(clientSocket);
            }
        }

        /// <summary>  
        /// 数据转换，网络发送需要两部分数据，一是数据长度，二是主体数据  
        /// </summary>  
        /// <param name="message"></param>  
        /// <returns></returns>  
        private static byte[] WriteMessage(byte[] message)
        {
            MemoryStream ms = null;
            using (ms = new MemoryStream())
            {
                ms.Position = 0;
                BinaryWriter writer = new BinaryWriter(ms);
                ushort msglen = (ushort)message.Length;
                writer.Write(msglen);
                writer.Write(message);
                writer.Flush();
                return ms.ToArray();
            }
        }

        /// <summary>  
        /// 接收指定客户端Socket的消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void RecieveMessage(object clientSocket)
        {
            Socket mClientSocket = (Socket)clientSocket;
            //mClientSocket.Accept();
            while (true)
            {
                try
                {
                    int receiveNumber = mClientSocket.Receive(result);
                    Console.WriteLine("接收客户端{0}消息， 长度为{1}", mClientSocket.RemoteEndPoint.ToString(), receiveNumber);
                    ByteBuffer buff = new ByteBuffer(result);
                    //数据长度  
                    int len = buff.ReadShort();
                    //数据内容  
                    string data = buff.ReadString();            //传入数据库
                    Console.WriteLine("数据内容：{0}", data);

                    //连接数据库，并发送判断值给客户端
                    int judge = ConnectSQL(data);
                    
                    string string_judge = Convert.ToString(judge);
                    Console.WriteLine(string_judge);
                    ByteBuffer buffer = new ByteBuffer();
                    buffer.WriteString(string_judge);
                    mClientSocket.Send(WriteMessage(buffer.ToBytes()));


                    mClientSocket.Close();
                }
                catch (Exception)
                {

                    break;
                }
            }
        }
        /*
         * 连接数据库
         * 其中包含注册、登陆操作
         * 
         */
        private static int ConnectSQL(string str)
        {
            String[] line = str.Split('#');
            for (int x = 0; x < line.Length; x++)
                Console.WriteLine(line[x]);
            //连接数据库
            DataSet dataSet = new DataSet();  // 声明并初始化DataSet
            //SqlDataAdapter dataAdapter;　　 // 声明DataAdapter

            string constr = "server=localhost;User Id=root;password=88888888;Database=kadou";

            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();

            int judge=0;

            //注册
            int result1 = String.Compare("register", line[0]);
            if (result1 == 0)
            {

                //判断注册中所输入的账号是否重复
                string sql1 = "select count(*) from user where user_id = '" + line[1] + "'";
                MySqlCommand cmd = new MySqlCommand(sql1, mycon);
                Object exist = cmd.ExecuteScalar();//执行查询，并返回查询结果集中第一行的第一列。所有其他的列和行将被忽略。select语句无记录返回时，ExecuteScalar()返回NULL值
                int int_exist = int.Parse(exist.ToString());
                if (int_exist == 1)
                {
                    Console.WriteLine("已存在！注册失败！");
                    //judge=0 代表注册失败
                    judge = 0;      
                }
                else
                {
                    Console.WriteLine("注册成功！");

                    //插入数据
                    string sql = InsertSQL(line[1], line[2]);
                    MySqlCommand mycmd = new MySqlCommand(sql, mycon);
                    if (mycmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("数据插入成功！");
                        //judge=1代表注册成功
                        judge = 1;
                    }
                }


                
            }
            //登陆
            int result2 = String.Compare("login", line[0]);
            if (result2 == 0)
            {
                string sql = "select count(*) from user where user_id = '" + line[1] + "' and user_name = '" + line[2] + "'";
                MySqlCommand mycmd2 = new MySqlCommand(sql, mycon);
                Object exist = mycmd2.ExecuteScalar();//执行查询，并返回查询结果集中第一行的第一列。所有其他的列和行将被忽略。select语句无记录返回时，ExecuteScalar()返回NULL值
                int int_exist = int.Parse(exist.ToString());
                if (int_exist == 1)
                {
                    Console.WriteLine("存在，登陆成功！");
                    //judge=3代表登陆成功
                    judge = 3;
                }
                else {
                    Console.WriteLine("账号或者密码不正确！");
                    //judge = 2代表登陆失败
                    judge = 2;
                }
            }

            //验证序列码
            int result3 = String.Compare("sequence", line[0]);
            if (result3 == 0)
            {
                string sql = "select count(*) from pet where pet_id = '" + line[1] + "' and pet_existed = '0'";
                MySqlCommand mycmd2 = new MySqlCommand(sql, mycon);
                Object exist = mycmd2.ExecuteScalar();//执行查询，并返回查询结果集中第一行的第一列。所有其他的列和行将被忽略。select语句无记录返回时，ExecuteScalar()返回NULL值
                int int_exist = int.Parse(exist.ToString());
                if (int_exist == 1)
                {
                    //UPDATE `kadou`.`pet` SET `pet_existed` = '1' WHERE (`pet_id` = '123456789');
                    Console.WriteLine("宠物存在且未被激活！");

                    string sql1 = UpdateSQL(line[1]);
                    MySqlCommand mycmd = new MySqlCommand(sql1, mycon);
                    if (mycmd.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("激活成功！");
                        //judge=5代表序列码存在且未被拥有
                        judge = 5;
                    }

                }
                else
                {
                    Console.WriteLine("宠物已被他人激活！");
                    //judge=4代表序列码存在但已被拥有
                    judge = 4;
                }
            }

            mycon.Close();
            return judge;
        }
        /*
         * 插入操作
        */
        public static string  InsertSQL(string name,string password)
        {
            
            //插入MySql数据库语句的连接
            int int_id = Convert.ToInt32(name);
            Console.WriteLine(int_id);
            string sql = "insert into user(user_id,user_name) values('" + name + "','" + password + "')";
            
            Console.WriteLine(sql);

            return sql;
        }
        /*
         * 修改操作
        */
        public static string UpdateSQL(string string_id)
        {
            string sql = "UPDATE `kadou`.`pet` SET `pet_existed` = '1' WHERE (`pet_id` = '" + string_id + "');";
            return sql;
        }
        /*
         *  查询操作 
         */
        public static void QuerySQL(string name)
        {
            
        }
        private static string toString(MySqlConnection mycon)
        {
            throw new NotImplementedException();
        }
    }
}
