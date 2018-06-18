using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;

namespace Net
{
    public class ClientSocket
    {
        private static byte[] result = new byte[1024];
        private static Socket clientSocket;
        //是否已连接的标识  
        public bool IsConnected = false;

        public ClientSocket()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>  
        /// 连接指定IP和端口的服务器  
        /// </summary>  
        /// <param name="ip"></param>  
        /// <param name="port"></param>  
        public void ConnectServer(string ip, int port)
        {
            IPAddress mIp = IPAddress.Parse(ip);
            IPEndPoint ip_end_point = new IPEndPoint(mIp, port);

            try
            {
                clientSocket.Connect(ip_end_point);
                IsConnected = true;
                Debug.Log("连接服务器成功");
            }
            catch
            {
                IsConnected = false;
                Debug.Log("连接服务器失败");
                return;
            }
            //服务器下发数据长度  
            int receiveLength = clientSocket.Receive(result);
            ByteBuffer buffer = new ByteBuffer(result);
            int len = buffer.ReadShort();
            string data = buffer.ReadString();
            Debug.Log("服务器返回数据：" + data);
        }

        /// <summary>  
        /// 发送数据给服务器  
        /// </summary>  
        public string SendMessage(string data)
        {
            string judge1 = null;
            //int message = 0;
            // if (IsConnected == false)
            // return;
            try
            {
                ByteBuffer buffer = new ByteBuffer();
                buffer.WriteString(data);
                clientSocket.Send(WriteMessage(buffer.ToBytes()));

                //接收返回值
                //如果judge1为0，则为注册失败
                //如果judge1为1，则为注册成功
                //如果judge1为2，则为登陆失败
                //如果judge1为3，则为登陆成功
                //如果judge1为4，为序列码已被他人激活
                //如果judge1为5，为序列码未被激活
                clientSocket.Receive(result);
                ByteBuffer buf = new ByteBuffer(result);
                int len = buf.ReadShort();
                judge1 = buf.ReadString();
            }
            catch
            {
                IsConnected = false;
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }

            return judge1;

        }

        public string  Receive()
        {
            ByteBuffer buffer = new ByteBuffer(result);
            int len = buffer.ReadShort();
            string data = buffer.ReadString();
            return data;
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
    }
}
